using System.Collections;
using System.Collections.Generic;
using Script.ObjectPooling;
using UnityEngine;

public class EnemyPooling : ObjectPooling
{
    public static EnemyPooling Instance;
    // public int amountTurnEnemy = 10;

    public override void Awake()
    {
        base.Awake();
        Instance = this;
    }
    public void SetPositionEnemy(Vector3 pos){
        GameObject enemy = GetPooledObject();
        enemy.transform.position = pos;
    }
    public void SetEnemyObject(GameObject enemyObject)
    {
        SetObjectPool(enemyObject);
    }
}
