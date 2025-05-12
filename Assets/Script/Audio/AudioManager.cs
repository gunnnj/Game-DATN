using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource bgMusic;
    [SerializeField] private AudioSource soundFX;
    [SerializeField] List<AudioClip> soundClips;
    [SerializeField] List<AudioClip> musicClips;
    [SerializeField] public Sprite imgOn;
    [SerializeField] public Sprite imgOff;
    [SerializeField] public Button btnSound;
    [SerializeField] public Button btnMusic;
    private bool isSoundOn;
    private bool isMusicOn;
    public static AudioManager Instance;

    void Start()
    {
        Instance = this;
        isSoundOn = true;
        isMusicOn = true;

        btnSound?.onClick.AddListener(SettingSound);

        btnMusic?.onClick.AddListener(SettingMusic);
        
        
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            PlaySfx(SoundFXData.ChangeLineUp);
            ToastUI.Instance.DisplayToast("Hello");
        }
    }
    public void PlaySfx(SoundFXData soundFXData){
        soundFX.PlayOneShot(soundClips[(int)soundFXData]);
    }
    public void SetMuteSfx(bool isMute)
    {
        soundFX.mute = isMute;
    }
    public void SetMuteMusic(bool isMute)
    {
        bgMusic.mute = isMute;
    }
    public void PauseMusic()
    {
        bgMusic.Pause();
    }
    public void PlayMusic()
    {
        bgMusic.Play();
    }

    public enum SoundFXData{
        CollectCoin,
        ThrowWeapon,
        Gethit,
        Warning,
        Explode,
        Earthquake,
        Laser,
        Losing,
        Winning,
        ChangeLineUp,
        Heal,
        FireBall,
        BuyCoin
    }
    public enum MusicData{
        BackgroundMusic
    }
    //Add button popup
    public void SettingSound(){
        isSoundOn = !isSoundOn;
        if(isSoundOn){
            btnSound.transform.DOLocalMoveX(213f, 0.2f).SetEase(Ease.Linear);
            btnSound.GetComponent<Image>().sprite = imgOn;
        }
        else{
            btnSound.transform.DOLocalMoveX(326f, 0.2f).SetEase(Ease.Linear);
            btnSound.GetComponent<Image>().sprite = imgOff;
        }
        SetMuteSfx(!isSoundOn);
    }
    public void SettingMusic(){
        isMusicOn = !isMusicOn;
        if(isMusicOn){
            btnMusic.transform.DOLocalMoveX(213f, 0.2f).SetEase(Ease.Linear);
            btnMusic.GetComponent<Image>().sprite = imgOn;
        }
        else{
            btnMusic.transform.DOLocalMoveX(326f, 0.2f).SetEase(Ease.Linear);
            btnMusic.GetComponent<Image>().sprite = imgOff;
        }
        SetMuteMusic(!isMusicOn);
    }
}
