using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAttack : MonoBehaviour
{
    public WolfController WolfController {get; private set;}

    private void Start()
    {
        WolfController = GetComponentInParent<WolfController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
            OnAttack(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player")){
            WolfController.IsAttack = false;
        }
    }
    protected virtual void OnAttack(GameObject gameObject)
    {
        WolfController.IsAttack = true;
    }
}
