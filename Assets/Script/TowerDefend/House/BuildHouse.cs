using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class BuildHouse : MonoBehaviour
{
    [SerializeField] GameObject[] parts;
    [SerializeField] float height = 5f;
    void Start()
    {
        SetPosition();
        EffectBuild();
    }
    public void SetPosition(){
        foreach(var item in parts){
            item.transform.position = new Vector3(item.transform.position.x,item.transform.position.y+height,item.transform.position.z);
        }
    }
    public async void EffectBuild(){
        foreach(var item in parts){
            item.SetActive(true);
            item.transform.DOMoveY(item.transform.position.y-height,0.2f);
            await Task.Delay(200);
            AudioManager.Instance.PlaySfx(AudioManager.SoundFXData.Build);
        }
    }
}
