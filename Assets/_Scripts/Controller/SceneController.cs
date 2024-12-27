using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : Singleton<SceneController>
{

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void LoadScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }
    
    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}


