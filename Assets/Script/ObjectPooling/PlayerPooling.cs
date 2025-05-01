using System.Collections;
using System.Collections.Generic;
using Script.ObjectPooling;
using UnityEngine;

public class PlayerPooling : ObjectPooling
{
    public static PlayerPooling Instance;
    public override void Awake()
    {
        base.Awake();
        Instance = this;
    }

    public GameObject GetPlayer(Vector3 position, Transform parrent){
        GameObject soldier = GetPooledObject();
        if(soldier==null){
            soldier = Instantiate(objectToPool, position, Quaternion.identity);
        }
        soldier.transform.position = position;
        soldier.transform.SetParent(parrent);
        soldier.SetActive(true);
        return soldier;
    }
}
