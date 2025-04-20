using System;
using Script.Interface;
using UnityEngine;
using UnityEngine.Serialization;

namespace Script.Enemy
{
    public class EnemyHealth : MonoBehaviour, IHealthDamage, IGetPresentHealth
    {
        [SerializeField]private float maxHealth = 100;
        private float currentHealth = 100;

        private void Start()
        {
            currentHealth = maxHealth;
        }

        public void Damage(float dame)
        {
            currentHealth  = currentHealth >= dame ? currentHealth-dame: 0;
           
           
            if (currentHealth == 0)
            {
                Dead();
            }
        }

        public float GetPresentHealth()
        {
            return (float) currentHealth / maxHealth;
        }

        public void Dead(){
            GetComponent<SpawnCoin>().Spawn();
            gameObject.SetActive(false);
        }
    }
}