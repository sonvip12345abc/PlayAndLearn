using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AvatarController : MonoBehaviour
{
    [SerializeField] private GameObject avatarPopup;
    [SerializeField] private GameObject blackPanel;
    [SerializeField] private RectTransform contentPopup;

    //
    [SerializeField] private Image mainAvatar;
    [SerializeField] private Image mainImagePopup;
    [SerializeField] private Text namePlayer;
    public List<Sprite> listSpriteAvatar;
    public List<Image> listBackgroundAvatar;
    public InputField inputName;
    public Text textName;
    public Button btnOpenPopUpAvatar;
    private int currentIdAvatar;

    private void Start()
    {
        inputName.onEndEdit.AddListener(OnInputFieldEndEdit);
        btnOpenPopUpAvatar.onClick.AddListener(ActiveAvatarPopup);
        namePlayer.text = DataController.Instance.NamePlayer;
        this.textName.text = DataController.Instance.NamePlayer;
        this.inputName.text = DataController.Instance.NamePlayer;
        currentIdAvatar = DataController.Instance.IdAvatar;
        SwitchAvatar(currentIdAvatar);

    }
    void OnInputFieldEndEdit(string text)
    {

        string stringTextName = textName.text;
        this.textName.text = stringTextName;
        this.inputName.text = stringTextName;
        namePlayer.text = stringTextName;
        DataController.Instance.NamePlayer = stringTextName;
    }

    void ActiveAvatarPopup()
    {
        avatarPopup.SetActive(true);
        blackPanel.SetActive(true);
        contentPopup.localScale = Vector3.one * 0.3f;
        contentPopup.gameObject.SetActive(true);
        contentPopup.DOScale(Vector3.one, 0.3f);  
    }

    public void DeActiveAvatarPopup()
    {
        contentPopup.DOScale(Vector3.zero, 0.25f).OnComplete(() => 
        {
            contentPopup.gameObject.SetActive(false);
            blackPanel.SetActive(false);
            avatarPopup.SetActive(false);
        });
    }


    public void SwitchAvatar(int indexAvatar)
    {
        currentIdAvatar = indexAvatar;
        DataController.Instance.IdAvatar = indexAvatar;
        mainAvatar.sprite = listSpriteAvatar[indexAvatar];
        mainImagePopup.sprite = listSpriteAvatar[indexAvatar];
        DeactiveAllBackgroundAvatar();
        listBackgroundAvatar[indexAvatar].color = Color.green;

    }

    public void DeactiveAllBackgroundAvatar()
    {
        foreach(var item in listBackgroundAvatar)
        {
            item.color = Color.white;
        }
    }
}
