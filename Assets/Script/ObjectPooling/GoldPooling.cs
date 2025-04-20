using System.Collections;
using System.Collections.Generic;
using Script.ObjectPooling;
using UnityEngine;

public class GoldPooling : ObjectPooling
{
    public static GoldPooling Instance;
    void Start()
    {
        Instance = this;
    }
    public void SetPositionGold(Vector3 position){
        float random = Random.Range(1,5);
        GameObject coin = GetPooledObject();
        coin.transform.position = position + new Vector3(random,0.2f,random);
        coin.SetActive(true);
    }
}
