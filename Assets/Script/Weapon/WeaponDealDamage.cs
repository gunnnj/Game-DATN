

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
                if(other.GetComponent<IHealthDamage>()!=null){
                    other.GetComponent<IHealthDamage>().Damage(Damage);
                    if(other.CompareTag("Enemy")){
                        ManagerUI.Instance.ShowHpMinus(other.transform,Damage);
                    }
                }
                
                StartCoroutine(weaponMovement.DestroyObjectCourutine());
            }
        }

       
    }
}