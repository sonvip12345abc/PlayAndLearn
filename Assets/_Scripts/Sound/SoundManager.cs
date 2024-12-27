
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class SoundManager : Singleton<SoundManager>
{


    public List<Sound> BG_Sound, Sfx_Sound;
    public AudioSource BG_Source;
    public AudioSource Sfx_Source;
    public AudioSource Sfx_Soure_Loop;
    public AudioSource Sfx_Soure_PlayOneShot;
    public float volumeBGM = 0.3f;
    


    public bool IsSoundOn;
    public bool IsMusicOn;
    public bool IsNotifyOn;
    public bool IsVibrationOn;


    private void Awake()
    {
        DontDestroyOnLoad(this);
        //this._isMuteBGMusic = PlayerPrefs.GetInt(CONSTANT.IsMuteBGMusic, 0) == 1;
        //this._isMuteSoundEffect = PlayerPrefs.GetInt(CONSTANT.IsMuteSoundEffect, 0) == 1;
        IsMusicOn = DataController.Instance.MusicOn == 1 ? true : false;
        IsSoundOn = DataController.Instance.SoundOn == 1 ? true : false;
        IsNotifyOn = PlayerPrefs.GetInt("NotifyOn", 1) == 1 ? true : false;
        IsVibrationOn = DataController.Instance.VibrationOn == 1 ? true : false;
    }

    private void Start()
    {
       
        this.PlayBGM(SoundTag.BGM_GameMusic);
        CheckBGM();
    }

    public void SaveDataSetting()
    {
        if (IsMusicOn) 
            DataController.Instance.MusicOn = 1;
        else 
            DataController.Instance.MusicOn = 0;

        if (IsSoundOn)
            DataController.Instance.SoundOn = 1;
        else
            DataController.Instance.SoundOn = 0;

        if (IsVibrationOn)
            DataController.Instance.VibrationOn = 1;
        else
            DataController.Instance.VibrationOn = 0;
    }
    public void CheckBGM()
    {
        if (IsMusicOn)
        {
            if(BG_Source.clip != null)
            {
                BG_Source.volume = volumeBGM;
            }
            else
            {
                this.PlayBGM(SoundTag.BGM_GameMusic);
            }
         
        }
        else
        {
            BG_Source.volume = 0;
        }
    }
    public void PlaySFX(SoundTag soundTag)
    {
        if (!IsSoundOn) return;
        foreach (Sound s in Sfx_Sound)
        {
            if (s.tag == soundTag)
            {
                Sfx_Source.volume = s.volume;
                Sfx_Source.clip = s.clip;
                Sfx_Source.loop = false;
                Sfx_Source.Play();
                break;
            }
        }
    }

    public bool IsSFXSourcePlaying()
    {
        return Sfx_Source.isPlaying;
    }

    public void PlaySFXOneShot(SoundTag soundTag)
    {
        if (!IsSoundOn) return;
        foreach (Sound s in Sfx_Sound)
        {
            if (s.tag == soundTag)
            {
                Sfx_Soure_PlayOneShot.volume = s.volume;
                Sfx_Soure_PlayOneShot.PlayOneShot(s.clip);
                break;
            }
        }
    }
    public void PlaySfxLoop(SoundTag soundTag)
    {
        if (!IsSoundOn) return;
        foreach (Sound s in Sfx_Sound)
        {
            if (s.tag == soundTag)
            {
                Sfx_Soure_Loop.volume = s.volume;
                Sfx_Soure_Loop.clip = s.clip;
                Sfx_Soure_Loop.loop = true;
                Sfx_Soure_Loop.Play();
                break;
            }
        }
    }

    public void StopSfxLoop()
    {
        Sfx_Soure_Loop.Stop();
    }


    public void PlayBGM(SoundTag soundTag)
    {
        if (!IsMusicOn) return;
        foreach (Sound s in BG_Sound)
        {
            if (s.tag == soundTag)
            {
                volumeBGM = s.volume;
                BG_Source.volume = s.volume;
                BG_Source.clip = s.clip;
                BG_Source.loop = true;
                BG_Source.Play();
                break;
            }
        }
    }
    public void StopAllSound()
    {
        StopCurrentBG();
        StopCurrentSFX();
        StopSfxLoop();
    }

    public void StopCurrentBG()
    {
        BG_Source.Pause();
    }
    public void ContinueCurrentBG()
    {
        BG_Source.UnPause();
    }
    public void StopCurrentSFX()
    {
        //foreach (AudioSource audio in Sfx_Source)
        //    audio.Stop();
    }
    public int maxTapticCount = 1;
    int tapticCount;

    public float tapticLimitTime = 0.1f;
    float tapticLimitTimeCount;
    public void OnTaptic(TypeTaptic type)
    {
        if (IsVibrationOn == false) return;

        if (tapticCount >= maxTapticCount)
        {
            return;
        }

        if (tapticCount == 0)
        {
            tapticLimitTimeCount = tapticLimitTime;
        }
        tapticCount++;

        switch (type)
        {
            case TypeTaptic.Warning:
                {
                    Taptic.Warning();
                }
                break;
            case TypeTaptic.Failure:
                {
                    Taptic.Failure();
                }
                break;
            case TypeTaptic.Success:
                {
                    Taptic.Success();
                }
                break;
            case TypeTaptic.Light:
                {
                    Taptic.Light();
                }
                break;
            case TypeTaptic.Medium:
                {
                    Taptic.Medium();
                }
                break;
            case TypeTaptic.Heavy:
                {
                    Taptic.Heavy();
                }
                break;
            case TypeTaptic.Default:
                {
                    Taptic.Default();
                }
                break;
            case TypeTaptic.Vibrate:
                {
                    Taptic.Vibrate();
                }
                break;
            case TypeTaptic.Selection:
                {
                    Taptic.Selection();
                }
                break;

        }
    }


}

public enum TypeTaptic { Warning, Failure, Success, Light, Medium, Heavy, Default, Vibrate, Selection }



