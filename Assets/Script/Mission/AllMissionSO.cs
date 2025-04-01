using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="AllMission", menuName = "Data/AllMission")]
public class AllMissionSO : ScriptableObject
{
    public MissionSO[] missionSOs;
    public int currentMission;
}
