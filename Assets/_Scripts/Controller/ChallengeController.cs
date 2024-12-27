using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ChallengeController : Singleton<ChallengeController>
{
    [SerializeField] public List<GameObject> listLevelChallenge = new List<GameObject>();
    [SerializeField] public List<GameObject> listDataLevelChallenge = new List<GameObject>();
    [SerializeField] PopupWinControl popupWin;
    [SerializeField] PopupCompleteChallengeControl popupCompleteChallenge;
    [SerializeField] Button btnBackHome;
    [SerializeField] Button btnStart;
    [SerializeField] GameObject conffetiWin;
    [SerializeField] GameObject effectEndScene;
    private int currentLevel = 0;

   

    [SerializeField] RectTransform correctPrefab;
    [SerializeField] RectTransform in_correctPrefab;
    [SerializeField] Transform effectParent;

    [SerializeField] GameObject animTho1;
    [SerializeField] GameObject anim321;
    [SerializeField] Text textNumberLevel;
    [SerializeField] Text textScore;
    [SerializeField] Text textScorePopup;
    



    //clock
    public float countdownTime; 
    public Text timerText;
    public bool isPause = false;
    public bool isStarted = false;

    //score
    public int currentScore = 0;
    public Button btnSkip;
    public Button btnComplete;
    public List<int> ListIndexSkip;
    public int currentIndexSkip = 0;
    public int soCauDung;
    public int currentIndexLevelOnDisplay;
    
    
    private void Start()
    {
        listLevelChallenge.Clear();
        if (listDataLevelChallenge.Count >= 25)
        {
            for (int i = 0; i < 25; i++)
            {
                int rd = Random.Range(0, listDataLevelChallenge.Count);
                listLevelChallenge.Add(listDataLevelChallenge[rd]);
                listDataLevelChallenge.RemoveAt(rd);
            }
        }
        // ShuffleLevel();
        btnBackHome.onClick.AddListener(BackToHome);
        countdownTime = 20 * 60;
        btnStart.gameObject.SetActive(true);
        animTho1.SetActive(true);
        btnStart.onClick.AddListener(OnButtonStart);
        textScore.text = currentLevel.ToString();
        btnSkip.onClick.AddListener(Skip);
        btnComplete.onClick.AddListener(ButtonComplete);
        btnSkip.gameObject.SetActive(false);
        btnComplete.gameObject.SetActive(false);
    }

    private void Skip()
    {
        if (currentLevel < listLevelChallenge.Count-1)
        {
            ListIndexSkip.Add(currentIndexLevelOnDisplay);
            currentLevel++;
            LoadLevel(currentLevel);
        }
        else
        {
            ListIndexSkip.Add(currentIndexLevelOnDisplay);
            LoadLevel(ListIndexSkip[currentIndexSkip]);
            currentIndexSkip++;
        }
      
    }

    private void ButtonComplete()
    {
        SoundManager.Instance.PlaySFXOneShot(SoundTag.SFX_Win);
        if (currentScore > DataController.Instance.ScoreChallenge)
        {
            DataController.Instance.ScoreChallenge = currentScore;

        }
        timerText.text = "00 : 00";
        textScore.text = currentScore.ToString();
        textScorePopup.text = currentScore.ToString();
        popupCompleteChallenge.Show();
        isPause = true;
    }
    void ShuffleLevel()
    {
        for (int i = 0; i < 50; i++)
        {
            int rd = Random.Range(0, listLevelChallenge.Count);
            listLevelChallenge.Add(listLevelChallenge[rd]);
            listLevelChallenge.RemoveAt(rd);
        }
        
        
    }
    void Update()
    {
        if(!isStarted)  return; 
        if (isPause) return;
        if (countdownTime <= 0) return;
        countdownTime -= Time.deltaTime;  
        if (countdownTime <= 0)
        {
            SoundManager.Instance.PlaySFXOneShot(SoundTag.SFX_Win);
            if (currentScore > DataController.Instance.ScoreChallenge)
            {
                DataController.Instance.ScoreChallenge = currentScore;

            }
            timerText.text = "00 : 00";
            textScore.text = currentScore.ToString();
            textScorePopup.text = currentScore.ToString();
            popupCompleteChallenge.Show();
            isPause = true;
        }  

        int minutes = Mathf.FloorToInt(countdownTime / 60); 
        int seconds = Mathf.FloorToInt(countdownTime % 60); 
        timerText.text = $"{minutes:00}:{seconds:00}";
    }

    void OnButtonStart()
    {
        btnStart.gameObject.SetActive(false);
        anim321.SetActive(true);
        Invoke(nameof(StartChallenge), 3f);
    }

    void StartChallenge()
    {
        anim321.SetActive(false);
        animTho1.SetActive(false);
        LoadLevel(0);
        isStarted = true;
        btnSkip.gameObject.SetActive(true);
        btnComplete.gameObject.SetActive(true);
        countdownTime = 20 * 60;
    }

    void SetTextNumberLevel()
    {
        
        string s = (soCauDung).ToString() + "/" + listLevelChallenge.Count.ToString();
       
        textNumberLevel.text = s ;
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

    public void BackToHome()
    {
        GameStateController.Instance.currentGameState = GameState.Home;
        effectEndScene.SetActive(true);
        StartCoroutine(StartBackToHome());

    }

    IEnumerator StartBackToHome()
    {
        yield return new WaitForSeconds(0.75f);
        GameStateController.Instance.currentGameState = GameState.Home;
        SceneController.Instance.LoadScene("Home");
       
    }

    public void StartWin()
    {
        currentLevel++;
        soCauDung++;
        if (currentLevel >= listLevelChallenge.Count)
        {
            currentIndexSkip++;
        }
        SoundManager.Instance.OnTaptic(TypeTaptic.Success);
        if (soCauDung >= listLevelChallenge.Count)
        {
            currentScore += 20;
            textScore.text = currentScore.ToString();
            Debug.LogError("done challenge");
            currentScore += (int)countdownTime;
            
            if (currentScore > DataController.Instance.ScoreChallenge)
            {
                DataController.Instance.ScoreChallenge = currentScore;
                
            }
            textScore.text = currentScore.ToString();
            textScorePopup.text = currentScore.ToString();
            popupCompleteChallenge.Show();
            isPause = true;
        }
        else
        {
            popupWin.Show();
            currentScore += 20;
            textScore.text = currentScore.ToString();
            isPause = true;
            conffetiWin.gameObject.SetActive(true);
        }
    }

    public void NextLevel()
    {
        if (currentLevel < listLevelChallenge.Count)
        {
            popupWin.Hide();
            LoadLevel(currentLevel);
            // StartCoroutine(StartLoadNewLevel());
        }
        else
        {
            popupWin.Hide();
            LoadLevel(ListIndexSkip[currentIndexSkip]);
            // StartCoroutine(StartLoadNewLevel());
        }
     

    }
    IEnumerator StartLoadNewLevel()
    {
        yield return new WaitForSeconds(0.5f);
        LoadLevel(currentLevel);
    }

    public void LoadLevel(int level)
    {
        foreach (GameObject it in listLevelChallenge)
        {
            it.SetActive(false);
        }

        currentIndexLevelOnDisplay = level;
        // currentLevel = level;
        listLevelChallenge[level].SetActive(true);
        SetTextNumberLevel();
        isPause = false;

    }

}
