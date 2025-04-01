using Script.Interface;
using UnityEngine;
using UnityEngine.UI;

namespace Script.UI.HPUI
{
    public class HealthBarUI : MonoBehaviour
    {
        [SerializeField] private Slider mainSlider;
        [SerializeField] private Slider subSlider;

        private float speed = 5f;
        private IGetPresentHealth presentHealth;

    
    
        private void Start()
        {
            presentHealth = GetComponentInParent<IGetPresentHealth>();
        }


 
        private void FixedUpdate()
        {
            DisplayHeath();
            
        }

        private void DisplayHeath()
        {
            transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
            mainSlider.value = presentHealth.GetPresentHealth();
            if (mainSlider.value <= subSlider.value)
            {
                subSlider.value = Mathf.SmoothStep(subSlider.value, mainSlider.value, speed*Time.deltaTime);
            }
        }
    }
}