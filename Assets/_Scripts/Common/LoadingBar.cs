using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class LoadingBar : MonoBehaviour
{
    [SerializeField] Image loadingFill;
  

    private void Start()
    {
        loadingFill.fillAmount = 0;

        Loading();
    }

    void Loading()
    {
        loadingFill.DOFillAmount(1, 3f).OnComplete(() =>
        {
            if (PlayerPrefs.GetInt("FirstSession",1) == 1)
            {
                SceneController.Instance.LoadScene("SelectNameAndAvatar");
                PlayerPrefs.SetInt("FirstSession", 0);
            }
            else
            {
                SceneController.Instance.LoadScene("Home"); 
                GameStateController.Instance.currentGameState = GameState.Home;
            }
            
        });
    }


}
