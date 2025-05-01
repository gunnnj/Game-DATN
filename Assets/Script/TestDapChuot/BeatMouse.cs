using UnityEngine;

public class BeatMouse : MonoBehaviour
{
    public LayerMask targetLayer; 
    public LayerMask blockLayer;
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Ray ray;
            if (Input.touchCount > 0)
            {
                ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            }
            else
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            }

            RaycastHit hit;

            LayerMask combinedLayerMask = targetLayer | blockLayer;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, combinedLayerMask))
            {
                // if (hit.transform != null)
                // {
                //     Debug.Log("Clicked on: " + hit.transform.name);
                //     hit.transform.GetComponent<Mouse>().Move();
                // }
                if (((1 << hit.collider.gameObject.layer) & blockLayer) != 0)
                {
                    Debug.Log("a");
                    return;
                }
                if (((1 << hit.collider.gameObject.layer) & targetLayer) != 0)
                {
                    Debug.Log("Clicked on: " + hit.transform.name);
                    hit.transform.GetComponent<Mouse>().Move();
                }
            }
            
            // if (Physics.Raycast(ray, out hit, Mathf.Infinity, blockLayer))
            // {
            //     Debug.Log("a");
            //     return;
            // }

            
        }
    }
}
