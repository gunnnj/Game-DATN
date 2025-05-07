using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Script.TowerDefend.HouseSO;
using UnityEngine;

public class SpawEnemyGuard : MonoBehaviour
{
    public int amoutEnemyGuard;
    private bool isSpawn = false;
    private RangeAttackUI rangeAttackUI;
    public EnemyPooling enemyPooling;

    async void Start()
    {
        rangeAttackUI = FindFirstObjectByType<RangeAttackUI>();
        await Task.Delay(1000);
        enemyPooling = EnemyPoolingManager.Instance.enemyPoolings[0];
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Army")){
            Spawn();
        }
    }
    public async void Spawn(){
        rangeAttackUI.SetTarget(transform.position);
        if(!isSpawn){
            for(int i=0; i<amoutEnemyGuard;i++){
                enemyPooling.SetPositionEnemy(transform.position + new Vector3(2f,0f,2f));
            }
            isSpawn = true;
        }
        await Task.Delay(2000);
        rangeAttackUI.DisActiveArrow();
        
    }

    
}
