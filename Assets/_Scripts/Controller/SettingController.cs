using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SettingController : MonoBehaviour
{
    [SerializeField] private GameObject blackPanel;
    [SerializeField] private RectTransform contentSettingPanel;



    [Space(20)]
    [SerializeField] List<Sprite> listSpriteToggle;
    [SerializeField] Button btnToggleMusic;
    [SerializeField] Button btnToggleSound;
    [SerializeField] Button btnToggleVibration;

    [SerializeField] Image imgToggleMusic;
    [SerializeField] Image imgToggleSound;
    [SerializeField] Image imgToggleVibration;

    

    private void Start()
    {
        btnToggleMusic.onClick.AddListener(OnButtonMusic);
        btnToggleSound.onClick.AddListener(OnButtonSound);
        btnToggleVibration.onClick.AddListener(OnButtonVibration);
        SetUp();
    }

    public void OpenPopupSetting()
    {
        blackPanel.SetActive(true);
        SetUp();
        contentSettingPanel.localScale = Vector3.one * 0.3f;
        contentSettingPanel.gameObject.SetActive(true);
        contentSettingPanel.DOScale(Vector3.one, 0.3f);
    }

    public void ClosePopupSetting()
    {
        contentSettingPanel.DOScale(Vector3.zero, 0.5f).OnComplete(() => 
        {
            blackPanel.SetActive(false);
            contentSettingPanel.gameObject.SetActive(false);
        });
    }
    private void SetUp()
    {

        imgToggleMusic.sprite = SoundManager.Instance.IsMusicOn == true ? listSpriteToggle[0] : listSpriteToggle[1];
        imgToggleSound.sprite = SoundManager.Instance.IsSoundOn == true  ? listSpriteToggle[0] : listSpriteToggle[1];
        imgToggleVibration.sprite = SoundManager.Instance.IsVibrationOn == true ? listSpriteToggle[0] : listSpriteToggle[1];
        SoundManager.Instance.CheckBGM();
        SoundManager.Instance.SaveDataSetting();

    }

    void OnButtonMusic()
    {
        bool isOn = SoundManager.Instance.IsMusicOn;
        SoundManager.Instance.IsMusicOn = !isOn;
        SetUp();
    }

    void OnButtonSound()
    {
        bool isOn = SoundManager.Instance.IsSoundOn;
        SoundManager.Instance.IsSoundOn = !isOn;
        SetUp();
    }

    void OnButtonVibration()
    {
        bool isOn = SoundManager.Instance.IsVibrationOn;
        SoundManager.Instance.IsVibrationOn = !isOn;
        SetUp();
    }

}
