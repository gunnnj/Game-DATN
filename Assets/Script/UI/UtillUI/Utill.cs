using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Utill
{
    public static void MoveUILTR(RectTransform rectTransform, float duration, float distance){
        Vector3 origin = rectTransform.anchoredPosition;
        Vector3 start = new Vector3(origin.x+ distance, origin.y, origin.z);
        rectTransform.anchoredPosition = start;
        var sequence = DOTween.Sequence();
        sequence.Append(rectTransform.DOAnchorPos(origin,duration));

    }
}
