using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Enemy"))
        {
            
            Debug.Log("Particle hit: " + other.name);
            
        }
        if (other.CompareTag("Player"))
        {
            
            Debug.Log("Particle hit: " + other.name);
            
        }
    }
}
