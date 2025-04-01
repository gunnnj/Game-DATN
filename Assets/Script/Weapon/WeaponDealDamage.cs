

using System;
using System.Collections;
using UnityEngine;

namespace Script.Weapon
{
    public class WeaponDealDamage : MonoBehaviour
    {
        protected int Damage { set; private get; }

        private WeaponMovement weaponMovement;

        private void Start()
        {
            weaponMovement = GetComponent<WeaponMovement>();
        }

        public void SetDamage(int damage)
        {
            Damage = damage;
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag( "House") || other.CompareTag("Enemy"))
            {
              
                other.GetComponent<IHealthDamage>().Damage(Damage);
                StartCoroutine(weaponMovement.DestroyObjectCourutine());
            }
        }

       
    }
}