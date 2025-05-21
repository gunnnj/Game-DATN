using System.Collections;
using System.Collections.Generic;
using Script.Weapon;
using Unity.VisualScripting;
using UnityEngine;

public class MagicShield : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<WeaponDealDamage>()!=null){
            other.gameObject.SetActive(false);
        }
    }
}
