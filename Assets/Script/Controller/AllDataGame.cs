using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="AllData", menuName ="Data/AllData")]
public class AllDataGame : ScriptableObject
{
    //Boss
    public int MaxHpBoss;
    public int DameBoss;
    public float SpeedBoss;
    //Enemy
    public int MaxHpGoblin;
    public int DameGoblin;
    public float SpeedGoblin;
    public int GoldGoblinSpawn;
    //Zombie
    public int MaxHpZombie;
    public int DameZombie;
    public float SpeedZombie;
    public int GoldZombieSpawn;
    //Jail
    public int GoldJailSpawn;
    public int TimeSpawnEnemy;
    public int AmountTurnEnemy;

}
