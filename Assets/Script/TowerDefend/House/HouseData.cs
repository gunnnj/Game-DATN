using System;
using UnityEngine;

namespace Script.TowerDefend.HouseSO
{
    public class HouseData : MonoBehaviour
    {
        [SerializeField]private HouseSO HouseSO;
        public int Health { get; private set; }
        
        public int AmountSolider { get; private set; }


        private void Awake()
        {
            Health = HouseSO.Health;
            AmountSolider = HouseSO.amountSolider;
        }
    }
}