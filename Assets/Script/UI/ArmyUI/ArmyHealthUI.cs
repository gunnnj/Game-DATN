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
    public TMP_Text hptext;
    private int amoutSol;
    private float maxHP;
    void OnEnable()
    {
        ArmyEvent.soldierDead += SetAmoutSoldier;
        PlayerEvent.addPlayer += AddSoldier;
        ArmyEvent.deceaseHealth += DeceaseHealth;
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
        UpdateHealth(ArmyHealth.Instance.currentHealth,maxHP);
    }
    void OnDisable()
    {
        ArmyEvent.soldierDead -= SetAmoutSoldier;
        PlayerEvent.addPlayer -= AddSoldier;
    }
    public void DeceaseHealth(bool value){
        if(!value){
            maxHP = 120;
        }
        else{
            maxHP = 100;
        }
    }
    public void UpdateHealth(float current, float max){
        hptext.text = current+"/"+max;
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
