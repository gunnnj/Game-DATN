using UnityEngine;

public class LoadDataGame: MonoBehaviour
{
    [SerializeField] AllDataGame allDataGame;
    public int GetMaxHpBoss() => allDataGame.MaxHpBoss;
    public int GetDameBoss() => allDataGame.DameBoss;
    public float GetSpeedBoss() => allDataGame.SpeedBoss;
    public int GetMaxHpGoblin() => allDataGame.MaxHpGoblin;
    public int GetDameGoblin() => allDataGame.DameGoblin;
    public int GetGoldGoblinSpawn() => allDataGame.GoldGoblinSpawn;
    public int GetMaxHpZombie() => allDataGame.MaxHpZombie;
    public int GetDameZombie() => allDataGame.DameZombie;
    public float GetSpeedZombie() => allDataGame.SpeedZombie;
    public int GetGoldZombieSpawn() => allDataGame.GoldZombieSpawn;
    public int GetGoldJailSpawn() => allDataGame.GoldJailSpawn;


    public static LoadDataGame Instance;
    void Awake()
    {
        Instance = this;
    }
    

}
