using System;
using TMPro;
using UnityEngine;
using UnityEngine.Video;

public class ManagerUI : MonoBehaviour
{
    public GameObject winUI;
    public GameObject LoseUI;
    public TMP_Text goldTxt;
    private int amoutGold;

    void OnEnable()
    {
        GameEvent.winGame += WinGame;
        GameEvent.loseGame += LoseGame;
        GameEvent.collectGold+=UpdateGold;
        GameEvent.minustGold+=UpdateGoldMinus;
    }
    void OnDisable()
    {
        GameEvent.winGame -= WinGame;
        GameEvent.loseGame -= LoseGame;
        GameEvent.collectGold-=UpdateGold;
        GameEvent.minustGold-=UpdateGoldMinus;
    }

    

    private void LoseGame()
    {
        LoseUI.SetActive(true);
    }

    private void WinGame()
    {
        winUI.SetActive(true);
    }
    public void OnClickHome(){
        Controller.Instance.LoadMenu();
    }
    public void OnClickPlayAgain(){
        Debug.Log("PlayAgain");
    }
    public void OnClickNextLevel(){
        Debug.Log("Next");
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
}
