using System.Collections;
using System.Collections.Generic;
using Script.ObjectPooling;
using UnityEngine;

public class EnemyPooling : ObjectPooling
{


    public override void Awake()
    {
        base.Awake();
    }
    public void SetPositionEnemy(Vector3 pos){
        GameObject enemy = GetPooledObject();
        enemy.transform.position = pos;
        enemy.SetActive(true);
    }

}
