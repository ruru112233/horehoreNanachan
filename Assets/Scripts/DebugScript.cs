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
    float chengeTime = 0.01f; // 画像を切り替える時間
    float plusTime = 0.01f; // changeTimeの+する数値
    int changeCount = 0;  // 画像をチェンジした回数
    int spriteCount = 20; // 画像を切り替える回数


    // アイテムボックスにアイテムが格納される

    public void SetItemBox()
    {
        // imageを取得
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

    // 一定時間毎に画像をセットする
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


    // ランダムでセットする画像を返す
    //Sprite RandSprite()
    //{
    //    int num = CalcScript.RandInt(0, 5);

    //    return stockItemManager.selectItemSpriteList[num];
    //}

}
