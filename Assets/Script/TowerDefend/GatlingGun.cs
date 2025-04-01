using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatlingGun : MonoBehaviour
{
    // GameObjects to control rotation and aiming
    public Transform go_baseRotation;
    public Transform go_GunBody;
    public Transform go_barrel;

    // Gun barrel rotation
    public float barrelRotationSpeed;
    public float rangeAttack = 10f;
    private float currentRotationSpeed;

    // Particle system for the muzzle flash
    public ParticleSystem muzzleFlash;

    // Used to start and stop the turret firing
    public bool canFire = false;

    void Update()
    {

        Collider[] hits = Physics.OverlapSphere(transform.position, rangeAttack);

        foreach (var hit in hits)
        {
            if (hit.CompareTag("Enemy"))
            {
                float distance = Vector3.Distance(transform.position, hit.transform.position);
                canFire = distance<rangeAttack;
                AimAndFire(hit.transform);
            }
        }

        
    }
    
    void AimAndFire(Transform target)
    {
        // Gun barrel rotation
        go_barrel.transform.Rotate(0, 0, currentRotationSpeed * Time.deltaTime);

        if (canFire)
        {
            // Start rotation
            currentRotationSpeed = barrelRotationSpeed;

            // Aim at enemy
            if (target != null)
            {
                Vector3 baseTargetPosition = new Vector3(target.position.x, transform.position.y, target.position.z);
                Vector3 gunBodyTargetPosition = target.position;

                go_baseRotation.LookAt(baseTargetPosition);
                go_GunBody.LookAt(gunBodyTargetPosition);

                // Start particle system 
                if (!muzzleFlash.isPlaying)
                {
                    muzzleFlash.Play();
                }
            }
        }
        else
        {
            // Slow down barrel rotation and stop
            currentRotationSpeed = Mathf.Lerp(currentRotationSpeed, 0, 10 * Time.deltaTime);

            // Stop the particle system
            if (muzzleFlash.isPlaying)
            {
                muzzleFlash.Stop();
            }
        }
    }
}