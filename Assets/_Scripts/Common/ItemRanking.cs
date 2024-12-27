using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemRanking : MonoBehaviour
{
    public List<Sprite> listIconHuyChuong; // vang bac dong
    public Image iconHuyChuong;
    public Image backgroundItemRanking;
    public Text textName;
    public Text textScore;

    public void SetItemRanking(int index, string name, string score, bool isUser)
    {
        if(index == 0)
        {
            iconHuyChuong.sprite = listIconHuyChuong[0];
        }
        else if(index == 1)
        {
            iconHuyChuong.sprite = listIconHuyChuong[1];
        }
        else if(index == 2)
        {
            iconHuyChuong.sprite = listIconHuyChuong[2];
        }
        else
        {
            iconHuyChuong.gameObject.SetActive(false);
        }

        textName.text = name;
        textScore.text = score;
        if (isUser)
        {
            backgroundItemRanking.color = Color.yellow;
        }
        else
        {
            backgroundItemRanking.color = Color.white;
        }
    }
}
