using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteMission : MonoBehaviour
{
    public GameObject goComplete;
    
    public void DisActiveGOComplete(){
        if(goComplete!=null){
            goComplete.SetActive(false);
        }    
    }

    public void ActiveGOComplete(){
        if(goComplete!=null){
            goComplete.SetActive(true);
        }
    }

    
}
