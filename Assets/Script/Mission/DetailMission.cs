using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DetailMission : MonoBehaviour
{
    public MissionSO missionSO;
    public Sprite spriteOn;
    public Sprite spriteOff;
    public Sprite spriteProcess;
    private Image imageM;
    private TextMeshProUGUI nameM;
    private TextMeshProUGUI describeM;
    private TextMeshProUGUI txtReqSoldier;
    private TextMeshProUGUI txtReqGold;
    private TextMeshProUGUI txtReqTime;
    private Button btnConfirm;
    private int amountSoldier;
    private int amountGold;

    void Awake()
    {
        imageM = transform.Find("ImageMission").GetComponent<Image>();
        nameM = transform.Find("Name").GetComponent<TextMeshProUGUI>();
        describeM = transform.Find("Describe").GetComponent<TextMeshProUGUI>();
        txtReqSoldier = transform.Find("Requiment").Find("soldier").GetComponent<TextMeshProUGUI>();
        txtReqGold = transform.Find("Requiment").Find("gold").GetComponent<TextMeshProUGUI>();
        txtReqTime = transform.Find("Requiment").Find("time").GetComponent<TextMeshProUGUI>();
        btnConfirm = transform.Find("BtnConfirm").GetComponent<Button>();
        btnConfirm.onClick.AddListener(OnClickConfirm);
        
        if(missionSO.isComplete){
            transform.gameObject.SetActive(false);
            SetCompleteMission();
        } 
        else{
            GetComponent<CompleteMission>().DisActiveGOComplete();
        }
    }
    private void OnEnable()
    {
        SetStaticDetail();
        SetDynamicDetail();
        SetBtnForReq();
    }
    
    public void UpdateMission(){
        SetCompleteMission();
        if(missionSO.isComplete){
            transform.gameObject.SetActive(false);
        }       
    }
    public void SetStaticDetail(){
        imageM.sprite = missionSO.ImageMission;
        nameM.text = missionSO.NameMission;
        describeM.text = missionSO.Describe;
        txtReqTime.text = missionSO.TimeToComplete+"";
    }
    public void SetDynamicDetail(){
        amountSoldier = ArmyPlayer.Instance.GetAmoutPlayer();
        amountGold = 20;
        txtReqSoldier.text = amountSoldier+"/"+missionSO.RequimentSoldier;
        txtReqGold.text = amountGold+"/"+missionSO.RequimentGold;
    }

    public void SetBtnForReq(){
        if(amountSoldier>=missionSO.RequimentSoldier && amountGold>=missionSO.RequimentGold){
            btnConfirm.GetComponent<Image>().sprite = spriteOn;
        }
        else{
            btnConfirm.GetComponent<Image>().sprite = spriteOff;
        }
    }
    
    public void OnClickConfirm(){
        if(btnConfirm.GetComponent<Image>().sprite == spriteOn){
            if(!ProgressBar.Instance.isProgress){

                ProgressBar.Instance.ExecuteMission(missionSO.TimeToComplete, missionSO.TypeMission,this.gameObject);
                btnConfirm.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Thực hiện";
                btnConfirm.GetComponent<Image>().sprite = spriteProcess;

            }
            else{
                Debug.Log("In progress other mission");
            }
            
        }
        else{
            Debug.Log("Can't do");
        }
    }

    private void SetCompleteMission(){
        missionSO.isComplete = true;
        GetComponent<CompleteMission>().ActiveGOComplete();
    }
}
