using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "MissionSO", menuName = "Data/MissionSO")]
public class MissionSO : ScriptableObject
{
    public string NameMission;
    public Sprite ImageMission;
    public string Describe;
    public int RequimentSoldier;
    public int RequimentGold;
    public int TimeToComplete;
    public int TypeMission;
    public bool isComplete;
}
