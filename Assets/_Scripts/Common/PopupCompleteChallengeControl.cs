using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class PopupCompleteChallengeControl : MonoBehaviour
{
    [SerializeField] GameObject blackPanel;
    [SerializeField] RectTransform popupPanel;
    [SerializeField] RectTransform anim;
    [SerializeField] Button btnGoHome;
    private void Start()
    {
        btnGoHome.onClick.AddListener(GoHome);
    }

    public void Show()
    {
        blackPanel.SetActive(true);
        popupPanel.anchoredPosition = new Vector2(0, -500f);
        anim.localScale = Vector3.one * 0.3f;
        popupPanel.gameObject.SetActive(true);
        popupPanel.DOAnchorPos(Vector2.zero, 0.2f).OnComplete(() =>
        {
            anim.DOScale(Vector3.one * 0.75f, 0.2f);
        });
    }

    public void Hide()
    {
        popupPanel.DOAnchorPos(new Vector2(0, -500f), 0.2f).OnComplete(() =>
        {
            blackPanel.SetActive(false);
            popupPanel.gameObject.SetActive(false);
        });
    }

    public void GoHome()
    {
        ChallengeController.Instance.BackToHome();
    }

}
