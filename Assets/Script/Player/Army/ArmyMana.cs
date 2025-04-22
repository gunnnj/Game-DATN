using System;
using System.Collections;
using System.Collections.Generic;
using Script.Event;
using UnityEngine;

public class ArmyMana : MonoBehaviour
{
    public int mana = 100;
    public static ArmyMana Instance;
    void OnEnable()
    {
        ArmyEvent.manaCost += UpdateMana;
    }
    void Start()
    {
        Instance = this;
        StartCoroutine(RegenerateMana());
    }


    private void UpdateMana()
    {
        mana -= 3;
    }

    private IEnumerator RegenerateMana()
    {
        while (true) 
        {
            yield return new WaitForSeconds(1f); 
            if(mana<100){
                mana += 1; 
            }  
        }
    }
}
