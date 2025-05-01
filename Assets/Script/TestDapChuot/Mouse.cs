using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    public bool isUp;

    public void Move(){
        isUp = !isUp;
        if(!isUp){
            transform.DOMoveY(-0.2f,0.1f).SetEase(Ease.Linear);
        }
        else{
            transform.DOMoveY(-1f,0.1f).SetEase(Ease.Linear);
        }
    }
}
