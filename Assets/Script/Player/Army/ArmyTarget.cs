using Script.Event;
using UnityEngine;

public class ArmyTarget : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        if(ArmyMana.Instance.mana>0){

            if(other.CompareTag("Enemy") && other.transform!=null){
                ArmyEvent.targetEnemy?.Invoke(other.transform);
            }
            else if(other.CompareTag("House") && other.transform!=null)
            {
                ArmyEvent.targetEnemy?.Invoke(other.transform);
            }
        }
        else{
            Debug.Log("Not enough mana");
            //Dùng ToastUI
        }
        
    }
}
