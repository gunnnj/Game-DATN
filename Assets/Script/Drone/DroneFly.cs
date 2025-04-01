using UnityEngine;

public class DroneFly : MonoBehaviour
{
    public Transform ownerPos;
    public float height = 10f;
    public float radius = 2f;
    public float speed = 5f;
    private DroneFire droneFire;
    private float acceleration = 2f; // Gia tốc
    private float turnSpeed = 2f; 
    private float wobbleAmount = 0.3f;
    private float wobbleSpeed = 1f; // Tốc độ lắc lư
    private float tiltAmount = 5f;
    private Vector3 standardPos;
    private float currentSpeed;

    void Start()
    {
        droneFire = GetComponent<DroneFire>();
        standardPos = new Vector3(ownerPos.position.x, height, ownerPos.position.z);
        transform.position = standardPos;
        currentSpeed = 0f; 
    }

    void Update()
    {
        standardPos = new Vector3(ownerPos.position.x, height, ownerPos.position.z);
        float distance = Vector3.Distance(transform.position, standardPos);

        if (distance > 1f)
        {
            FlyToTarget();
        }
        else{
            if(!droneFire.canFire){
                Wobble();
            }        
        }
    }

    void FlyToTarget()
    {
        // Tính toán gia tốc
        if (currentSpeed < speed)
        {
            currentSpeed += acceleration * Time.deltaTime; 
        }

        Vector3 direction = (standardPos - transform.position).normalized;

        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, turnSpeed * Time.deltaTime);

        transform.position = Vector3.MoveTowards(transform.position, standardPos, currentSpeed * Time.deltaTime);
    }
    public void Wobble()
    {
        // Lắc lư & xoay
        float wobbleY = Mathf.Sin(Time.time * wobbleSpeed) * wobbleAmount; 
        transform.position = new Vector3(transform.position.x, standardPos.y + wobbleY, transform.position.z);

        float tilt = Mathf.Sin(Time.time * wobbleSpeed) * tiltAmount; 
        transform.rotation = Quaternion.Euler(tilt, transform.rotation.eulerAngles.y, 0); 
    
    }

}