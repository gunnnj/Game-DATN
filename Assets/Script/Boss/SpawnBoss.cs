using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
    public GameObject bossPrefab;
    public Transform pos;
    public void SpawnBossArc(){
        if(pos!=null){
            bossPrefab.transform.position = pos.position;
        }
        bossPrefab.SetActive(true);
        
    }
}
