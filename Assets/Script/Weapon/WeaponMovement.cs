
using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UIElements;


namespace  Script.Weapon
{
    public class WeaponMovement : MonoBehaviour
    {
        public Vector3 Target { get; private set; }
        public Vector3 Start { get; private set; }
        private float timeToReachTarget = 1f;
        private Rigidbody rb;
        public void OnEnable()
        {
            rb = GetComponent<Rigidbody>();
            //transform.position =Start;
        }
        public void SetTarget(Vector3 target, Vector3 start, float time)
        {
            this.Target = target;   
            this.Start = start; 
            this.timeToReachTarget = time;
            Vector3 dir = (target - start).normalized; 
            Quaternion rot = Quaternion.LookRotation(dir);
            
            transform.rotation = rot;
            Launch();
            StartCoroutine(RotateWeaponCoroutine(dir));
            
        }

        private IEnumerator RotateWeaponCoroutine(Vector3 dir)
        {
         
            float timeToRoate = timeToReachTarget;
            while (timeToRoate > 0)
            {
                this.transform.Rotate(dir * 25);
                timeToRoate -= Time.deltaTime;
                yield return null;
                
            }

            StartCoroutine(DestroyObjectCourutine());
            
        }


        public void Launch()
        {
            Vector3 A = Start;
            Vector3 B = Target;
            float T = timeToReachTarget;
            float g = Physics.gravity.magnitude;

            Vector3 velocity = new Vector3(
                (B.x - A.x) / T,
                (B.y - A.y + 0.5f * g * T * T) / T,
                (B.z - A.z) / T
            );

            rb.velocity = velocity;
        }
        
        
        public IEnumerator DestroyObjectCourutine()
        {
            yield return new WaitForSeconds(0.2f);
            this.gameObject.SetActive(false);   
        }

      
    }
}
