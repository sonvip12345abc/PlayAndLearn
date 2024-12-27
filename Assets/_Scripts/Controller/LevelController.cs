using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public int maxAmountBtnCorrect;
    public int curAmountBtnCorrect;
    public int curAmountBtnIncorrect;
    public List<Button> listButtonCorrect;
    public List<Button> listButtonInCorrect;
    public bool isLevelInputResult;
    public Button buttonSubmit;
    public InputField inputField;
    public Text text1;
    public int correctResult = 10;




    void OnEnable()
    {
        ResetLevel();
    }
    private void Start()
    {
        if (isLevelInputResult)
        {
            buttonSubmit.onClick.AddListener(SubmitResult);
            inputField.onEndEdit.AddListener(OnInputFieldEndEdit);
        }
        else
        {
            for (int i = 0; i < listButtonCorrect.Count; i++)
            {
                int x = i;
                listButtonCorrect[x].onClick.AddListener(() =>
                {
                    listButtonCorrect[x].interactable = false;
                    BtnCorrect(listButtonCorrect[x].GetComponent<RectTransform>().position);
                });
            }

            for (int i = 0; i < listButtonInCorrect.Count; i++)
            {
                int x = i;
                listButtonInCorrect[x].onClick.AddListener(() =>
                {

                    BtnInCorrect(listButtonInCorrect[x].GetComponent<RectTransform>().position);
                });
            }
        }

    }

    public void EnableHint()
    {
        if (isLevelInputResult)
        {
            text1.text = correctResult.ToString();
            inputField.text = correctResult.ToString();
        }
        else
        {
            foreach(var item in listButtonCorrect)
            {
                item.image.color = Color.gray;
            }
        }
    }
    void SubmitResult()
    {
        string result = inputField.text.Replace(" ", "");
        int resultInput = int.Parse(result);
        if (resultInput == correctResult)
        {
            Win();
            SoundManager.Instance.OnTaptic(TypeTaptic.Light);
            SoundManager.Instance.PlaySFXOneShot(SoundTag.SFX_Win);
        }
        else
        {
            SoundManager.Instance.OnTaptic(TypeTaptic.Light);
            if (GameStateController.Instance.currentGameState == GameState.Challenger)
            {
                ChallengeController.Instance.countdownTime -= 5f;
            }
            SoundManager.Instance.PlaySFXOneShot(SoundTag.SFX_Wrong);
            this.text1.text = "";
            this.inputField.text = "";
        }
    }

    void OnInputFieldEndEdit(string text)
    {
        Debug.Log(text);
        string textInput = text1.text;
        this.text1.text = textInput;
        this.inputField.text = textInput;
    }

    public void BtnCorrect(Vector3 pos)
    {
        curAmountBtnCorrect++;
        ActiveEffectCorrectButton(pos);
        SoundManager.Instance.OnTaptic(TypeTaptic.Light);
        SoundManager.Instance.PlaySFXOneShot(SoundTag.SFX_Correct);

        if (curAmountBtnCorrect == maxAmountBtnCorrect)
        {
            Win();
            SoundManager.Instance.PlaySFXOneShot(SoundTag.SFX_Win);

        }

    }


    public void BtnInCorrect(Vector3 pos)
    {
        curAmountBtnIncorrect++;
        
        ActiveEffectInCorrectButton(pos);
        SoundManager.Instance.OnTaptic(TypeTaptic.Light);
        SoundManager.Instance.PlaySFXOneShot(SoundTag.SFX_Wrong);
        if (GameStateController.Instance.currentGameState == GameState.Challenger)
        {
            ChallengeController.Instance.countdownTime -= 5f;
        }
        if (curAmountBtnIncorrect == maxAmountBtnCorrect)
        {
            Debug.LogError("lose");

        }
    }
    void Win()
    {
        SoundManager.Instance.OnTaptic(TypeTaptic.Success);
        Debug.LogError("win");
        switch (GameStateController.Instance.currentGameState)
        {
            case GameState.Grade1:
                Grade1Controller.Instance.StartWin();
                break;

            case GameState.Grade2:

                Grade2Controller.Instance.StartWin();
                break;
            case GameState.Grade3:
                Grade3Controller.Instance.StartWin();
                break;

            case GameState.Grade4:
                Grade4Controller.Instance.StartWin();
                break;

            case GameState.Grade5:
                Grade5Controller.Instance.StartWin();
                break;

            case GameState.Challenger:
                ChallengeController.Instance.StartWin();
                break;

        }
    }

    void ActiveEffectCorrectButton(Vector3 pos)
    {
        switch (GameStateController.Instance.currentGameState)
        {
            case GameState.Grade1:
                Grade1Controller.Instance.ActiveCorrectEffect(pos);
                break;

            case GameState.Grade2:

                Grade2Controller.Instance.ActiveCorrectEffect(pos);
                break;
            case GameState.Grade3:
                Grade3Controller.Instance.ActiveCorrectEffect(pos);
                break;

            case GameState.Grade4:
                Grade4Controller.Instance.ActiveCorrectEffect(pos);
                break;

            case GameState.Grade5:
                Grade5Controller.Instance.ActiveCorrectEffect(pos);
                break;

            case GameState.Challenger:
                ChallengeController.Instance.ActiveCorrectEffect(pos);
                break;

        }
    }

    void ActiveEffectInCorrectButton(Vector3 pos)
    {
        switch (GameStateController.Instance.currentGameState)
        {
            case GameState.Grade1:
                Grade1Controller.Instance.ActiveInCorrectEffect(pos);
                break;

            case GameState.Grade2:

                Grade2Controller.Instance.ActiveInCorrectEffect(pos);
                break;
            case GameState.Grade3:
                Grade3Controller.Instance.ActiveInCorrectEffect(pos);
                break;

            case GameState.Grade4:
                Grade4Controller.Instance.ActiveInCorrectEffect(pos);
                break;

            case GameState.Grade5:
                Grade5Controller.Instance.ActiveInCorrectEffect(pos);
                break;

            case GameState.Challenger:
                ChallengeController.Instance.ActiveInCorrectEffect(pos);
                break;

        }
    }
    void ResetLevel()
    {

        // fix
        if (!isLevelInputResult)
        {
            for (int i = 0; i < listButtonCorrect.Count; i++)
            {
                int x = i;
                listButtonCorrect[x].interactable = true;

            }

            curAmountBtnCorrect = 0;
            curAmountBtnIncorrect = 0;
        }

    }
}