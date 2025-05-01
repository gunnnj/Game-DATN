using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemController : EnemyControl
{
    public SphereCollider sphereCollider;

    void Awake()
    {
        sphereCollider.enabled = false;
    }

    // Event of Animation attack
    public void SpawnEffect(){
        GameObject effect = GetComponentInChildren<GolemAttack>().effectImpact;
        effect.SetActive(true);
        sphereCollider.enabled =true;
    }

    //Event of Animation attack end
    public void DisActiveCollier(){
        sphereCollider.enabled = false;
    }
}
    
