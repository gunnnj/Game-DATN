using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class HouseHealthUI : MonoBehaviour
{
    public Slider hpBar;
    public GameObject warning;
    private float Ratio;

    void Start()
    {
        warning.SetActive(false);
        Ratio = 1;
        GameEvent.updateHealthHouse+=UpdateHealthBar;
    }

    private async void UpdateHealthBar(float ratio)
    {
        Ratio = ratio;
        warning.SetActive(true);
        await Task.Delay(3000);
        warning.SetActive(false);
    }
    void  Update()
    {
        hpBar.value = Ratio;
    }
}
