using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoolingManager : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        // int amount = 10;
        // while(amount>0){        
            EnemyPooling.Instance.SetPositionEnemy(transform.position);
            yield return new WaitForSeconds(2f);
            EnemyPooling.Instance.SetPositionEnemy(transform.position);
        //     amount--;
        // }
        
    }
}
