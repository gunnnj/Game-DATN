using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
    public GameObject bossPrefab;
    public void SpawnBossArc(){
        GameObject boss = Instantiate(bossPrefab,transform.position, Quaternion.identity);
    }
}
