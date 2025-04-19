using System;
using System.Collections;
using System.Collections.Generic;
using Script.Event;
using Script.Interface;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ArmyHealthUI : MonoBehaviour
{
    public TMP_Text amoutSoldier;
    public Slider hpBar;
    public GameObject army;
    private IGetPresentHealth presentHealth;
    private int amoutSol;
    void OnEnable()
    {
        ArmyEvent.soldierDead += SetAmoutSoldier;
        PlayerEvent.addPlayer += AddSoldier;
    }

    void Start()
    {
        presentHealth = army.GetComponent<IGetPresentHealth>();
        amoutSol = ArmyPlayer.Instance.GetAmoutPlayer();
        amoutSoldier.text = "X"+amoutSol;
        
    }
    private void FixedUpdate()
    {
        hpBar.value = presentHealth.GetPresentHealth();
    }
    void OnDisable()
    {
        ArmyEvent.soldierDead -= SetAmoutSoldier;
        PlayerEvent.addPlayer -= AddSoldier;
    }
    public void SetAmoutSoldier(){
        amoutSol --;
        amoutSoldier.text = "X"+amoutSol;
    }
    private void AddSoldier(Vector3 postion)
    {
        amoutSol++;
        amoutSoldier.text = "X"+amoutSol;
    }

}
