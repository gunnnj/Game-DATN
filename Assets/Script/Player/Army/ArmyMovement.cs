using System;
using UnityEngine;

public class ArmyMovement : MonoBehaviour, IMovement
{
    public float Speed { get; private set; }

    private ArmyPlayer units;

    private Vector3 directionMovement;

    private void Start()
    {
        Speed = 4f;
        units = GetComponent<ArmyPlayer>();
    }


    public void SetSpeed(float speed)
    {
        this.Speed *= speed;
    }


    private void Update()
    {
        Movement();


    }

    private void Movement()
    {
        transform.Translate(directionMovement * Time.deltaTime*Speed);
        foreach (SoldierController contrl in units.Players)
        {
            contrl.onMove(directionMovement);
        }
    }

    public void OnMove(Vector3 direction)
    {
        directionMovement = direction;
        //transform.Translate(direction*Time.deltaTime);
    }


}