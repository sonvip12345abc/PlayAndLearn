using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public SoundTag tag;
    public AudioClip clip;
    [Range(0f, 1f)]
    public float volume;
}

public enum SoundTag
{
    BGM_GameMusic,
    SFX_Correct,
    SFX_Wrong,
    SFX_Win,
    SFX_Lose,
    SFX_Button
    
}

