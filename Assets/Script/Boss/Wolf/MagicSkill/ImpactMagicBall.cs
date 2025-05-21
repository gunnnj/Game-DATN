using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactMagicBall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // if(other.CompareTag("Player")){
        //     Debug.Log("Dame to player");
        // }
        if(other.CompareTag("Army")){
            other.GetComponent<IHealthDamage>().Damage(20f);
            Debug.Log("Take dame player 55");
        }
        else if(other.CompareTag("MainHouse")){
            other.GetComponent<IHealthDamage>().Damage(15f);
            Debug.Log("Take dame mainhouse 20");
        }
    }
}
