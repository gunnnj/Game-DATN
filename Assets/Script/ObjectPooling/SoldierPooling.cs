using System.Collections;
using System.Collections.Generic;
using Script.ObjectPooling;
using UnityEngine;

public class SoldierPooling : ObjectPooling
{
    public static SoldierPooling Instance;
    public override void Awake()
    {
        base.Awake();
        Instance = this;
    }

    public void GetSoldier(Vector3 position){
        GameObject soldier = this.GetPooledObject();
        soldier.transform.position = position;
        soldier.SetActive(true);
    }

}
