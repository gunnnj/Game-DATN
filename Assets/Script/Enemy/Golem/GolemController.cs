using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemController : EnemyControl
{
    // Event of Animation attack
    public void SpawnEffect(){
        GameObject effect = GetComponentInChildren<GolemAttack>().effectImpact;
        effect.SetActive(true);
    }
}
    
