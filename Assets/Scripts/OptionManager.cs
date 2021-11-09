using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour
{
    [SerializeField] Slider bgmSlider = null
                          , seSlider = null;

    [SerializeField] Image bgmBackImage = null
                         , seBackImage = null
                         , miniMapBackImage = null
                         , optionCloseButton = null;

    [SerializeField] GameObject checkMark = null;

    private bool miniMapCheckFlag = false;

    private int optionSelectNum = 0; // 0:BGMの音量調整、1:SEの音量調整、2:ミニマップのチェックボックス

    public int OptionSelectNum
    {
        get { return optionSelectNum; }
        set { optionSelectNum = value; }
    }

    int bgmVolumeInit = 3
      , seVoluumeInt = 3;

    float setBgmVol = 0.5f
        , setSeVol = 0.5f;

    [SerializeField] MasterKeyController masterController;
    [SerializeField] ButtonManager buttonManager;

    // Start is called before the first frame update
    void Start()
    {
        SetVolume();
    }

    void SetVolume()
    {
        bgmSlider.normalizedValue = bgmVolumeInit;
        seSlider.normalizedValue = seVoluumeInt;

        SetBgmAndSe();
    }

    // Update is called once per frame
    void Update()
    {
        SetBgmAndSe();
        OptionSelectChange();
        CheckMarkOnOff();
    }

    void SetBgmAndSe()
    {
        AudioManager.instance.BgmSliderVolume(bgmSlider.normalizedValue);
        AudioManager.instance.SeSliderVolume(seSlider.normalizedValue);

        SelectColor();
    }

    void OptionSelectChange()
    {

        setBgmVol = bgmVolumeInit / 5.0f;
        BgmSliderChenge(setBgmVol);

        setSeVol = seVoluumeInt / 5.0f;
        SeSliderChenge(setSeVol);

        if (TitleManager2.instance.OptionFlag)
        {
            if (Input.GetKeyDown(masterController.upP1Key))
            {
                if (OptionSelectNum > 0)
                {
                    OptionSelectNum--;
                }
                else
                {
                    OptionSelectNum = 0;
                }

            }
            else if (Input.GetKeyDown(masterController.downP1Key))
            {
                if (OptionSelectNum < 3)
                {
                    OptionSelectNum++;
                }
                else
                {
                    OptionSelectNum = 3;
                }
            }

            ChengeVolume();
        }
        
    }

    void SelectColor()
    {
        switch (OptionSelectNum)
        {
            case 0:
                ColorCrear();
                bgmBackImage.color = masterController.SelectColor;
                break;
            case 1:
                ColorCrear();
                seBackImage.color = masterController.SelectColor;
                break;
            case 2:
                ColorCrear();
                miniMapBackImage.color = masterController.SelectColor;
                if (Input.GetKeyDown(masterController.startP1Key))
                {
                    AudioManager.instance.PlaySE(3);
                    miniMapCheckFlag = !miniMapCheckFlag;
                    MasterData.miniMapFlag = this.miniMapCheckFlag;
                }
                break;
            case 3:
                ColorCrear();
                optionCloseButton.color = masterController.SelectColor;
                if (Input.GetKeyDown(masterController.startP1Key))
                {
                    buttonManager.OptionOff();
                }
                break;

        }
    }

    void ChengeVolume()
    {
        if (OptionSelectNum == 0)
        {   
            if (Input.GetKeyDown(masterController.leftP1Key))
            {
                if (bgmVolumeInit > 0)
                {
                    AudioManager.instance.PlaySE(3);
                    bgmVolumeInit--;
                }
                else
                {
                    bgmVolumeInit = 0;
                }
            }
            else if (Input.GetKeyDown(masterController.rightP1Key))
            {
                if (bgmVolumeInit < 5)
                {
                    AudioManager.instance.PlaySE(3);
                    bgmVolumeInit++;
                }
                else
                {
                    bgmVolumeInit = 5;
                }
            }

        }
        else if (OptionSelectNum == 1)
        {
            if (Input.GetKeyDown(masterController.leftP1Key))
            {
                if (seVoluumeInt > 0)
                {
                    AudioManager.instance.PlaySE(3);
                    seVoluumeInt--;
                }
                else
                {
                    seVoluumeInt = 0;
                }
            }
            else if (Input.GetKeyDown(masterController.rightP1Key))
            {
                if (seVoluumeInt < 5)
                {
                    AudioManager.instance.PlaySE(3);
                    seVoluumeInt++;
                }
                else
                {
                    seVoluumeInt = 5;
                }
            }

        }

        //SetBgmAndSe();
    }

    void CheckMarkOnOff()
    {
        if (miniMapCheckFlag)
        {
            checkMark.SetActive(true);
        }
        else
        {
            checkMark.SetActive(false);
        }
    }


    void BgmSliderChenge(float volume)
    {
        bgmSlider.normalizedValue = volume;
    }

    void SeSliderChenge(float volume)
    {
        seSlider.normalizedValue = volume;
    }

    void ColorCrear()
    {
        bgmBackImage.color = masterController.TransparntColor;
        seBackImage.color = masterController.TransparntColor;
        miniMapBackImage.color = masterController.TransparntColor;
        optionCloseButton.color = masterController.DefaultColor;
    }

}
