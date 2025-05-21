using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Player"))
        {
            
            Debug.Log("Particle hit: " + other.name);
            other.GetComponentInParent<ArmyHealth>().Damage(20f);
            
        }
        
    }
    
}
