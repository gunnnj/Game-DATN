using System;
using UnityEngine;

public class EnemyWeaponAttack : MonoBehaviour
{


    [SerializeField] private float timeDealDamge = 1f;
    [SerializeField] private float _timeDealDame = 1f;

    private bool canAttack => _timeDealDame <= 0;




    private void Update()
    {
        DecreaseTimeAttack();
    }

    private void DecreaseTimeAttack()
    {
       
        if(_timeDealDame > 0)
        {
            _timeDealDame -= Time.deltaTime;
        }
    }


    protected virtual void OnTriggerStay(Collider other)
    {
    
        if (other.CompareTag("Player") && canAttack)
        {
         
            _timeDealDame = timeDealDamge;
        }
    }


}