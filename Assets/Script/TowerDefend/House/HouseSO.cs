using UnityEngine;

namespace Script.TowerDefend.HouseSO
{
    [CreateAssetMenu(menuName = "Data/HouseSO", fileName =  "HouseSO")]
    public class HouseSO : ScriptableObject
    {
        public int Health = 100;
        public int amountSolider = 3;
    }
}