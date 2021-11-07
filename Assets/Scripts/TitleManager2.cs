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

    public GameObject optionPanel = null;

    private string selectMode = "";
    private int selectNum = 0;

    public int SelectNum
    {
        set { selectNum = value; }
    }

    private bool optionFlag = false;

    public bool OptionFlag
    {
        get { return optionFlag; }
        set { optionFlag = value; }
    }

    MasterKeyController masterKeyController;

    [SerializeField] ButtonManager buttonManager;

    public static TitleManager2 instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        masterKeyController = MasterKeyController.instance;
        selectMode = SelectMode();
        SetSelectMode();
        optionPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!optionFlag)
        {
            if (Input.GetKeyDown(masterKeyController.P1Controller().upKey))
            {
                if (selectNum <= 0)
                {
                    selectNum = 0;
                }
                else
                {
                    selectNum--;
                }
            }
            else if (Input.GetKeyDown(masterKeyController.P1Controller().downKey))
            {
                if (selectNum >= 2)
                {
                    selectNum = 2;
                }
                else
                {
                    selectNum++;
                }
            }
            if (Input.GetKeyDown(masterKeyController.P1Controller().startKey))
            {
                SceneSeni();
            }
        }
        
        SetSelectMode();

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

        Debug.Log("mode>>" + mode);

        return mode;
    }

    void SelectColorChenge()
    {
        if (selectMode == EnumsScript.Enums.SelectMode.P1BUTTON.ToString())
        {
            p1Button.color = masterKeyController.SelectColor;
        }
        else if (selectMode == EnumsScript.Enums.SelectMode.P2BUTTON.ToString())
        {
            p2Button.color = masterKeyController.SelectColor;
        }
        else if (selectMode == EnumsScript.Enums.SelectMode.OPTION.ToString())
        {
            optionButton.color = masterKeyController.SelectColor;
        }
    }

    void DefoColor()
    {
        p1Button.color = masterKeyController.DefaultColor;
        p2Button.color = masterKeyController.DefaultColor;
        optionButton.color = masterKeyController.DefaultColor;
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
            buttonManager.OptionButton();
        }
    }
}
