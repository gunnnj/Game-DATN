using DG.Tweening;
using System;
using System.Collections;
using Script.ObjectPooling;
using Script.Player.Soldier;
using Script.Player.Soldier.SoldierState;
using Script.Weapon;

using UnityEngine;
using Random = UnityEngine.Random;

public class SoldierController : MonoBehaviour
{

    public Transform WeaponTarget;
    public Vector3 DirectionMovement { get;set; }
    public SoldierData SoldierData { get ; private set;}
    public Animator Animator {  get; private set; }
    public Rigidbody RB { get; private set; }
    
    public SoliderHealth SoliderHealth { get; private set; }

    
    
    
    #region  State Machine

    public ManagerState ManagerState { get; private set; }
    public IdleState Idle { get; private set; }
    public MoveState Move {  get; private set; }

    public AttackState Attack { get; private set; }

    public Transform target { get; private set; }


    #endregion


    private void Awake()
    {
        SoldierData = GetComponent<SoldierData>();
        SoliderHealth = GetComponent<SoliderHealth>();
    }


    private void Start()
    {
        
        ManagerState = new ManagerState();
        Idle = new IdleState(this, SoldierData, ManagerState, "Idle");
        Move = new MoveState(this, SoldierData, ManagerState, "Move");
        Attack = new AttackState(this, SoldierData, ManagerState, "Attack");
        transform.localScale = Vector3.one * SoldierData.LocalScale;
        Animator = GetComponent<Animator>();
        RB = GetComponent<Rigidbody>();
        
        ManagerState.Initilize(Idle);
    }

    private void Update()
    {
        ManagerState.CurrentState.OnExecute();
    }





    public void SetPostion(Vector3 postion)
    {
        this.transform.DOLocalMove(postion, 1f);
    }

    public void onMove(Vector3 directionMovement)
    {
        DirectionMovement = directionMovement;
    }

    public void SetAttack(Collider collider)
    {

        target = collider.transform;
        ManagerState.ChangeState(Attack);
       
    }


    
    // Add by Event of Animator;
    public void SpawnWeapon()
    {
        GameObject weapon = WeaponPooling.Instance.GetPooledObject();
        weapon.transform.position = WeaponTarget.position;
        weapon.transform.rotation = WeaponTarget.rotation;
        this.WeaponTarget.gameObject.SetActive(false);
        weapon.SetActive(true);
        
        Vector3 targetPosition = new Vector3(target.position.x + Random.Range(-0.3f,0.3f), target.position.y, target.position.z +  Random.Range(-0.3f,0.3f));
        weapon.GetComponent<WeaponMovement>().SetTarget(targetPosition, weapon.transform.position, 1.5f);
        weapon.GetComponent<WeaponDealDamage>().SetDamage(SoldierData.Damage);
    }

    // Add By Event of Animator
    public void SetActiveWeapon()
    {
        this.WeaponTarget.gameObject.SetActive(true);
    }

 



 


}