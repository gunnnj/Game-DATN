using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Script.Boss.Dragon
{
    public class DragonMovement: MonoBehaviour
    {
        public Vector3 MoveDirection { get; set; }
        public bool IsMove { get; private set; }
        public DragonController Controller { get; private set; }

        private float speedMovement;

        private float timeRandomMovement = 0f;
        private void Start()
        {
            Controller = GetComponent<DragonController>();
            speedMovement = Controller.DragonData.speedMovement;
        }

        private void FixedUpdate()
        {
            Movement();
        }

    
        protected virtual void Movement() {

            Debug.DrawRay(transform.position,MoveDirection*speedMovement,Color.black);
            // transform.Translate(direction*Time.deltaTime*speed);
            transform.position = Vector3.Lerp(transform.position,transform.position+MoveDirection*speedMovement, Time.deltaTime);
        }

        public void SetDirection(Vector3 vector3)
        {
        
            MoveDirection = Vector3.Normalize(vector3);
            if(MoveDirection!=Vector3.zero){
                Quaternion rotate = Quaternion.LookRotation(MoveDirection);
                transform.rotation = rotate;
            }
        
        }

        public void RandomMovement()
        {
            if (timeRandomMovement < 0)
            {
                float[] ArrayIndex = {-1, -0.5f, 0.5f,1};
                Vector3 randomMovement = new Vector3(ArrayIndex[Random.Range(0, ArrayIndex.Length)], 0f, ArrayIndex[Random.Range(0, ArrayIndex.Length)]);
                
                MoveDirection = randomMovement; 
               
                SetDirection(MoveDirection);
                timeRandomMovement = 6f; 
            }
            else
            {
                timeRandomMovement -= Time.deltaTime;
            }
        }
    }
}