using System;
using UnityEngine;

public  class EnemyMovement : MonoBehaviour
{
    [SerializeField] protected float speed;



    protected Vector3 direction = Vector3.zero;


    protected virtual void Update()
    {
        OnMove();
    }
    protected virtual void OnMove() {
        transform.position = Vector3.Lerp(transform.position,transform.position+direction*speed, Time.deltaTime);

    }

    public void SetDirection(Vector3 vector3)
    {
        
        direction = Vector3.Normalize(vector3);
        direction.y = 0f;
        if(direction!=Vector3.zero){
            Quaternion rotate = Quaternion.LookRotation(direction);
            transform.rotation = rotate;
        }
        
    }
}