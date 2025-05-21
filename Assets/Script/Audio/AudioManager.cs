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
    public static AudioManager Instance;

    void Awake()
    {
        if(Instance==null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
        
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
        BuyCoin,
        Build,
        Rock,
        Slash
    }
    public enum MusicData{
        BackgroundMusic
    }
    
}
