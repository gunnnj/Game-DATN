using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayMission : MonoBehaviour
{
    private RectTransform mission;

    void Awake()
    {
        mission = transform.GetComponent<RectTransform>();
    }

    void OnEnable()
    {
        TurnTab();
    }

    [ContextMenu("Turn")]
    public void TurnTab(){
        Utill.MoveUILTR(mission,1f,700f);
    }
}
