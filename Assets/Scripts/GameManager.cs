using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using SelectItem;

public class GameManager : MonoBehaviour
{
    private int drillCount = 0;
    private int bomCount = 0;

    public Text kyoritext;

    public bool player1Stop = false
              , player2Stop = false;

    public ItemCountManager itemCountManager;

    public GameObject gameOver
                    , p1Win
                    , p2Win;

    private bool gameOverFlag = false;

    public GameObject setsumeiPanel, blockPanel;

    public GameObject ora1,ora2;

    public GameObject horeru, drill, doubleDrill, bom, speedUp, speedDoun, star, ice;

    public StopScript stopScript;

    public Sprite groundSprite;

    public GameObject resultPanel;

    int setumeiNo = 1;

    //private float tsuritenjouSpeed = 0.3f;

    private float yJiku = 0;

    bool pause = false;
    bool mutekiFlag1 = false
       , mutekiFlag2 = false;

    bool blockPanelFlag = false;

    private float mutekiTime1 = 0
                , mutekiTime2 = 0;

    GameObject player;

    public bool p1ChangeFlag = false
              , p2ChangeFlag = false;

    public Color textGray = new Color(0.5f, 0.5f, 0.5f, 1);
    public Color textWhite = new Color(1, 1, 1, 1);

    public int DrillCount
    {
        get { return drillCount; }
        set { drillCount = value; }
    }

    public int BomCount
    {
        get { return bomCount; }
        set { bomCount = value; }
    }

    public float YJIKU
    {
        get { return yJiku; }
        set { yJiku = value; }
    }

    //public float TsuritenjouSpeed
    //{
    //    get { return tsuritenjouSpeed; }
    //    set { tsuritenjouSpeed = value; }
    //}

    public bool MutekiFlag1
    {
        get { return mutekiFlag1; }
        set { mutekiFlag1 = value; }
    }

    public bool MutekiFlag2
    {
        get { return mutekiFlag2; }
        set { mutekiFlag2 = value; }
    }

    public float MutekiTime1
    {
        get { return mutekiTime1; }
        set { mutekiTime1 = value; }
    }

    public float MutekiTime2
    {
        get { return mutekiTime2; }
        set { mutekiTime2 = value; }
    }

    public bool GameOverFlag
    {
        get { return gameOverFlag; }
        set { gameOverFlag = value; }
    }

    public static GameManager instance;

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
        DrillCount = 20;
        BomCount = 3;

        gameOver.SetActive(false);
        if(p1Win) p1Win.SetActive(false);
        if(p2Win) p2Win.SetActive(false);
        PanelClear();

        blockPanel.SetActive(false);
        setsumeiPanel.SetActive(false);

        GameOverFlag = false;

        if (ora1) ora1.SetActive(false);
        if (ora2) ora2.SetActive(false);

        if (resultPanel) resultPanel.SetActive(false);

        player = GameObject.FindGameObjectWithTag("Player");

        if (MasterData.playerMode == EnumsScript.Enums.PlayerMode.P1PLAY.ToString())
        {
            AudioManager.instance.PlayBGM(3);
        }
        else
        {
            AudioManager.instance.PlayBGM(4);
        }

        

    }

    // Update is called once per frame
    void Update()
    {

        if (player != null)
        {
            YJIKU = Mathf.Abs(player.transform.position.y + 0.21f);

            if(kyoritext) kyoritext.text = YJIKU.ToString("F2") + "m";
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (!pause)
            {
                Time.timeScale = 0;
                pause = true;
                setsumeiPanel.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                pause = false;
                blockPanel.SetActive(false);
                setsumeiPanel.SetActive(false);
            }
            
        }

        if (pause)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                blockPanelFlag = !blockPanelFlag;

                if (blockPanelFlag)
                {
                    blockPanel.SetActive(true);
                }
                else
                {
                    blockPanel.SetActive(false);
                }
            }
        }

        // プレイヤー１のドリルスピードアップ
        if (MutekiFlag1)
        {
            MutekiTime1 += Time.deltaTime;

            if (MutekiTime1 >= 7.0f)
            {
                if (ora1 != null) ora1.SetActive(false);
                
                //AudioManager.instance.PlayBGM(0);
                MutekiFlag1 = false;
                MutekiTime1 = 0;
            }

        }

        // プレイヤー２のドリルスピードアップ
        if (MutekiFlag2)
        {
            MutekiTime2 += Time.deltaTime;

            if (MutekiTime2 >= 7.0f)
            {
                if (ora2 != null) ora2.SetActive(false);

                //AudioManager.instance.PlayBGM(0);
                MutekiFlag2 = false;
                MutekiTime2 = 0;
            }

        }

        // リスタート
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!pause)
            {
                SceneManager.LoadScene("MainScene");
            }

        }

        if (pause)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (setumeiNo < 8)
                {
                    setumeiNo++;
                }

            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (setumeiNo > 1)
                {
                    setumeiNo--;
                }
            }
        }

        PanelSelect(setumeiNo);

    }

    void PanelSelect(int panelNo)
    {
        switch (panelNo)
        {
            case 1:
                PanelClear();
                horeru.SetActive(true);
                break;
            case 2:
                PanelClear();
                drill.SetActive(true);
                break;
            case 3:
                PanelClear();
                doubleDrill.SetActive(true);
                break;
            case 4:
                PanelClear();
                bom.SetActive(true);
                break;
            case 5:
                PanelClear();
                speedUp.SetActive(true);
                break;
            case 6:
                PanelClear();
                speedDoun.SetActive(true);
                break;
            case 7:
                PanelClear();
                star.SetActive(true);
                break;
            case 8:
                PanelClear();
                ice.SetActive(true);
                break;
        }
    }


    void PanelClear()
    {
        horeru.SetActive(false);
        drill.SetActive(false);
        doubleDrill.SetActive(false);
        bom.SetActive(false);
        speedUp.SetActive(false);
        speedDoun.SetActive(false);
        star.SetActive(false);
        ice.SetActive(false);
    }
}
