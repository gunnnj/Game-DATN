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
        protected float currentHealth = 100;
        public bool isDead = false;
        public bool offSound;
        void Awake()
        {
            
            offSound = false;
        }
        

        public virtual void Start()
        {
            currentHealth = maxHealth;
        }
        void OnEnable()
        {
            GameEvent.loseGame += OffSoundLose;
            GameEvent.winGame += OffSoundWin;
        }
        void OnDisable()
        {
            GameEvent.loseGame -= OffSoundLose;
            GameEvent.winGame -= OffSoundWin;
        }
        public void OffSoundLose(int type){
            offSound = true;
        }
        public void OffSoundWin(){
            offSound = true;
        }

        public void Damage(float dame)
        {
            if(!offSound) AudioManager.Instance.PlaySfx(AudioManager.SoundFXData.Slash);
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
            gameObject.SetActive(false);
            gameObject.transform.position = Vector3.zero;
            currentHealth = maxHealth;
            GetComponent<EnemyControl>()?.ResetState();
            await Task.Delay(300);
            isDead = false;
            
        }
    }
}