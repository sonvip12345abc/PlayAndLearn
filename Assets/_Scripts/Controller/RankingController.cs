using DG.Tweening;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class RankingController : MonoBehaviour
{
    [SerializeField] private Transform leaderBoardParent;
    public List<PlayerData> leaderboard = new List<PlayerData>();
    public ItemRanking itemRankingPrefab;
    public List<ItemRanking> listItemRanking;

    // 
    [SerializeField] GameObject blackPanel;
    [SerializeField] RectTransform contentPanel;

    private Vector3 posStart = new Vector3 (0, -1200, 0);
    void Start()
    {
        //GenerateLeaderBoard();
    }

    public void OpenRanking()
    {
        GenerateLeaderBoard();
        leaderboard.Clear();
        contentPanel.anchoredPosition = posStart;
        contentPanel.gameObject.SetActive(true);
        blackPanel.gameObject.SetActive(true);
        contentPanel.DOAnchorPos(Vector3.zero, 0.5f);
    }

    public void CloseRanking()
    {
        blackPanel.gameObject.SetActive(false);
        contentPanel.DOAnchorPos(new Vector3(0,-2000,0), 0.5f).OnComplete(() =>
        {
            contentPanel.gameObject.SetActive(false);
            foreach (var item in listItemRanking)
            {
                Destroy(item.gameObject);
            }
            listItemRanking.Clear();
        });

    }

    void GenerateLeaderBoard()
    {
        leaderboard.Clear();
        HashSet<string> usedNames = new HashSet<string>(); 
        int totalPlayers = 19;

        for (int i = 0; i < totalPlayers; i++)
        {
            string playerName;
            do
            {
                playerName = playerNames[Random.Range(0, playerNames.Length)];
            }
            while (usedNames.Contains(playerName));
            usedNames.Add(playerName);
            int playerScore = Random.Range(300, 1400);

            leaderboard.Add(new PlayerData
            {
                name = playerName,
                score = playerScore
            });
        }

        leaderboard.Add(new PlayerData
        {
            name = DataController.Instance.NamePlayer,
            score = DataController.Instance.ScoreChallenge,
        }); 

        leaderboard.Sort((a, b) => b.score.CompareTo(a.score));


        for (int i = 0;i < leaderboard.Count;i++)
        {
            ItemRanking item = Instantiate(itemRankingPrefab, leaderBoardParent);
            listItemRanking.Add(item);
            if (leaderboard[i].name == DataController.Instance.NamePlayer)
            {
                item.SetItemRanking(i, leaderboard[i].name, leaderboard[i].score.ToString(), true);
            }
            else
            {
                item.SetItemRanking(i, leaderboard[i].name, leaderboard[i].score.ToString(), false);
            }

        }

    }

    private string[] playerNames = new string[]
   {
        "Alex", "Chris", "Taylor", "Jordan", "Morgan", "Jamie", "Casey", "Cameron", "Dylan", "Quinn",
        "Riley", "Hayden", "Skyler", "Avery", "Parker", "Rowan", "Reese", "Blake", "Dakota", "Emerson",
        "Logan", "Finley", "Harper", "Jesse", "Kai", "Mason", "Hunter", "Sawyer", "Spencer", "Kendall",
        "Phoenix", "Adrian", "Ryan", "Jaden", "Ellis", "Elliot", "Sam", "Charlie", "Arden", "Lane",
        "Brett", "Shawn", "Rory", "Corey", "Toby", "Alexis", "Marley", "Sasha", "Sydney", "Devon"
   };
}

[System.Serializable]
public class PlayerData
{
    public string name;
    public int score;
}