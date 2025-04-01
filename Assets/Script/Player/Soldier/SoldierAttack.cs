

using System;
using UnityEngine;

public class SoldierAttack : MonoBehaviour
{

    private SoldierController soldierController;
    [SerializeField] private LayerMask enemyLayer;


    private void Start()
    {
        soldierController = GetComponent<SoldierController>();
    }

    private void Update()
    {
        CheckAttack();
    }

    private void CheckAttack()
    {
        var hit = Physics.OverlapSphere(transform.position, soldierController.SoldierData.RangeAttack, enemyLayer);
        if (hit.Length > 0)
        {
            OnAttack(hit[0]);
        }
        
  
    }



    private void OnAttack(Collider collider)
    {
        if(soldierController.DirectionMovement.magnitude <= 0.3)
        {
            soldierController.SetAttack(collider);
        }
      
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 5f);
    }



}