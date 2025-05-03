using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class GameManage : MonoBehaviour
{
    public int gold = 0;
    public EnemyPoolingManager enemyPool;
    public CinemachineVirtualCamera CamPlayer;
    public CinemachineVirtualCamera CamRest;
    public Transform army;
    public static GameManage Instance;

    void Awake()
    {
        Instance = this;
        gold = 0;
    }
    void OnEnable()
    {
        GameEvent.collectGold+= AddGold;
        GameEvent.completeBuildHouse += SpawnEnemy;
    }
    public int GetGold(){
        return gold;
    }
    public void AddGold(){
        gold++;
    }
    public void MinusGold(int gold){
        if(this.gold<gold){
            Debug.Log("Not enough gold");
        }
        else{
            this.gold -= gold;
            GameEvent.minustGold?.Invoke();
        }
    }
    private void SpawnEnemy()
    {
        Debug.Log("complete house");
        StartCoroutine(SpawnEnemyByTime());
    }

    public IEnumerator SpawnEnemyByTime(){
        yield return new WaitForSeconds(5f);
        ToastUI.Instance.DisplayToast("Quái vật xuất hiện sau 30 giây!");
        yield return new WaitForSeconds(10f);
        enemyPool.StartSpawn();
        yield return new WaitForSeconds(0f);
    }

    public void SwithCamera(bool value){
        if(value){
            CamPlayer.Priority=0;
            CamRest.Priority = 10;
            ArmyHide(true);
            ArmyMana.Instance.RecoveryMana();
        }
        else{
            // ToastUI.Instance.DisplayToast("Hồi đầy thể lực!");
            CamPlayer.Priority=10;
            CamRest.Priority = 0;
            ArmyHide(false);
            ArmyMana.Instance.BasicRecoveryMana();
        }
    }

    public void ArmyHide(bool value){
        for(int i =0; i<army.childCount; i++){
            army.GetChild(i).gameObject.SetActive(!value);
        }
    }

}
