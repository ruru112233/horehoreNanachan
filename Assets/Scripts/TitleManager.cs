using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public GameObject setsumeiPanel, blockPanel;

    bool setumeiFlag = false;
    bool blockPanelFlag = false;

    int setumeiNo = 1;

    public GameObject horeru, drill, doubleDrill, bom, speedUp, speedDoun, star, ice;

    // Start is called before the first frame update
    void Start()
    {
        blockPanel.SetActive(false);
        setsumeiPanel.SetActive(false);

        PanelClear();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (!setumeiFlag)
            {
                setsumeiPanel.SetActive(true);
                setumeiFlag = true;
            }
            else
            {
                setsumeiPanel.SetActive(false);
                setumeiFlag = false;
                blockPanelFlag = false;
            }
        }

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

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!setumeiFlag)
            {
                SceneManager.LoadScene("MainScene");
            }

        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            if (!setumeiFlag)
            {
                SceneManager.LoadScene("NetMainScene");
            }
        }

        if (setumeiFlag)
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
