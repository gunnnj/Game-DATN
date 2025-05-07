using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class RangeAttackUI : MonoBehaviour
{
    public Transform army;
    public Transform mainHouse;
    public GameObject arrow;
    Vector3 target;
    private bool isTargetHouse;

    void Start()
    {
        isTargetHouse = false;
        target = mainHouse.position;
    }
    void Update()
    {
        transform.position = army.position;
        RotationTarget(target);
    }

    public void RotationTarget(Vector3 position){
        Vector3 dir = (position-transform.position).normalized;
        dir.y=0;
        transform.rotation = Quaternion.LookRotation(dir);
    }
    public void SetTarget(Vector3 position){
        arrow.SetActive(true);
        if(!isTargetHouse){
            target = position;
        }
    }
    public async void SetOriginTarget(){
        arrow.SetActive(true);
        target = mainHouse.position;
        isTargetHouse = true;
        await Task.Delay(10000);
        isTargetHouse = false;

    }
    public void DisActiveArrow(){
        arrow.SetActive(false);
    }
}
