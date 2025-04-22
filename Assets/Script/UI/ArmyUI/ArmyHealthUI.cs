using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
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
    private int amoutSol;
    private float maxHP;
    void OnEnable()
    {
        ArmyEvent.soldierDead += SetAmoutSoldier;
        PlayerEvent.addPlayer += AddSoldier;
    }

    async void Start()
    {
        amoutSol = ArmyPlayer.Instance.GetAmoutPlayer();
        amoutSoldier.text = "X"+amoutSol;
        await Task.Delay(100);
        maxHP = ArmyHealth.Instance.totalHP;
        
    }
    private void Update()
    {
        hpBar.value = ArmyHealth.Instance.currentHealth/maxHP;
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
