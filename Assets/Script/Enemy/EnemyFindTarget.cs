using UnityEngine;

public class EnemyFindTarget : MonoBehaviour
{




    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.CompareTag("Player"))
    //     {
    //         SetTargetPlayer(other);
            
    //     }
    // }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SetTargetPlayer(other);
            
        }
    }
    
    protected virtual void SetTargetPlayer(Collider other){
        GetComponentInParent<EnemyControl>().SetTarget(other.transform);
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            SetDisTargetPlayer(other);
            
        }
    }

    protected virtual void SetDisTargetPlayer(Collider other)
    {
        GetComponentInParent<EnemyControl>().SetTarget(null);
    }
}