using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfMovement : MonoBehaviour
{
    public Vector3 MoveDirection { get; set; }
    public WolfController Controller { get; private set; }
    private float speedMovement = 3f;

    void Start()
    {
        Controller = GetComponent<WolfController>();
        // speedMovement = Controller.WolfData.speedMovement;
    }
    public void FixedUpdate()
    {
        Movement();
    }
    public void Movement() 
    {
        MoveDirection = new Vector3(MoveDirection.x,0,MoveDirection.z);
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
}
