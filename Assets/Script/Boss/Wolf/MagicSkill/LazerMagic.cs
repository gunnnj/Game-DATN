using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerMagic : MonoBehaviour
{
    private float timeDealDamage = 1f;

    private void FixedUpdate()
    {
        if (timeDealDamage > 0)
        {
            timeDealDamage -= Time.deltaTime;
        }

        if(this.GetComponent<ParticleSystem>().isPlaying){
            GetComponent<CapsuleCollider>().enabled =  true;
        }
        else{
            GetComponent<CapsuleCollider>().enabled =  false;
        }
    }


    void OnTriggerStay(Collider other)
    {
        if (timeDealDamage <= 0 && other.CompareTag("Player"))
        {
            Debug.Log("Dealing damage lazer");
            timeDealDamage = 1f;
        }
    }
}
