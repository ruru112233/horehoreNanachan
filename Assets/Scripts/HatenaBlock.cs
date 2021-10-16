using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HatenaBlock : MonoBehaviour
{
    [SerializeField] StockItemManager stockItemManager;

    Image sprite;

    bool selectItemFlag = false;

    float startTime = 0;
    float chengeTime = 0.01f; // �摜��؂�ւ��鎞��
    float plusTime = 0.01f; // changeTime��+���鐔�l
    int changeCount = 0;  // �摜���`�F���W������
    int spriteCount = 20; // �摜��؂�ւ����

    public enum PlayerType
    {
        PLAYER_1,
        PLAYER_2,
    } 

    public PlayerType playerType;

    private void Start()
    {
        stockItemManager = GameObject.FindWithTag("StockItemManager").GetComponent<StockItemManager>();
    }


    private void Update()
    {
        if (selectItemFlag)
        {
            if (changeCount > spriteCount)
            {
                selectItemFlag = false;
                return;
            }
            SetTimeSprite(sprite);
        }
    }


    // �A�C�e���{�b�N�X�ɃA�C�e�����i�[�����
    public void SetItemBox()
    {
        
        // image���擾
        if (PlayerType.PLAYER_1 == playerType)
        {
            Debug.Log("�A�C�e��");
            sprite = GameObject.FindWithTag("P1ItemPanel").GetComponent<Image>();
        }
        else
        {
            sprite = GameObject.FindWithTag("P2ItemPanel").GetComponent<Image>();
        }


        changeCount = 0;
        chengeTime = 0.01f;
        selectItemFlag = true;
    }

    // ��莞�Ԗ��ɉ摜���Z�b�g����
    void SetTimeSprite(Image sprite)
    {
        startTime += Time.deltaTime;

        if (startTime > chengeTime)
        {
            startTime = 0;
            changeCount++;
            chengeTime += plusTime;
            sprite.sprite = RandSprite();
        }
    }


    // �����_���ŃZ�b�g����摜��Ԃ�
    Sprite RandSprite()
    {
        int num = CalcScript.RandInt(0, 5);

        return stockItemManager.selectItemSpriteList[num];
    }
}
