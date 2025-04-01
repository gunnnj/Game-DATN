using System;
using Script.Interface;
using UnityEngine;
using UnityEngine.UI;


public class DisplayHealthUI:  MonoBehaviour
{
    [SerializeField] private Slider silder;
    private IGetPresentHealth presentHealth;

    
    
    private void Start()
    {
        presentHealth = GetComponentInParent<IGetPresentHealth>();
    }


 
    private void FixedUpdate()
    {
        silder.value = presentHealth.GetPresentHealth();
    }
}
