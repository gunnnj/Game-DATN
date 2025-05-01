using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public GameObject popUpResume;
    public Slider barLoading;
    public GameObject option;
    public GameObject setting;
    public static Controller Instance;
    
    void Start()
    {
        Instance = this;
        if(barLoading!=null){
            SetActive(barLoading.gameObject,false);
        }
        SetActive(setting,false);
        SetActive(popUpResume,false);
        Time.timeScale =1;
    }
    private void SetActive(GameObject go, bool value){
        if(go!=null){
            go.SetActive(value);
        }
    }
    public void LoadMenu(){
        SceneManager.LoadScene(0);
    }
    public void LoadLevel(int level){
        StartCoroutine(LoadScene(level));
    }
    public IEnumerator LoadScene(int ind){
        SetActive(option,false);
        SetActive(barLoading.gameObject,true);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(ind);

        while (!asyncLoad.isDone)
        {
            float progressAsyn = Mathf.Clamp01(asyncLoad.progress/0.9f);
            barLoading.value = progressAsyn;
            yield return null;
        }
        yield return null;
    }
    public void LoadSceneLevel(){
        SceneManager.LoadScene("Level");
    }
    public void DisplayPopupSetting(){
        setting.SetActive(true);
    }
    public void ClosePopUp(){
        setting.SetActive(false);
    }
    public void DisplayPopUpResume(){
        SetActive(popUpResume,true);
        Time.timeScale = 0;
    }
    public void CloseResume(){
        SetActive(popUpResume,false);
    }
    public void Resume(){
        Time.timeScale = 1;
        SetActive(popUpResume,false);
    }
    public void Quit(){
        Application.Quit();
    }
}
