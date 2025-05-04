using System;
using System.Threading.Tasks;
using Script.Interface;
using UnityEngine;
using UnityEngine.Serialization;

namespace Script.Enemy
{
    public class EnemyHealth : MonoBehaviour, IHealthDamage, IGetPresentHealth
    {
        public float maxHealth = 100;
        // private const string nameBossArc2 = "Golem(Clone)";
        private float currentHealth = 100;
        public bool isDead = false;

        public virtual void Start()
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

        public virtual async void Dead(){
            isDead = true;
            GetComponent<SpawnCoin>()?.Spawn();
            // if(transform.name == nameBossArc2){
            //     GameEvent.winGame?.Invoke();
            // }
            gameObject.SetActive(false);
            gameObject.transform.position = Vector3.zero;
            currentHealth = maxHealth;
            GetComponent<EnemyControl>().ResetState();
            await Task.Delay(300);
            isDead = false;
            
        }
    }
}