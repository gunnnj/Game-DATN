using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class TabMission : MonoBehaviour
{
    async void Start()
    {
        await Task.Delay(500);
        gameObject.SetActive(false);
    }
}
