using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class SpawnCoin : MonoBehaviour
{
    public int amoutCoin = 3;

    public void Spawn(){
        for(int i=0; i<amoutCoin; i++){
            GoldPooling.Instance.SetPositionGold(transform.position);
        }
    }
}
