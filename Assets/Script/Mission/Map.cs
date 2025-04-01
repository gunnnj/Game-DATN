using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour
{
    public GameObject BtnOnMap;
    public Image iconProgress;
    public Sprite iconTrain;
    public Sprite iconSetting;
    public Sprite iconContact;
    public Sprite iconBuild;
    public GameObject tabMission;
    public void OnClickBtnMap(){
        this.gameObject.SetActive(!this.gameObject.activeSelf);
        if(this.gameObject.activeSelf){
            BtnOnMap.GetComponent<RectTransform>().localScale = new Vector3(-1,1,1);
        }
        else{
            BtnOnMap.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
        }
    }
    //Phòng nghỉ ngơi
    public void RestRoom(){

    }
    //Phòng huấn luyện
    public void TrainRoom(){
        Rotate(0);
        CloseTabMission();
        iconProgress.sprite = iconTrain;
        tabMission.SetActive(true);

    }
    //Phòng chế tạo
    public void ManufacturingRoom(){
        Rotate(0);
        iconProgress.sprite = iconSetting;
    }
    //Phòng liên lạc, viện trợ
    public void ContactRoom(){
        Rotate(0);
        iconProgress.sprite = iconContact;
    }
    //Phòng xây dựng
    public void BuildRoom(){
        CloseTabMission();
        Rotate(96);
        iconProgress.sprite = iconBuild;
        tabMission.SetActive(true);

    }

    public void Rotate(float x){
        iconProgress.GetComponent<RectTransform>().rotation = Quaternion.Euler(0,0,x);
    }

    public void CloseTabMission(){
        tabMission.SetActive(false);
    }
}
