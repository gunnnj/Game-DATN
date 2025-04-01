using System;
using Script.Interface;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Script.Player.Soldier
{
    public class SoliderHealth : MonoBehaviour, IHealthDamage, IHealthHeal, IInscreaseArmor, IDecreaseArmor, IDodge
    {
        private SoldierController soldierController;
        public int CurrentHealth { get; private set; }
        public int MaxHealth  { get; private set; }
        public int Armor { get; private set; }
        
        public float RateDodge { get; private set; }


        private void Start()
        {
            soldierController = GetComponent<SoldierController>();
            CurrentHealth = soldierController.SoldierData.Health;
            MaxHealth = soldierController.SoldierData.Health;
            Armor = soldierController.SoldierData.Armor;
            RateDodge = soldierController.SoldierData.RateDodge;
        }


        public void Damage(int dame)
        {
            float random = Random.Range(0f, 100f);
            if (random > RateDodge)
            {
                int dameGet = dame >= Armor ? dame-Armor : 0;
                CurrentHealth = CurrentHealth > dameGet ? CurrentHealth - dameGet : 0;
            }
            else
            {
                Debug.Log("Dodge");
            }
            
            if (CurrentHealth == 0)
            {
                Debug.Log("Player Die");
            }
        }

        public void Heal(int amount)
        {
            CurrentHealth = CurrentHealth + amount < MaxHealth ? CurrentHealth + amount : MaxHealth;
        }

        public void InscreseArmor(int amount)
        {
            Armor += amount;
        }

        public void DecreaseArmor(int amount)
        {
            Armor -= amount;
        }


        public void Dodge(float amount)
        {
            this.RateDodge += amount;
        }
    }
}