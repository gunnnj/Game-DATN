using UnityEngine;

public class SoldierData : MonoBehaviour
{

    [SerializeField] private SoldierSO data;
    public int Health {  get; private set; }
    public int Damage { get; private set; }
    public float LocalScale { get; private set; }

    public float RangeAttack { get; private set; }
    
    public float SpeedAttack { get; private set; }
    
    public int Armor  { get; private set; }
    
    public float RateDodge { get; private set; }
    
    
 

    private void Awake()
    {
        Health = data.Health;
        Damage = data.Damage;
        LocalScale = data.LocalScale;
        RangeAttack = data.RangeAttack;
        SpeedAttack = data.SpeedAttack;
        Armor = data.Armor;
        RateDodge = data.RateDodge;
      
    }


    public void SetRangeAttack(float range)
    {
        this.RangeAttack = range;
    }

    public void SetDamage(int damage)
    {
        this.Damage = damage;
    }

    public void SetSpeedAttack(float speedAttack)
    {
        this.SpeedAttack = speedAttack;
    }

}