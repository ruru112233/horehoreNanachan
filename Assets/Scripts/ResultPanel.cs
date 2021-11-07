using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultPanel : MonoBehaviour
{
    [SerializeField] Image retryButton = null
                         , titleButton = null;

    private string resultSelectMode = "";
    private int resultSelectNum = 0;

    MasterKeyController masterKeyController;

    [SerializeField] ButtonManager buttonManager;

    // Start is called before the first frame update
    void Start()
    {
        masterKeyController = MasterKeyController.instance;
        resultSelectMode = SelectMode();
        SetSelectMode();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(masterKeyController.P1Controller().upKey))
        {
            if (resultSelectNum <= 0)
            {
                resultSelectNum = 0;
                SetSelectMode();
            }
            else
            {
                resultSelectNum--;
                SetSelectMode();
            }
        }
        else if (Input.GetKeyDown(masterKeyController.P1Controller().downKey))
        {
            if (resultSelectNum >= 1)
            {
                resultSelectNum = 1;
                SetSelectMode();
            }
            else
            {
                resultSelectNum++;
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
        resultSelectMode = SelectMode();
        DefoColor();
        SelectColorChenge();
    }

    string SelectMode()
    {
        string mode = "";

        if (resultSelectNum == 0)
        {
            mode = EnumsScript.Enums.ResultSelectMode.RETRY.ToString();
        }
        else if (resultSelectNum == 1)
        {
            mode = EnumsScript.Enums.ResultSelectMode.TITLE.ToString();
        }

        return mode;
    }

    void SelectColorChenge()
    {
        if (resultSelectMode == EnumsScript.Enums.ResultSelectMode.RETRY.ToString())
        {
            retryButton.color = masterKeyController.SelectColor;
        }
        else if (resultSelectMode == EnumsScript.Enums.ResultSelectMode.TITLE.ToString())
        {
            titleButton.color = masterKeyController.SelectColor;
        }
    }

    void DefoColor()
    {
        retryButton.color = masterKeyController.DefaultColor;
        titleButton.color = masterKeyController.DefaultColor;
    }

    void SceneSeni()
    {
        if (resultSelectMode == EnumsScript.Enums.ResultSelectMode.RETRY.ToString())
        {
            buttonManager.ReTryButton();
        }
        else if (resultSelectMode == EnumsScript.Enums.ResultSelectMode.TITLE.ToString())
        {
            buttonManager.TitleButton();
        }
    }
}
