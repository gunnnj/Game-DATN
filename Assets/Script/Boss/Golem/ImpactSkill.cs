using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactSkill : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Army")){
            other.GetComponent<IHealthDamage>().Damage(51f);
            Debug.Log("take dame player 51");
        }
    }
}
