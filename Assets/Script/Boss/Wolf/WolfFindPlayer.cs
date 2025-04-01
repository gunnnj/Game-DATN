using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfFindPlayer : EnemyFindTarget
{
    protected override void SetTargetPlayer(Collider other)
    {
        GetComponentInParent<WolfController>().SetTarget(other.transform);
    }
    protected override void SetDisTargetPlayer(Collider other)
    {
        GetComponentInParent<WolfController>().SetTarget(null);
    }
    
}
