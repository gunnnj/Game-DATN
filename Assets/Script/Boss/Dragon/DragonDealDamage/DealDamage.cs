using UnityEngine;

namespace Script.Boss.Dragon
{
    public class DealDamage : MonoBehaviour
    {
        protected DragonData DragonData;
        protected int Damage;
        private void OnEnable()
        {
            DragonData = GetComponentInParent<DragonData>();
            Damage = DragonData.attackDamage;
        }
    }
}