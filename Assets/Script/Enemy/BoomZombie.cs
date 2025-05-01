using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomZombie : MonoBehaviour
{
    private SphereCollider sphereCollider;
    void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Army")){
            other.GetComponent<IHealthDamage>().Damage(10f);
            Debug.Log("Exploser");
            sphereCollider.enabled = false;
        }
    }
}
