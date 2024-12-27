using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grade1Controller : Singleton<Grade1Controller>
{
    [SerializeField] List<GameObject> listLevel1;
    [SerializeField] PopupWinControl popupWin;
    [SerializeField] GameObject btnSelectLevel;
    [SerializeField] GameObject conffetiWin;
    [SerializeField] Button btnBackLevel;
    [SerializeField] Button btnBackHome;
    [SerializeField] GameObject effectEndScene;
    private int currentLevel;

    [SerializeField] RectTransform correctPrefab;
    [SerializeField] RectTransform in_correctPrefab;
    [SerializeField] Transform effectParent;
    [SerializeField] Text textLevelCurrent;
    public LevelController currentLeveOnDisplay;
    public Button btnHint;
    public int amountHint;

    public void ButtonHint()
    {
        amountHint--;
        if(amountHint == 0) btnHint.gameObject.SetActive(false);
        currentLeveOnDisplay.EnableHint();
    }
    public void ActiveTextLevel()
    {
        textLevelCurrent.text = "Level " + (currentLevel + 1);
    }

    public void ActiveCorrectEffect(Vector3 pos)
    {
        RectTransform effect = Instantiate(correctPrefab, effectParent);
        effect.position = pos;
        effect.gameObject.SetActive(true);

    }

    public void ActiveInCorrectEffect(Vector3 pos)
    {
        RectTransform effect = Instantiate(in_correctPrefab, effectParent);
        effect.position = pos;
        effect.gameObject.SetActive(true);

    }
    private void Start()
    {
        amountHint = 2;
        btnHint.onClick.AddListener(ButtonHint);
        btnBackHome.onClick.AddListener(BackToHome);
        btnBackLevel.onClick.AddListener(BackLevel);
        btnSelectLevel.gameObject.SetActive(true);
        btnBackLevel.gameObject.SetActive(false);
        btnBackHome.gameObject.SetActive(true);
        
        foreach (GameObject it in listLevel1)
        {
            it.SetActive(false);
        }
    }

    private void BackToHome()
    {
        GameStateController.Instance.currentGameState = GameState.Home;
        effectEndScene.SetActive(true);
        StartCoroutine(StartBackToHome());
        
    }

    IEnumerator StartBackToHome()
    {
        yield return new WaitForSeconds(0.75f);
        SceneController.Instance.LoadScene("Home");
    }

    private void BackLevel()
    {
        btnBackHome.gameObject.SetActive(true);
        btnBackLevel.gameObject.SetActive(false);
        foreach (GameObject it in listLevel1)
        {
            it.SetActive(false);
        }
        btnSelectLevel.SetActive(true);
    }

    public void LoadLevel(int level)
    {
        foreach (GameObject it in listLevel1)
        {
            it.SetActive(false);
        }
        currentLevel = level;
        btnSelectLevel.SetActive(false);
        btnBackHome.gameObject.SetActive(false);
        btnBackLevel.gameObject.SetActive(true);
        listLevel1[level].SetActive(true);
        currentLeveOnDisplay= listLevel1[level].GetComponent<LevelController>();
        ActiveTextLevel();

    }

    public void StartWin()
    {
        popupWin.Show();
        
        conffetiWin.gameObject.SetActive(true);
        if (currentLevel >= DataController.Instance.DataGrade1)
        {
            DataController.Instance.DataGrade1++;
            
        }

        currentLevel++;
        if (currentLevel >= listLevel1.Count) { currentLevel = 0; popupWin.ShowTextComPlete(); }
        }

    public void NextLevel()
    {
        popupWin.Hide();
        LoadLevel(currentLevel);
        StartCoroutine(StartLoadNewLevel());

    }

    IEnumerator StartLoadNewLevel()
    {
        yield return new WaitForSeconds(0.5f);
        LoadLevel(currentLevel);
    }

}
