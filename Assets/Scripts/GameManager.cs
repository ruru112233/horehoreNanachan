using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int drillCount = 0;
    private int bomCount = 0;

    //public Text drillText,bomText, bomMei, kyoritext;

    public ItemCountManager itemCountManager;

    public GameObject gameOver;

    public GameObject setsumeiPanel, blockPanel;

    public GameObject ora;

    public GameObject horeru, drill, doubleDrill, bom, speedUp, speedDoun, star, ice;

    int setumeiNo = 1;

    private float tsuritenjouSpeed = 0.3f;

    private float yJiku = 0;

    bool pause = false;
    bool mutekiFlag = false;

    bool blockPanelFlag = false;

    private float mutekiTime = 0;

    GameObject player;

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

    public float TsuritenjouSpeed
    {
        get { return tsuritenjouSpeed; }
        set { tsuritenjouSpeed = value; }
    }

    public bool MutekiFlag
    {
        get { return mutekiFlag; }
        set { mutekiFlag = value; }
    }

    public float MutekiTime
    {
        get { return mutekiTime; }
        set { mutekiTime = value; }
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
        PanelClear();

        blockPanel.SetActive(false);
        setsumeiPanel.SetActive(false);
        
        if (ora != null)
        {
            ora.SetActive(false);
        }
        
        player = GameObject.FindGameObjectWithTag("Player");

        AudioManager.instance.PlayBGM(0);

    }

    // Update is called once per frame
    void Update()
    {
        //drillText.text = DrillCount.ToString();
        //bomText.text = BomCount.ToString();

        if (player != null)
        {
            YJIKU = Mathf.Abs(player.transform.position.y + 0.22f);

            //kyoritext.text = YJIKU.ToString("F2") + "m";
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

        // ドリルスピードアップ
        if (MutekiFlag)
        {
            MutekiTime += Time.deltaTime;

            if (MutekiTime >= 7.0f)
            {
                if (ora != null)
                {
                    ora.SetActive(false);
                }
                
                AudioManager.instance.PlayBGM(0);
                MutekiFlag = false;
                MutekiTime = 0;
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
