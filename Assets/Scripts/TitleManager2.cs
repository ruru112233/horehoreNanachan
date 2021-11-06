using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager2 : MonoBehaviour
{
    [SerializeField] Image p1Button = null
                         , p2Button = null
                         , optionButton = null;

    private string selectMode = "";
    private int selectNum = 0;

    MasterKeyController masterKeyController;

    [SerializeField] ButtonManager buttonManager;

    // Start is called before the first frame update
    void Start()
    {
        masterKeyController = MasterKeyController.instance;
        selectMode = SelectMode();
        SetSelectMode();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(masterKeyController.P1Controller().upKey))
        {
            if (selectNum <= 0)
            {
                selectNum = 0;
                SetSelectMode();
            }
            else
            {
                selectNum--;
                SetSelectMode();
            }
        }
        else if (Input.GetKeyDown(masterKeyController.P1Controller().downKey))
        {
            if (selectNum >= 2)
            {
                selectNum = 2;
                SetSelectMode();
            }
            else
            {
                selectNum++;
                SetSelectMode();
            }
        }

        if (Input.GetKeyDown(masterKeyController.P1Controller().startKey))
        {
            SceneSeni();
        }

    }

    void SetSelectMode()
    {
        selectMode = SelectMode();
        DefoColor();
        SelectColorChenge();
    }

    string SelectMode()
    {
        string mode = "";

        if (selectNum == 0)
        {
            mode = EnumsScript.Enums.SelectMode.P1BUTTON.ToString();
        }
        else if(selectNum == 1)
        {
            mode = EnumsScript.Enums.SelectMode.P2BUTTON.ToString();
        }
        else if(selectNum == 2)
        {
            mode = EnumsScript.Enums.SelectMode.OPTION.ToString();
        }

        return mode;
    }

    void SelectColorChenge()
    {
        if (selectMode == EnumsScript.Enums.SelectMode.P1BUTTON.ToString())
        {
            p1Button.color = Color.blue;
        }
        else if (selectMode == EnumsScript.Enums.SelectMode.P2BUTTON.ToString())
        {
            p2Button.color = Color.blue;
        }
        else if (selectMode == EnumsScript.Enums.SelectMode.OPTION.ToString())
        {
            optionButton.color = Color.blue;
        }
    }

    void DefoColor()
    {
        p1Button.color = Color.white;
        p2Button.color = Color.white;
        optionButton.color = Color.white;
    }

    void SceneSeni()
    {
        if (selectMode == EnumsScript.Enums.SelectMode.P1BUTTON.ToString())
        {
            buttonManager.P1PlayButton();
        }
        else if (selectMode == EnumsScript.Enums.SelectMode.P2BUTTON.ToString())
        {
            buttonManager.P2PlayButton();
        }
        else if (selectMode == EnumsScript.Enums.SelectMode.OPTION.ToString())
        {
            
        }
    }
}
