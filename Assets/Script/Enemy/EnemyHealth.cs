using System;
using Script.Interface;
using UnityEngine;
using UnityEngine.Serialization;

namespace Script.Enemy
{
    public class EnemyHealth : MonoBehaviour, IHealthDamage, IGetPresentHealth
    {
        [SerializeField]private int maxHealth = 100;
        private int currentHealth = 100;

        private void Start()
        {
            currentHealth = maxHealth;
        }

        public void Damage(int dame)
        {
            currentHealth  = currentHealth >= dame ? currentHealth-dame: 0;
           
           
            if (currentHealth == 0)
            {
                Debug.Log("Die");
                Dead();
            }
        }

        public float GetPresentHealth()
        {
            return (float) currentHealth / maxHealth;
        }

        public void Dead(){
            gameObject.SetActive(false);
            // EnemyPooling.Instance.SetObjectPool(gameObject);
        }
    }
}