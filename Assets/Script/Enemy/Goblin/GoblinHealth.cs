using System.Collections;
using System.Collections.Generic;
using Script.Enemy;
using UnityEngine;

public class GoblinHealth : EnemyHealth
{
    public override void Start()
    {
        // maxHealth = LoadDataGame.Instance.GetMaxHpGoblin();
        base.Start();
        GetComponent<SpawnCoin>().amoutCoin = LoadDataGame.Instance.GetGoldGoblinSpawn();
    }
    public override void Dead()
    {
        base.Dead();
        if(!GameEvent.isLose){
            GameEvent.winGame?.Invoke();
        }
        
    }
}
