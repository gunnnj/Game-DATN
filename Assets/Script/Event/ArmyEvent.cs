using Script.Player.Army;
using UnityEngine;

namespace Script.Event
{
    public class ArmyEvent
    {
        public delegate void ChangeLineUp(LineUp lineUp);
        public static ChangeLineUp ChangeLineUpArmy;

        public delegate void TargetEnemy(Transform target);
        public static TargetEnemy targetEnemy; 

        public delegate void SoldierDead();
        public static SoldierDead soldierDead; 

        // public delegate void AddSoldier();
        // public static AddSoldier addSoldier;
    }
}