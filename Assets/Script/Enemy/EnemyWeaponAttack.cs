using System;
using Script.TowerDefend.HouseSO;
using UnityEngine;

public class EnemyWeaponAttack : MonoBehaviour
{
    [SerializeField] private int damage;
    public bool offSound;
    void Start()
    {
        offSound = false;
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


    protected virtual void OnTriggerEnter(Collider other)
    {
    
        if (other.CompareTag("Player") || other.CompareTag("MainHouse"))
        {

            if(other.GetComponentInParent<ArmyHealth>()!=null){
                other.GetComponentInParent<ArmyHealth>().Damage(damage);
                if(!offSound) AudioManager.Instance.PlaySfx(AudioManager.SoundFXData.Gethit);
            }
            else{
                other.GetComponentInParent<MainHouseHealth>().Damage(damage);
                if(!offSound) AudioManager.Instance.PlaySfx(AudioManager.SoundFXData.Gethit);
            }

        }

    }


}