using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SupportItem : MonoBehaviour
{
    public GameObject spItem;
    public int typeSp;
    private Button button;
    
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ActiveItem);
        if(spItem!=null) spItem.SetActive(false);
    }

    public void ActiveItem(){
        if(typeSp==0){
            if(spItem!=null) spItem.SetActive(true);
        }
        else{
            ActiveMedicin();
        }
        
    }

    private void ActiveMedicin()
    {
        
    }
}
