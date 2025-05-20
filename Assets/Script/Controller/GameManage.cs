using System;
using System.Collections;
using System.Linq;
using Cinemachine;
using UnityEngine;

public class GameManage : MonoBehaviour
{
    public int gold = 0;
    public EnemyPoolingManager enemyPool;
    public CinemachineVirtualCamera CamPlayer;
    public CinemachineVirtualCamera CamRest;
    public Transform army;
    public float timeSpawnEnemy = 20f;
    public AllMissionSO allMissionSO;
    public bool offSound;

    private RangeAttackUI rangeAttackUI;
    public static GameManage Instance;


    void Awake()
    {
        Instance = this;
        offSound = false;
        rangeAttackUI = FindFirstObjectByType<RangeAttackUI>();
        gold = 0;
        ResetAllMission();
    }
    void OnEnable()
    {
        GameEvent.collectGold+= AddGold;
        GameEvent.completeBuildHouse += SpawnEnemy;
        GameEvent.loseGame += OffSoundLose;
        GameEvent.winGame += OffSoundWin;
    }

    private void OffSoundWin()
    {
        offSound = true;
    }

    private void OffSoundLose(int type)
    {
        offSound = true;
    }

    void OnDisable()
    {
        GameEvent.loseGame -= OffSoundLose;
        GameEvent.winGame -= OffSoundWin;
    }
    public void ResetAllMission(){
        for(int i =0; i<allMissionSO.missionSOs.Count(); i++){
            allMissionSO.missionSOs[i].isComplete = false;
        }
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
        ToastUI.Instance.DisplayToast($"Quái vật xuất hiện tấn công sau {timeSpawnEnemy} giây!");
        yield return new WaitForSeconds(timeSpawnEnemy);
        rangeAttackUI.SetOriginTarget();
        if(!offSound) AudioManager.Instance.PlaySfx(AudioManager.SoundFXData.Warning);
        enemyPool.StartSpawn();
        yield return new WaitForSeconds(timeSpawnEnemy);
        ToastUI.Instance.DisplayToast($"Quái vật xuất hiện tấn công sau {timeSpawnEnemy} giây!");
        yield return new WaitForSeconds(timeSpawnEnemy);
        if(!offSound) AudioManager.Instance.PlaySfx(AudioManager.SoundFXData.Warning);
        rangeAttackUI.SetOriginTarget();
        enemyPool.StartSpawn();
        yield return new WaitForSeconds(timeSpawnEnemy);
        ToastUI.Instance.DisplayToast($"Quái vật xuất hiện tấn công sau {timeSpawnEnemy} giây!");
        yield return new WaitForSeconds(timeSpawnEnemy);
        if(!offSound) AudioManager.Instance.PlaySfx(AudioManager.SoundFXData.Warning);
        rangeAttackUI.SetOriginTarget();
        enemyPool.StartSpawn();
        yield return new WaitForSeconds(timeSpawnEnemy);
        ToastUI.Instance.DisplayToast($"Trùm cuối xuất hiện tấn công sau {timeSpawnEnemy} giây!");
        yield return new WaitForSeconds(timeSpawnEnemy);
        if(!offSound) AudioManager.Instance.PlaySfx(AudioManager.SoundFXData.Warning);
        rangeAttackUI.SetOriginTarget();
        enemyPool.SpawnBoss();
        yield return new WaitForSeconds(0f);
    }

    public void SwithCamera(bool value){
        if(value){
            CamPlayer.Priority=0;
            CamRest.Priority = 10;
            ArmyHide(true);
            // ArmyMana.Instance.RecoveryMana();
        }
        else{
            // ToastUI.Instance.DisplayToast("Hồi đầy thể lực!");
            CamPlayer.Priority=10;
            CamRest.Priority = 0;
            ArmyHide(false);
            // ArmyMana.Instance.BasicRecoveryMana();
        }
    }

    public void ArmyHide(bool value){
        for(int i =0; i<army.childCount; i++){
            army.GetChild(i).gameObject.SetActive(!value);
        }
    }

}
