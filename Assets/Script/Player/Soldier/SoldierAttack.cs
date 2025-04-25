

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

    public void SetTargetEnemy(Transform position){
        OnAttack(position);
    }

    private void OnAttack(Transform target)
    {
        if(soldierController.DirectionMovement.magnitude <= 0.3)
        {
            soldierController.SetAttack(target);
        }
      
    }
}