
using UnityEngine;

namespace Script.Bullet
{
    public class BulletMovement : MonoBehaviour
    {
        public Vector3 StartPosition { get; private set; }
        public Vector3 EndPosition { get; private set; }

        private Vector3 directionMovement;

        private float speedMovement;


        private void FixedUpdate()
        {
            this.transform.position += (this.directionMovement * this.speedMovement*Time.deltaTime);
        }

        public void SetMovement(Vector3 start, Vector3 end, float speed)
        {
            transform.position = start;
            this.StartPosition = start;
            this.EndPosition = end;
            
            directionMovement = (end - start).normalized;
            Quaternion rotation = Quaternion.LookRotation(directionMovement);
            transform.rotation = rotation;
            speedMovement = speed;
        }
        
        
    }
}