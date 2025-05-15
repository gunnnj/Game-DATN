using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GoldUI : MonoBehaviour
{
    private RectTransform rectTransform;
    public Vector3 scale;
    void OnEnable()
    {
        GameEvent.collectGold += EffectGold;
    }
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void EffectGold()
    {
        rectTransform.DOScale(scale * 1.5f, 0.2f)
            .OnComplete(() => rectTransform.DOScale(scale, 0.2f));
    }
}
