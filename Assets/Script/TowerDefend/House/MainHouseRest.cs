using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainHouseRest : MonoBehaviour
{
    public LayerMask targetLayer; 
    void Update()
    {
        // Kiểm tra sự kiện nhấn chuột hoặc cảm ứng
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Ray ray;
            if (Input.touchCount > 0)
            {
                // Xử lý trên thiết bị di động
                ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            }
            else
            {
                // Xử lý trên máy tính
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            }

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, targetLayer))
            {
                if (hit.transform != null)
                {
                    Debug.Log("Clicked on: " + hit.transform.name);
                    GameManage.Instance.SwithCamera(true);
                }

            }
        }
    }
}
