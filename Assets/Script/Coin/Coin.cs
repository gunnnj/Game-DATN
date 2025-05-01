using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
            GameEvent.collectGold?.Invoke();
            AudioManager.Instance.PlaySfx(AudioManager.SoundFXData.CollectCoin);
            gameObject.SetActive(false);
        }
    }
}
