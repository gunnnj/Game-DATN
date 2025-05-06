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

        public delegate void ManaCost();
        public static ManaCost manaCost;

        public delegate void Heal();
        public static Heal heal;

        public delegate void Drone();
        public static Drone drone;

        public delegate void DeceaseHealth(bool value);
        public static DeceaseHealth deceaseHealth;
    }
}