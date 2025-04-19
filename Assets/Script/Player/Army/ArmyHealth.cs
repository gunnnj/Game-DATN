using System;
using System.Collections;
using System.Collections.Generic;
using Script.Event;
using Script.Interface;
using UnityEngine;
using UnityEngine.UI;

public class ArmyHealth : MonoBehaviour, IHealthDamage, IGetPresentHealth
{
    [SerializeField] private int totalHP;
    private float currentHealth;
    private int amoutSoldier;
    void OnEnable()
    {
        PlayerEvent.addPlayer += AddSoldier;
    }
    void Start()
    {
        amoutSoldier = ArmyPlayer.Instance.GetAmoutPlayer();
        currentHealth = totalHP;
    }
    void OnDisable()
    {
        PlayerEvent.addPlayer -= AddSoldier;
    }

    private void AddSoldier(Vector3 postion)
    {
        amoutSoldier++;
    }
    
    public void Damage(int dame)
    {
        currentHealth -= dame;
        if(currentHealth<=0){
            ArmyPlayer.Instance.SoldierDead();
            ArmyEvent.soldierDead?.Invoke();
            amoutSoldier --;
            Debug.Log(amoutSoldier);
            if(amoutSoldier==0){
                GameEvent.loseGame?.Invoke();
            }
            else{
                currentHealth = totalHP;
            }
        }
    }

    public float GetPresentHealth()
    {
        return currentHealth/totalHP;
    }
    public void SetTotalHp(){

    }
    
}
