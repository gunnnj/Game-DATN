using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemController : EnemyControl
{
    public SphereCollider sphereCollider;
    public GameObject effectImpact;
    public bool offSound;

    void Awake()
    {
        sphereCollider.enabled = false;
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

    // Event of Animation attack
    public void SpawnEffect(){
        effectImpact.SetActive(true);
        sphereCollider.enabled =true;
        if(!offSound){
            AudioManager.Instance.PlaySfx(AudioManager.SoundFXData.Earthquake);
        }
        
    }

    //Event of Animation attack end
    public void DisActiveCollier(){
        sphereCollider.enabled = false;
    }
}
    
