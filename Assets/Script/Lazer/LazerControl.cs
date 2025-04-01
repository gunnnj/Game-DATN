using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerControl : MonoBehaviour
{
    public Transform target; 
    private LineRenderer lineRenderer;
    private float startSize = 0.01f;
    private Coroutine coroutine;
    [SerializeField] private float timeAppear = 2f;
    [SerializeField] private float timeLoopLazer = 3f;
    [SerializeField] private float endSize = 0.2f;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2; 
        lineRenderer.enabled = false; 
    }

    void Update()
    {
        if(coroutine==null){
            coroutine = StartCoroutine(LazerBeam());
        }
    }
    public IEnumerator LazerBeam()
    {
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, transform.position); 
        lineRenderer.SetPosition(1, target.position);

        SetSizeLine(startSize);
        yield return new WaitForSeconds(timeAppear);
        CheckRaycast();
        SetSizeLine(endSize);

        yield return new WaitForSeconds(timeLoopLazer);
        lineRenderer.enabled = false;
        yield return new WaitForSeconds(timeLoopLazer);
        coroutine = null;
    }

    public void SetSizeLine(float size){
        lineRenderer.startWidth = size;
        lineRenderer.endWidth = size;
    }

    public void CheckRaycast(){
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = target.position;
        RaycastHit hit;
        if (Physics.Raycast(startPosition, (targetPosition - startPosition).normalized, out hit, Vector3.Distance(startPosition, targetPosition)))
        {
            Debug.Log("Raycast hit: " + hit.collider.name);
        }
    }
}
