using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugScript : MonoBehaviour
{
    //[SerializeField] StockItemManager stockItemManager;

    [SerializeField] StockItemPanel stockItemPanel;

    [SerializeField] Text text1, text2;

    Image sprite;

    bool selectItemFlag = false;

    float startTime = 0; 
    float chengeTime = 0.01f; // �摜��؂�ւ��鎞��
    float plusTime = 0.01f; // changeTime��+���鐔�l
    int changeCount = 0;  // �摜���`�F���W������
    int spriteCount = 20; // �摜��؂�ւ����


    // �A�C�e���{�b�N�X�ɃA�C�e�����i�[�����

    public void SetItemBox()
    {
        // image���擾
        //sprite = GameObject.FindWithTag("P1ItemPanel").GetComponent<Image>();

        //changeCount = 0;
        //chengeTime = 0.01f;
        //selectItemFlag = true;
    }

    private void Update()
    {
        text1.text = "ItemName:" + stockItemPanel.ItemName;
        text2.text = "QuantityCange" + stockItemPanel.QuantityCange;
        //if (selectItemFlag)
        //{
        //    if (changeCount > spriteCount)
        //    {
        //        selectItemFlag = false;
        //        return;
        //    }
        //    SetTimeSprite(sprite);
        //}
    }

    // ��莞�Ԗ��ɉ摜���Z�b�g����
    //void SetTimeSprite(Image sprite)
    //{
    //    startTime += Time.deltaTime;

    //    if (startTime > chengeTime)
    //    {
    //        startTime = 0;
    //        changeCount++;
    //        chengeTime += plusTime;
    //        sprite.sprite = RandSprite();
    //    }
    //}


    // �����_���ŃZ�b�g����摜��Ԃ�
    //Sprite RandSprite()
    //{
    //    int num = CalcScript.RandInt(0, 5);

    //    return stockItemManager.selectItemSpriteList[num];
    //}

}
