using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class DroneFire : MonoBehaviour
{
    public float damage = 10f;
    public float rangeAttack = 25f;
    public float fireRate = 1f;
    public bool canFire = false;
    public ParticleSystem muzzleFlash;

    public void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Enemy")){
            canFire=true;
            AimAndFire(other.transform);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Enemy")){
            canFire=false;
            AimAndFire(null);
        }
    }

    private void AimAndFire(Transform target)
    {
        if (canFire)
        {
            if (target != null)
            {
                RotateToTarget(target);
                muzzleFlash.gameObject.SetActive(true);
            }
        }
        else{
            
            muzzleFlash.gameObject.SetActive(false);
            
        }
    }

    public void RotateToTarget(Transform target){

        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 360f * Time.deltaTime);

    }
}
