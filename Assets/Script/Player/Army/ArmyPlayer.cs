
using System;
using System.Collections.Generic;
using System.Drawing;
using Script.Event;
using Script.Player.Army;
using Script.Player.Army.ArmyLineUp;
using Unity.VisualScripting;
using UnityEngine;

public class ArmyPlayer : MonoBehaviour
{


    public GameObject playerPrefab;
    public List<SoldierController> Players { get; private set; }
    public int GetAmoutPlayer()=>transform.childCount;

   
    [SerializeField] private PlayerUI playerUI;
    public ArmyMovement ArmyMovement { get; private set; }


    #region  State Army 

    private LineUp lineUp = LineUp.Horizontal; 
    public ManagerLineUp ManagerLineUp { get; private set; }
    public HorizontalLineUp HorizontalLineUp { get; private set; }
    public VerticalLineUp VerticalLineUp { get; private set; }
    public TriangleLineUp  TriangleLineUp { get; private set; }
    public RectangleLineUp RectangleLineUp { get; private set; }

    public static ArmyPlayer Instance;

    #endregion
    

    private void Awake()
    {
        Instance = this;
        Players = new List<SoldierController>();
        foreach(Transform t in transform)
        {
            if (t.gameObject.CompareTag("Player"))
            {
                Players.Add(t.GetComponent<SoldierController>());
            }
        }
        
        ManagerLineUp = new ManagerLineUp();
        this.HorizontalLineUp = new HorizontalLineUp(this);
        this.VerticalLineUp = new VerticalLineUp(this);
        this.RectangleLineUp = new RectangleLineUp(this);
        this.TriangleLineUp = new TriangleLineUp(this);


    }


    private void Start()
    {
        playerUI = GameObject.Find("PlayerUI").GetComponent<PlayerUI>();
        ArmyMovement = GetComponent<ArmyMovement>();
        playerUI.Initialize(ArmyMovement);
        
        this.ManagerLineUp.Initialize(HorizontalLineUp);
    }

    private void Update()
    {
        ManagerLineUp.CurrentLineUp.OnExecuteLineUp();
    }


    private void OnEnable()
    {
        PlayerEvent.addPlayer += AddPlayer;
        ArmyEvent.ChangeLineUpArmy += ChangeLineUpArmy;
    }

    private void OnDisable()
    {
        PlayerEvent.addPlayer -= AddPlayer;
        ArmyEvent.ChangeLineUpArmy += ChangeLineUpArmy;
    }

    private void AddPlayer(Vector3 postion)
    {
        GameObject game =  Instantiate(playerPrefab, postion, Quaternion.identity, transform);
    
        Players.Add(game.GetComponent<SoldierController>());
        ChangeLineUpArmy(this.lineUp);
    }

    private void ChangeLineUpArmy(LineUp lineUp)
    {
        if (lineUp == LineUp.Horizontal)
        {
            ManagerLineUp.ChangeLineUp(this.HorizontalLineUp);
        }
        else if (lineUp == LineUp.Vertical)
        {
            ManagerLineUp.ChangeLineUp(this.VerticalLineUp);
        }
        else if (lineUp == LineUp.Triangle)
        {
            if (Players.Count <= 3) return;
            else ManagerLineUp.ChangeLineUp(this.TriangleLineUp);
        }
        else if (lineUp == LineUp.Rectangle)
        {
            
            if (Players.Count <= 3) return;
            else ManagerLineUp.ChangeLineUp(this.RectangleLineUp);
        }

        this.lineUp = lineUp;
    }

    

    public void SetHorizontal()
    {
        List<Vector3> lineup = ArmyFormation.Horizontal(Players.Count);
        for(int i = 0; i < lineup.Count; i++) {
            Players[i].SetPostion(lineup[i]);
        }
        
    }


    public void SetVertical()
    {
        List<Vector3> lineup = ArmyFormation.Vertical(Players.Count);
        for (int i = 0; i < lineup.Count; i++)
        {

            Players[i].SetPostion(lineup[i]);


        }
    }


    public void SetTriangle()
    {
        List<Vector3> lineup = ArmyFormation.Triangle(Players.Count);
        
        for (int i = 0; i < lineup.Count; i++)
        {

            Players[i].SetPostion(lineup[i]);


        }
    }


    public void SetRectangle()
    {
        List<Vector3> lineup = ArmyFormation.Rectangle(Players.Count);
        for (int i = 0; i < lineup.Count; i++)
        {
            Players[i].SetPostion(lineup[i]);
        }
    }

}