using System;
using System.Collections;
using System.Collections.Generic;
using Script.Event;
using UnityEngine;

public class ArmyMana : MonoBehaviour
{
    public int mana = 100;
    public int manaCost = 5;
    private Coroutine coroutine;
    public static ArmyMana Instance;
    void OnEnable()
    {
        ArmyEvent.manaCost += UpdateMana;
    }
    void Start()
    {
        Instance = this;
        StartCoroutine(RegenerateMana(1));
    }

    public void BasicRecoveryMana(){
        StartCoroutine(RegenerateMana(1));
    }
    private void UpdateMana()
    {
        if(mana>0){
            mana -= manaCost;
            if(mana<=0){
                mana = 0;
            }
        }   
    }

    private IEnumerator RegenerateMana(int value)
    {
        while (true) 
        {
            yield return new WaitForSeconds(1f); 
            if(mana<100){
                mana += value;
                if(mana>1000){
                    mana = 100;
                } 
            }
            else{
                GameManage.Instance.SwithCamera(false);
                StopCoroutine(coroutine);
            }  
        }
    }

    public void RecoveryMana(){
        coroutine = StartCoroutine(RegenerateMana(10));
    }
}
