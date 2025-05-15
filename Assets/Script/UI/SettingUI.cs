using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour
{
    [SerializeField] public Sprite imgOn;
    [SerializeField] public Sprite imgOff;
    [SerializeField] public Button btnSound;
    [SerializeField] public Button btnMusic;
    private bool isSoundOn;
    private bool isMusicOn;
    private const string valuePrefSound = "isSoundOn";
    private const string valuePrefMusic = "isMusicOn";

    void Start()
    {
        btnSound?.onClick.AddListener(SettingSound);
        btnMusic?.onClick.AddListener(SettingMusic);
        SetPositionBtn();
    }

    public void SetPositionBtn(){
        isMusicOn = PlayerPrefs.GetInt(valuePrefMusic,0) == 1;
        isSoundOn = PlayerPrefs.GetInt(valuePrefSound,0) == 1;
        if(isMusicOn){
            btnMusic.transform.DOLocalMoveX(213f, 0.2f).SetEase(Ease.Linear);
            btnMusic.GetComponent<Image>().sprite = imgOn;
        }
        else{
            btnMusic.transform.DOLocalMoveX(326f, 0.2f).SetEase(Ease.Linear);
            btnMusic.GetComponent<Image>().sprite = imgOff;
        }
        if(isSoundOn){
            btnSound.transform.DOLocalMoveX(213f, 0.2f).SetEase(Ease.Linear);
            btnSound.GetComponent<Image>().sprite = imgOn;
        }
        else{
            btnSound.transform.DOLocalMoveX(326f, 0.2f).SetEase(Ease.Linear);
            btnSound.GetComponent<Image>().sprite = imgOff;
        }

    }
    //Add button popup
    public void SettingSound(){
        isSoundOn = !isSoundOn;
        PlayerPrefs.SetInt(valuePrefSound,isSoundOn?1:0);
        if(isSoundOn){
            btnSound.transform.DOLocalMoveX(213f, 0.2f).SetEase(Ease.Linear);
            btnSound.GetComponent<Image>().sprite = imgOn;
        }
        else{
            btnSound.transform.DOLocalMoveX(326f, 0.2f).SetEase(Ease.Linear);
            btnSound.GetComponent<Image>().sprite = imgOff;
        }
        AudioManager.Instance.SetMuteSfx(!isSoundOn);
    }
    public void SettingMusic(){
        isMusicOn = !isMusicOn;
        PlayerPrefs.SetInt(valuePrefMusic,isSoundOn?1:0);
        if(isMusicOn){
            btnMusic.transform.DOLocalMoveX(213f, 0.2f).SetEase(Ease.Linear);
            btnMusic.GetComponent<Image>().sprite = imgOn;
        }
        else{
            btnMusic.transform.DOLocalMoveX(326f, 0.2f).SetEase(Ease.Linear);
            btnMusic.GetComponent<Image>().sprite = imgOff;
        }
        AudioManager.Instance.SetMuteMusic(!isMusicOn);
    }
}
