using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainHouseHealth :MonoBehaviour, IHealthDamage
{
    public float HPMax;
    public float currentHp;
    public HouseHealthUI houseHealthUI;

    void Start()
    {
        currentHp = HPMax;
        houseHealthUI = FindFirstObjectByType<HouseHealthUI>();
    }
    public void Damage(float dame)
    {
        currentHp -= dame;
        GameEvent.updateHealthHouse?.Invoke(currentHp/HPMax);
        if(currentHp<=0){
            Debug.Log("Lose destroyed mainhouse");
            GameEvent.loseGame?.Invoke();
        } 
    }


}
