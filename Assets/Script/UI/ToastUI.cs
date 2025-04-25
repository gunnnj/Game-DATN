using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class ToastUI : MonoBehaviour
{
    public TMP_Text textMessage;
    public float displayDuration = 2f; 
    public float fadeDuration = 0.5f;
    public static ToastUI Instance;

    void Start()
    {
        Instance = this;
        textMessage.alpha = 0;
    }
    public void DisplayToast(string message){
        textMessage.text = message;
        ShowToast();
    }
    private void ShowToast()
    {
        textMessage.DOFade(1, fadeDuration).OnComplete(() =>
        {
            DOVirtual.DelayedCall(displayDuration, () =>
            {
                textMessage.DOFade(0, fadeDuration);
            });
        });
    }
}
