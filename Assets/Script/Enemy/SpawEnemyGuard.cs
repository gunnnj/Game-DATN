using System.Collections;
using System.Collections.Generic;
using Script.TowerDefend.HouseSO;
using UnityEngine;

public class SpawEnemyGuard : MonoBehaviour
{
    public int amoutEnemyGuard;

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Army")){
            Spawn();
        }
    }
    public void Spawn(){
        for(int i=0; i<amoutEnemyGuard;i++){
            EnemyPooling.Instance.SetPositionEnemy(transform.position + new Vector3(2f,0f,2f));
        }
    }

    
}
