using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Script.Event;
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
    private async void OnEnable()
    {
        SetStaticDetail();
        await Task.Delay(1000);
        SetDynamicDetail();
        // SetBtnForReq();
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
    public async void SetDynamicDetail(){
        amountSoldier = ArmyPlayer.Instance.GetAmoutPlayer();
        await Task.Delay(200);
        amountGold = GameManage.Instance.GetGold();
      
        txtReqSoldier.text = amountSoldier+"/"+missionSO.RequimentSoldier;
        txtReqGold.text = amountGold+"/"+missionSO.RequimentGold;
        SetBtnForReq();
    }

    public void SetBtnForReq(){
        if(amountSoldier>missionSO.RequimentSoldier && amountGold>=missionSO.RequimentGold){
            btnConfirm.GetComponent<Image>().sprite = spriteOn;
        }
        else{
            btnConfirm.GetComponent<Image>().sprite = spriteOff;
        }
    }
    
    public async void OnClickConfirm(){

        for(int i=0; i<missionSO.RequimentSoldier;i++){
            Debug.Log("-1 soldier");
            await Task.Delay(200);
            ArmyPlayer.Instance.SoldierDead();
            ArmyEvent.soldierDead?.Invoke();
        }

        GameManage.Instance.MinusGold(missionSO.RequimentGold);


        if(btnConfirm.GetComponent<Image>().sprite == spriteOn){
            if(!ProgressBar.Instance.isProgress){

                ProgressBar.Instance.ExecuteMission(missionSO.TimeToComplete, missionSO.TypeMission,this.gameObject);
                btnConfirm.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Thực hiện";
                btnConfirm.GetComponent<Image>().sprite = spriteProcess;

            }
            else{
                Debug.Log("Can't do");
            }
            
        }
        else{
            Debug.Log("Can't do");
        }
    }

    private async void SetCompleteMission(){
        missionSO.isComplete = true;
        GameObject army = FindFirstObjectByType<ArmyPlayer>().gameObject;
        for(int i=0; i<missionSO.RequimentSoldier;i++){
            await Task.Delay(200);
            PlayerEvent.addPlayer?.Invoke(army.transform.position);
        }
        GetComponent<CompleteMission>().ActiveGOComplete();
        if(missionSO.ImageMission.name == "MH1" || missionSO.ImageMission.name == "MH2"){
            ToastUI.Instance.DisplayToast("Nhà chính đã hoàn thành!");
            GameEvent.completeBuildHouse?.Invoke();
        }
    }
}
