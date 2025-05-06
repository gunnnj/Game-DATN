using System.Collections;
using System.Collections.Generic;
using Script.Enemy;
using UnityEngine;

public class GolemHealth : EnemyHealth
{
    public override void Dead()
    {
        
        GameEvent.winGame?.Invoke();
        base.Dead();
    }
}
