using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Mission : MonoBehaviour
{
    public GameObject tabMission;
    public Image[] imgBtns;
    private Color btnOff;
    private Color btnOn;
    private Transform trainRoom;
    private Transform manufacturingRoom;
    private Transform contactRoom;
    private Transform buildRoom;



    void Start()
    {
        btnOff = new Color(0.65f,0.65f,0.65f,1);
        btnOn = new Color(1,1,1,1);
        trainRoom = transform.Find("TrainRoom");
        manufacturingRoom = transform.Find("ManufacturingRoom");
        contactRoom = transform.Find("ContactRoom");
        buildRoom = transform.Find("BuildRoom");
    }

    public void TurnMission(){
        tabMission.SetActive(!tabMission.activeSelf);
    }
    
    private void DisActiveContain(){
        trainRoom.Find("Contain").gameObject.SetActive(false);
        manufacturingRoom.Find("Contain").gameObject.SetActive(false);
        contactRoom.Find("Contain").gameObject.SetActive(false);
        buildRoom.Find("Contain").gameObject.SetActive(false);
    }
    private void SetColorBtnOff(){
        foreach(var item in imgBtns){
            item.color = btnOff;
        }
    }

    public void RestRoom(){

    }

    //Phòng huấn luyện
    public void TrainRoom(){
        DisActiveContain();
        SetColorBtnOff();
        TurnOnContain(trainRoom);

    }
    //Phòng chế tạo
    public void ManufacturingRoom(){
        DisActiveContain();
        SetColorBtnOff();
        TurnOnContain(manufacturingRoom);

    }
    //Phòng liên lạc, viện trợ
    public void ContactRoom(){
        DisActiveContain();
        SetColorBtnOff();
        TurnOnContain(contactRoom);

    }
    //Phòng xây dựng
    public void BuildRoom(){
        DisActiveContain();
        SetColorBtnOff();
        TurnOnContain(buildRoom);

    }

    public void TurnOnContain(Transform parent){
        GameObject contain = parent.Find("Contain").gameObject;
        contain.SetActive(true);
        contain.GetComponent<ContainMission>().SetDynamicMission();
        parent.GetComponent<Image>().color = btnOn;
    }

    public void ProgressBar(){

    }

    public void CheckCompleteMission(){

    }
}
