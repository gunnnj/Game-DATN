using System;
using UnityEngine;

namespace Script.Boss.Dragon
{
    public class BreathDealDamge : DealDamage
    {
        private float timeDealDamage = 0f;

        private void FixedUpdate()
        {
            if (timeDealDamage > 0)
            {
                timeDealDamage -= Time.deltaTime;
            }
        }

        private void OnParticleCollision(GameObject other)
        {
            if (timeDealDamage <= 0 && other.CompareTag("Player"))
            {
                Debug.Log("Dealing damage");
                timeDealDamage = 0.2f;
            }
        }

        // private void OnParticleCollision()
        // {

        // }
    }
}