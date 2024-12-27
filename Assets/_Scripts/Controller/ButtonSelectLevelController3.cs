using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSelectLevelController3 : MonoBehaviour
{
    [SerializeField] List<Button> listButtonLevels;

    private void OnEnable()
    {
        SetUpButtons();

    }

    void SetUpButtons()
    {
        int currentLevelLock = DataController.Instance.DataGrade3;
        DeActivateAllButton();
        for (int i = 0; i <= currentLevelLock; i++)
        {
            int ii = i;
            listButtonLevels[ii].interactable = true;
        }
    }

    void DeActivateAllButton()
    {
        for (int i = 0; i < listButtonLevels.Count; i++)
        {
            int ii = i;
            listButtonLevels[ii].interactable = false;
        }
    }
}
