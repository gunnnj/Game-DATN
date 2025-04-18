using System;
using DG.Tweening;
using Script.Interface;
using UnityEngine;

namespace Script.TowerDefend.HouseSO
{
    public class HouseHealth : MonoBehaviour, IHealthDamage, IGetPresentHealth
    {
        public HouseData HouseData { get; private set; }
        
        public int maxHP { get; private set; }
        
        private int currentHP;

        private void Start()
        {
            HouseData = GetComponent<HouseData>();
            maxHP = HouseData.Health;
            currentHP = maxHP;

        }


        public void Damage(int dame)
        {
          
            currentHP  = currentHP >= dame ? currentHP-dame: 0;
           
            transform.DOScale(transform.localScale * 0.98f, 0.1f);
            if (currentHP == 0)
            {
                Debug.Log("Generate: " + HouseData.AmountSolider);
                int amount = HouseData.AmountSolider;
                for(int i=0; i<amount; i ++ ){
                    SoldierPooling.Instance.GetSoldier(transform.position+new Vector3(i,0f,i));
                }
                gameObject.SetActive(false);
                // Destroy(gameObject);
            }
        }
        
        
        


        public float GetPresentHealth()
        {
            return (float) currentHP / maxHP;
        }
    }
}