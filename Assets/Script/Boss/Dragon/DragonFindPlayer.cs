using UnityEngine;

namespace Script.Boss.Dragon.DragonState
{
    public class DragonFindPlayer : EnemyFindTarget
    {
        protected override void SetTargetPlayer(Collider other)
        {
            GetComponentInParent<DragonController>().SetTarget(other.transform);
        }

        protected override void SetDisTargetPlayer(Collider other)
        {
            GetComponentInParent<DragonController>().SetTarget(null);
        }
    }
}