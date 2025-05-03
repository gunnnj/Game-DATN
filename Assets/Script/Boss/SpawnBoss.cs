using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
    public GameObject bossPrefab;
    public void SpawnBossArc(Vector3 position){
        GameObject boss = Instantiate(bossPrefab,position, Quaternion.identity);
    }
}
