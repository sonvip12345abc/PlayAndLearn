using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : Singleton<GameStateController>
{
    public GameState currentGameState;
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SoundManager.Instance.PlaySFXOneShot(SoundTag.SFX_Button);
        }
    }
}



[Serializable]
public enum GameState
{
    Home,
    Grade1,
    Grade2,
    Grade3,
    Grade4,
    Grade5,
    Challenger
}
