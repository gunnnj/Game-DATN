using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MagicBall : MonoBehaviour
{
    public Transform owner;
    public Transform target;
    public float speed = 5f;
    public ParticleSystem particle;
    private bool isMoving = false;
    
    public void Update()
    {
        if(isMoving){
            transform.position = Vector3.Lerp(transform.position,target.position,5f*Time.deltaTime);
            float distance = Vector3.Distance(transform.position, target.position);
            if(distance<0.2f){
                particle.transform.position = transform.position;
                particle.gameObject.SetActive(true);
                this.gameObject.SetActive(false);
                isMoving = false;
            }
        }
        
    }
    public void SpawnAndAttackMagicBall(){
        particle.gameObject.SetActive(false);
        this.gameObject.SetActive(true);
        transform.position = owner.position;

        transform.localScale = Vector3.one * 0.1f;
        Sequence sequence = DOTween.Sequence();

        sequence.Append(transform.DOScale(Vector3.one, .5f)
            .SetEase(Ease.OutBounce)) 
            .Join(transform.DOMoveY(5f, 1f) 
            .SetEase(Ease.OutQuad)); 
    }
    public void SetFireMagic(){
        if(target == null){
            this.gameObject.SetActive(false);
        }
        else{
            isMoving = true;
        }
        
    }
    
}
