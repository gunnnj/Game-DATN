using System;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]protected float damage;

    private void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("Player") || other.CompareTag("MainHouse")) && GetComponentInParent<EnemyControl>().Target == other.transform)
        {
           
            OnAttack(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ((other.CompareTag("Player") || other.CompareTag("MainHouse")) && GetComponentInParent<EnemyControl>().Target == other.transform)
        {
            GetComponentInParent<EnemyControl>().isAttack = false;


        }
    }

    protected virtual void OnAttack(GameObject gameObject)
    {
        GetComponentInParent<EnemyControl>().isAttack = true;
    }
}


