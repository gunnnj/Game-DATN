using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public Transform legR;
    public Transform legL; 
    public float speed = 2f; 

    void Update()
    {
        Vector3 midpoint = (legR.position + legL.position) / 2;

        transform.position = Vector3.MoveTowards(transform.position, midpoint, speed * Time.deltaTime);

    }
}
