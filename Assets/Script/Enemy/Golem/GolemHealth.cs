using System.Collections;
using System.Collections.Generic;
using Script.Enemy;
using UnityEngine;

public class GolemHealth : EnemyHealth
{
    public override void Dead()
    {
        if(!GameEvent.isLose){
            GameEvent.winGame?.Invoke();
        }
        base.Dead();
    }
}
