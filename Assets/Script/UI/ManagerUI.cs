using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ManagerUI : MonoBehaviour
{
    public Image winUI;
    public Image LoseUI;
    public TMP_Text goldTxt;
    public GameObject canvasHp;
    public GameObject winGo;
    public GameObject loseGo;
    public Image progressBoss;
    private int amoutGold;
    private Color originColor;
    private Color originColorLose;
    public static ManagerUI Instance;
    

    void Awake()
    {
        Instance = this;
    }
    void OnEnable()
    {
        GameEvent.winGame += WinGame;
        GameEvent.loseGame += LoseGame;
        GameEvent.collectGold+=UpdateGold;
        GameEvent.minustGold+=UpdateGoldMinus;
        GameEvent.completeBuildHouse+=UpdateProgressBoss;
    }
    public void Start()
    {
        originColor = winUI.color;
        originColorLose = LoseUI.color;
    }
    void OnDisable()
    {
        GameEvent.winGame -= WinGame;
        GameEvent.loseGame -= LoseGame;
        GameEvent.collectGold-=UpdateGold;
        GameEvent.minustGold-=UpdateGoldMinus;
    }

    private async void LoseGame(int type)
    {
        if(type == 1){
            await Task.Delay(1000);
            GameManage.Instance.SwithCamera(true);
            await Task.Delay(2000);
        }
        
        LoseUI.gameObject.SetActive(true);
        FadeImg(LoseUI, loseGo, originColorLose);
        await Task.Delay(500);
        AudioManager.Instance.PlaySfx(AudioManager.SoundFXData.Losing);

    }
    public async void ShowPopUp(RectTransform rect){
        float scale = 0.5f;
        while(scale<1.2f){
            await Task.Delay(5);
            scale+=0.1f;
            rect.localScale = new Vector3(scale,scale,scale);
        }
        scale = 1.1f;
        rect.localScale = new Vector3(scale,scale,scale);
        await Task.Delay(5);
        scale = 1f;
        rect.localScale = new Vector3(scale,scale,scale);
    }
    public async void FadeImg(Image bg, GameObject logo, Color color){
        float alpha = 0;
        while(alpha<1f){
            await Task.Delay(5);
            alpha+=0.03f;
            bg.color = new Color(color.r,color.g,color.b, alpha);
        }
        
        RectTransform rect = logo.GetComponent<RectTransform>();
        rect.localScale = new Vector3(0.5f,0.5f,0.5f);
        logo.SetActive(true);
        ShowPopUp(rect);
    }
    private async void WinGame()
    {
        winUI.gameObject.SetActive(true);
        FadeImg(winUI, winGo, originColor);
        await Task.Delay(500);
        AudioManager.Instance.PlaySfx(AudioManager.SoundFXData.Winning);

    }
    public void OnClickHome(){
        Controller.Instance.LoadMenu();
    }
    public void OnClickPlayAgain(int level){
        Controller.Instance.LoadLevel(level);
    }
    public void OnClickNextLevel(int level){
        Controller.Instance.LoadLevel(level);
    }
    public void UpdateGold(){
        amoutGold = GameManage.Instance.GetGold();
        goldTxt.text = amoutGold+1+"";
    }
    private void UpdateGoldMinus()
    {
        amoutGold = GameManage.Instance.GetGold();
        goldTxt.text = amoutGold+"";
    }
    public void ShowHpMinus(Transform parrent, int dame){
        GameObject gameObject = Instantiate(canvasHp,parrent);
        gameObject.GetComponent<FloatingTextUI>().ShowText(dame);
    }
    public async void UpdateProgressBoss(){
        float totalTime = GameManage.Instance.timeSpawnEnemy*7;
        float time = 0;
        await Task.Delay(5000);
        while(time<totalTime){
            await Task.Delay(500);
            time+=0.5f;
            progressBoss.fillAmount = time/totalTime;
        }
    }
}
