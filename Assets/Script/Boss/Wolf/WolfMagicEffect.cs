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

    void Start()
    {
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
        }        
    }

    

    public void TurnShield(bool booleanVal){
        shieldMagic.GetComponent<SphereCollider>().enabled = booleanVal;
        shieldMagic.Play();
    }

    public void TurnEffectAOE(ParticleSystem effect){
        effect.Play();
    }

}
