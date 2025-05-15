using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCameraUI : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (mainCamera != null)
        {
            transform.LookAt(mainCamera.transform);
            // Đảo ngược trục Y để UI không bị lộn ngược
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        }
    }
}
