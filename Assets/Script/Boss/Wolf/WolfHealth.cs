using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Script.Enemy;
using UnityEngine;

public class WolfHealth : EnemyHealth
{
    private bool isTurnShied = false;
    void Update()
    {
        if(!isTurnShied && currentHealth/maxHealth <= 0.5f){
            GetComponent<WolfController>().TurnOnShield();
            isTurnShied = true;
        }
    }
    public override void Dead()
    {
        GameEvent.winGame?.Invoke();
        base.Dead();
    }
}
