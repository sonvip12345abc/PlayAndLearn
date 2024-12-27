using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradesController : MonoBehaviour
{
    [SerializeField] GameObject effectEndScene;
    public void LoadGame(string name)
    {
        switch (name){
            case "Grade1":
                GameStateController.Instance.currentGameState = GameState.Grade1;
                break;

            case "Grade2":
                GameStateController.Instance.currentGameState = GameState.Grade2;
                break;
            case "Grade3":
                GameStateController.Instance.currentGameState = GameState.Grade3;
                break;

            case "Grade4":
                GameStateController.Instance.currentGameState = GameState.Grade4;
                break;
            case "Grade5":
                GameStateController.Instance.currentGameState = GameState.Grade5;
                break;
            case "Challenge":
                GameStateController.Instance.currentGameState = GameState.Challenger;
                break;

        }
        effectEndScene.SetActive(true);
        StartCoroutine(LoadScene(name));
        
    }

    IEnumerator LoadScene( string name)
    {
        yield return new WaitForSeconds(0.75f);
        SceneController.Instance.LoadScene(name);
    }
    
}
