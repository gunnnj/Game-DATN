using System;
using UnityEngine;

namespace Script.Boss.Dragon
{
    public class DragonAttack : MonoBehaviour
    {

       
        
        private int damage;
        public DragonController DragonController { get; private set; }

        private void Start()
        {
            DragonController = GetComponentInParent<DragonController>();
            damage = DragonController.DragonData.attackDamage;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && DragonController.Target == other.transform)
            {
           
                OnAttack(other.gameObject);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player") && DragonController.Target == other.transform)
            {
                DragonController.IsAttack = false;


            }
        }

        protected virtual void OnAttack(GameObject gameObject)
        {
            DragonController.IsAttack = true;
        }


       
        
        
        
    }
}