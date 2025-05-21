using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class FadeSceneUI : MonoBehaviour
{
    [SerializeField] Image image;
    private float fadeDuration = 3f;

    private async void Start()
    {
        await Task.Delay(1000);
        FadeIn();
    }

    public void FadeIn()
    {
        image.gameObject.SetActive(true);
        image.color = new Color(0, 0, 0, 1); 
        image.DOFade(0, fadeDuration).SetUpdate(true).OnComplete(() => image.gameObject.SetActive(false));
    }
}
