using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Script.Bullet
{
    public class BulletDamage:MonoBehaviour
    {
        private int damage;
        private string targetName;

        private void OnTriggerEnter(Collider other)
        {
           
            if (other.CompareTag(targetName))
            {
                Debug.Log("Hit target");
                //this.gameObject.SetActive(false);
            }

            if (other.CompareTag("Ground"))
            {
                this.gameObject.SetActive(false);
            }
            
        }


        public void SetTarget(int damage, string targetName)
        {
            this.damage = damage;
            this.targetName = targetName; 
        }
    }
}