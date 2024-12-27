using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TestSubmitText : MonoBehaviour
{
    public InputField inputField;
    public Text text1;
    public Button btnSubmit;

    public int correctResult = 10;

    void Start()
    {
        inputField.onEndEdit.AddListener(OnInputFieldEndEdit);
        btnSubmit.onClick.AddListener(Submit);
    }

    void OnInputFieldEndEdit(string text)
    {
        Debug.Log(text);
        string textInput = text1.text;
        this.text1.text = textInput;
        this.inputField.text = textInput;
    }

    void Submit()
    {
        string result = inputField.text.Replace(" ", "");
        int resultInput = int.Parse(result);
        if (correctResult == resultInput)
        {
            Debug.Log("dung");
        }
        else
        {
            Debug.Log("sai");
        }
    }
    


}
