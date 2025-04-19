using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManage : MonoBehaviour
{
    public int gold;
    public EnemyPoolingManager enemyPool;
    public static GameManage Instance;
    void OnEnable()
    {
        GameEvent.collectGold+= AddGold;
    }

    void Start()
    {
        Instance = this;
        gold = 0;
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

    [ContextMenu("Minus")]
    public void Minus(){
        MinusGold(2);
    }

}
