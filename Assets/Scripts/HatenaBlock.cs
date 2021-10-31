using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EnumsScript;

public class HatenaBlock : MonoBehaviour
{
    StockItemManager stockItemManager;
    StockItemPanel stockItemPanel;

    Image sprite;

    bool selectItemFlag = false;

    float startTime = 0;
    float chengeTime = 0.01f; // 画像を切り替える時間
    float plusTime = 0.01f; // changeTimeの+する数値
    int changeCount = 0;  // 画像をチェンジした回数
    int spriteCount = 20; // 画像を切り替える回数


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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            stockItemPanel = GameObject.FindWithTag("P1ItemPanel").GetComponent<StockItemPanel>();
            sprite = GameObject.FindWithTag("P1ItemPanel").GetComponent<Image>();

        }
        else if(collision.gameObject.CompareTag("Player2"))
        {
            stockItemPanel = GameObject.FindWithTag("P2ItemPanel").GetComponent<StockItemPanel>();
            sprite = GameObject.FindWithTag("P2ItemPanel").GetComponent<Image>();
        }
    }


    private void Update()
    {
        if (selectItemFlag)
        {
            if (changeCount > spriteCount)
            {
                selectItemFlag = false;
                string itemName = sprite.sprite.name;
                Debug.Log(itemName);
                stockItemPanel.ItemName = ItemTypeString(itemName);
                stockItemPanel.QuantityCange = QuantityCange(itemName);

                return;
            }
            SetTimeSprite(sprite);
        }
    }


    // アイテムボックスにアイテムが格納される
    public void SetItemBox()
    {
        changeCount = 0;
        chengeTime = 0.01f;
        selectItemFlag = true;
    }

    // 一定時間毎に画像をセットする
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


    // ランダムでセットする画像を返す
    Sprite RandSprite()
    {
        int num = CalcScript.RandInt(0, 5);

        return stockItemManager.selectItemSpriteList[num];
    }

    // 最終的にセットされるアイテムの文字列を返す
    string ItemTypeString(string itemName)
    {
        string itemType = null;

        switch (itemType)
        {
            case "items-speed":
                itemType = Enums.HtenaItemType.SPEEDUP.ToString();
                break;
            case "items-ubau":
                itemType = Enums.HtenaItemType.STEAL.ToString();
                break;
            case "items-drillhueru":
            case "items-drillheru":
                itemType = Enums.HtenaItemType.DRILL.ToString();
                break;
            case "items-bakudanhueru":
            case "items-bakudanheru":
                itemType = Enums.HtenaItemType.BOM.ToString();
                break;
            case "items-kaeru":
                itemType = Enums.HtenaItemType.BLOCKCHANGE.ToString();
                break;
            case "items-sousa":
                itemType = Enums.HtenaItemType.NOPLAY.ToString();
                break;
        }

        return itemType;
    }

    // ドリルかボムの場合、２倍にするか半分にするかを返す
    string QuantityCange(string itemName)
    {
        string quantityCange = "";

        switch (itemName)
        {
            case "items-drillhueru":
            case "items-bakudanhueru":
                Enums.QuantityCangeType.UP.ToString();
                break;
            case "items-drillheru":
            case "items-bakudanheru":
                Enums.QuantityCangeType.DOWN.ToString();
                break;
        }

        return quantityCange;
    }
}
