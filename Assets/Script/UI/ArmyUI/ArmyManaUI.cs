using System;
using System.Collections;
using System.Collections.Generic;
using Script.Event;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ArmyManaUI : MonoBehaviour
{
    public Slider manaBar;
    public float maxMana = 100;
    public float ratio;

    private void Update()
    {
        ratio = ArmyMana.Instance.mana/maxMana;
        manaBar.value = ratio;
    }
}
