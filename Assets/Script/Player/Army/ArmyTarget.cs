using Script.Event;
using UnityEngine;

public class ArmyTarget : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Enemy") && other.transform!=null){
            ArmyEvent.targetEnemy?.Invoke(other.transform);
        }
        else if(other.CompareTag("House") && other.transform!=null)
        {
            ArmyEvent.targetEnemy?.Invoke(other.transform);
        }
    }
}
