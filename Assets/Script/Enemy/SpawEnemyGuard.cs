using System.Collections;
using System.Collections.Generic;
using Script.TowerDefend.HouseSO;
using UnityEngine;

public class SpawEnemyGuard : MonoBehaviour
{
    private int amountSoldier;
    void Start()
    {
        amountSoldier = GetComponentInParent<HouseData>().AmountSolider;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log("trigger");
        if(other.CompareTag("Player")){
            Debug.Log("SpawnEnemy");
            Spawn();
        }
    }
    private void Spawn(){
        int amoutEnemyGuard = 0;
        if(amountSoldier==5){
            amoutEnemyGuard = 3;
        }
        else if (amountSoldier==3){
            amoutEnemyGuard = 2;
            Debug.Log("Enemy :"+amoutEnemyGuard);
        }
        else{
            amoutEnemyGuard = 1;
        }
        for(int i=0; i<amoutEnemyGuard;i++){
            EnemyPooling.Instance.SetPositionEnemy(transform.position + new Vector3((i+1),0f,2f));
        }
    }

    
}
