using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectNameAndAvatar : MonoBehaviour
{
   [SerializeField] private Image mainAvatar;
   [SerializeField] private Button btnHome;
   [SerializeField] private GameObject effectEndScene;

    public List<Sprite> listSpriteAvatar;
    public List<Image> listBackgroundAvatar;
    public InputField inputName;
    public Text textName;
    private int currentIdAvatar;

    

    private void Start()
    {
        inputName.onEndEdit.AddListener(OnInputFieldEndEdit);
        btnHome.onClick.AddListener(GoHome);
        this.textName.text = DataController.Instance.NamePlayer;
        this.inputName.text = DataController.Instance.NamePlayer;
        currentIdAvatar = DataController.Instance.IdAvatar;
        SwitchAvatar(0);

    }
    void OnInputFieldEndEdit(string text)
    {

        string stringTextName = textName.text;
        this.textName.text = stringTextName;
        this.inputName.text = stringTextName;
        DataController.Instance.NamePlayer = stringTextName;
    }


    private void GoHome()
    {
        StartCoroutine(startGOHome());
    }

    IEnumerator startGOHome()
    {
        effectEndScene.SetActive(true);    
        yield return new WaitForSeconds(0.75f);
        GameStateController.Instance.currentGameState = GameState.Home;
        SceneController.Instance.LoadScene("Home");
    }

    public void SwitchAvatar(int indexAvatar)
    {
        currentIdAvatar = indexAvatar;
        DataController.Instance.IdAvatar = indexAvatar;
        mainAvatar.sprite = listSpriteAvatar[indexAvatar];
       
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
