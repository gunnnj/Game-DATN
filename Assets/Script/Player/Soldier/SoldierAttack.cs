

using System;
using Script.Event;
using UnityEngine;

public class SoldierAttack : MonoBehaviour
{

    private SoldierController soldierController;
    [SerializeField] private LayerMask enemyLayer;
    private Vector3 targetEnemy;

    void OnEnable()
    {
        ArmyEvent.targetEnemy += SetTargetEnemy;
    }
    void OnDisable()
    {
        ArmyEvent.targetEnemy -= SetTargetEnemy;
    }

    private void Start()
    {
        soldierController = GetComponent<SoldierController>();
    }

    private void Update()
    {
        // CheckAttack();
    }
    public void SetTargetEnemy(Transform position){
        OnAttack(position);
    }

    // private void CheckAttack()
    // {
    //     var hit = Physics.OverlapSphere(transform.position, soldierController.SoldierData.RangeAttack, enemyLayer);
    //     if (hit.Length > 0)
    //     {
    //         OnAttack(hit[0]);
    //     }
        
  
    // }



    private void OnAttack(Transform target)
    {
        if(soldierController.DirectionMovement.magnitude <= 0.3)
        {
            soldierController.SetAttack(target);
        }
      
    }

    // private void OnDrawGizmosSelected()
    // {
    //     Gizmos.color = Color.yellow;
    //     Gizmos.DrawWireSphere(transform.position,soldierController.SoldierData.RangeAttack);
    // }



}