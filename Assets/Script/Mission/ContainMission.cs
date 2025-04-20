using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainMission : MonoBehaviour
{
    public List<GameObject> missions;

    void Awake()
    {
        for(int i=0; i<transform.childCount; i++){
            missions.Add(transform.GetChild(i).gameObject);
        }
    } 
    void OnEnable()
    {
        GameEvent.collectGold += SetDynamicMission;
        GameEvent.minustGold += SetDynamicMission;
    }
    void OnDisable()
    {
        GameEvent.collectGold -= SetDynamicMission;
        GameEvent.minustGold -= SetDynamicMission;
    }
    public void SetDynamicMission(){
        foreach(var item in missions){
            item.GetComponent<DetailMission>().SetDynamicDetail();
        }
    }
}
