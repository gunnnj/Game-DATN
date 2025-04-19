using System;
using UnityEngine;

public class EnemyWeaponAttack : MonoBehaviour
{
    [SerializeField] private int damage;

    // [SerializeField] private float timeDealDamge = 1f;
    // [SerializeField] private float _timeDealDame = 1f;

    // private bool canAttack => _timeDealDame <= 0;




    // private void Update()
    // {
    //     DecreaseTimeAttack();
    // }

    // private void DecreaseTimeAttack()
    // {
       
    //     if(_timeDealDame > 0)
    //     {
    //         _timeDealDame -= Time.deltaTime;
    //     }
    // }


    protected virtual void OnTriggerEnter(Collider other)
    {
    
        if (other.CompareTag("Player") || other.CompareTag("MainHouse"))
        {
            other.GetComponentInParent<ArmyHealth>().Damage(damage);

        }

    }


}