using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfMagicEffect : MonoBehaviour
{
    [SerializeField] public MagicBall magicBall;
    [SerializeField] public ParticleSystem redExplodeAOE;
    [SerializeField] public ParticleSystem lazerAOE;
    [SerializeField] public ParticleSystem fireStoneAOE;
    [SerializeField] private ParticleSystem shieldMagic;
    private List<ParticleSystem> listEffect;
    private bool offSound ;
    void OnEnable()
    {
        GameEvent.winGame += OffSound;
        GameEvent.loseGame += OffSoundLose;
    }
    void OnDisable()
    {
        GameEvent.winGame -= OffSound;
        GameEvent.loseGame -= OffSoundLose;
    }

    private void OffSoundLose(int type)
    {
        offSound = true;
    }

    private void OffSound()
    {
        offSound = true;
    }

    void Start()
    {
        offSound = false;
        shieldMagic.GetComponent<SphereCollider>().enabled = false;
        listEffect = new List<ParticleSystem>();
        listEffect.Add(redExplodeAOE);
        listEffect.Add(lazerAOE);
        listEffect.Add(fireStoneAOE);
    }

    //Use for AOE effect
    public void SetTargetMagic(Transform target){
        int index = Random.Range(0,listEffect.Count);
        ParticleSystem effect = listEffect[index];
        if(target!=null){
            effect.transform.position = new Vector3(target.position.x,0f,target.position.z);
            TurnEffectAOE(effect);
            if(index==1){
                if(!offSound) AudioManager.Instance.PlaySfx(AudioManager.SoundFXData.Laser);
            }
            if(index==1){
                if(!offSound) AudioManager.Instance.PlaySfx(AudioManager.SoundFXData.Rock);
            }
            if(index == 2){
                if(!offSound) AudioManager.Instance.PlaySfx(AudioManager.SoundFXData.Rock);
            }
        }        
    }

    

    public void TurnShield(bool booleanVal){
        shieldMagic.GetComponent<SphereCollider>().enabled = booleanVal;
        shieldMagic.Play();
        if(!booleanVal) shieldMagic.gameObject.SetActive(false);
    }

    public void TurnEffectAOE(ParticleSystem effect){
        effect.Play();
    }

}
