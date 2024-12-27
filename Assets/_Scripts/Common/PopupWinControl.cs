using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PopupWinControl : MonoBehaviour
{
    [SerializeField] GameObject blackPanel;
    [SerializeField] RectTransform popupPanel;
    [SerializeField] RectTransform anim;
    [SerializeField] RectTransform textComplete;

    public void Show()
    {
        blackPanel.SetActive(true);
        textComplete.gameObject.SetActive(false);
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

    public void ShowTextComPlete()
    {
        textComplete.gameObject.SetActive(true);
    }
    
    
    
}
