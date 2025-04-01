using UnityEngine;
using UnityEngine.Serialization;


[CreateAssetMenu(fileName ="Soldier", menuName = "Data/Solider")]
public  class SoldierSO : ScriptableObject
{
    public int Health = 100;
    public int Damage = 10;
    public float LocalScale  = 1;

    public float RangeAttack = 5;

    public float SpeedAttack = 1f;

    public int Armor = 5;
    
    public float RateDodge = 5f;
}