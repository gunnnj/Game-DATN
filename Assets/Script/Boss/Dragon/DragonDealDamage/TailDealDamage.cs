


using System;

using UnityEngine;

namespace Script.Boss.Dragon 
{
    public class TailDealDamage : DealDamage
    {
     

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("Hit player");
            }
        }
    }
}