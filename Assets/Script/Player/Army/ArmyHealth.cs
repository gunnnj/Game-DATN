using System;
using System.Collections;
using System.Collections.Generic;
using Script.Event;
using Script.Interface;
using UnityEngine;
using UnityEngine.UI;

public class ArmyHealth : MonoBehaviour, IHealthDamage
{
    [SerializeField] public int totalHP;
    public float currentHealth;
    private int amoutSoldier;
    public static ArmyHealth Instance;
    void OnEnable()
    {
        PlayerEvent.addPlayer += AddSoldier;
    }
    void Start()
    {
        Instance = this;
        amoutSoldier = ArmyPlayer.Instance.GetAmoutPlayer();
        currentHealth = totalHP;
        StartCoroutine(RegenerateHP());
    }
    void OnDisable()
    {
        PlayerEvent.addPlayer -= AddSoldier;
    }

    private void AddSoldier(Vector3 postion)
    {
        amoutSoldier++;
    }
    
    public void Damage(float dame)
    {
        currentHealth -= dame;
        // AudioManager.Instance.PlaySfx(AudioManager.SoundFXData.Gethit);
        if(currentHealth<=0){
            ArmyPlayer.Instance.SoldierDead();
            ArmyEvent.soldierDead?.Invoke();
            amoutSoldier --;
            Debug.Log(amoutSoldier);
            if(amoutSoldier==0){
                if(!GameEvent.isLose){
                    GameEvent.loseGame?.Invoke();
                    GameEvent.isLose = true;
                    AudioManager.Instance.PlaySfx(AudioManager.SoundFXData.Losing);
                }
                
            }
            else{
                currentHealth = totalHP;
            }
        }
    }

    private IEnumerator RegenerateHP()
    {
        while (true) 
        {
            yield return new WaitForSeconds(1f); 
            if(currentHealth<100){
                currentHealth += 1; 
            }  
        }
    }

    
}
