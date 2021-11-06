using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StealItem : MonoBehaviour
{
    Image sprite1 = null;
    Image sprite2 = null;
    StockItemPanel stockItemPanel1 = null;
    StockItemPanel stockItemPanel2 = null;

    private void Start()
    {
        sprite1 = GameObject.FindWithTag("P1ItemPanel").GetComponent<Image>();
        sprite2 = GameObject.FindWithTag("P2ItemPanel").GetComponent<Image>();
        stockItemPanel1 = sprite1.gameObject.GetComponent<StockItemPanel>();
        stockItemPanel2 = sprite2.gameObject.GetComponent<StockItemPanel>();

    }

    public void ItemUse(string tag)
    {
        if (tag == "Player")
        {
            if (stockItemPanel2.ItemName != "")
            {
                Debug.Log("1P");

                // 名前のセット
                stockItemPanel1.ItemName = stockItemPanel2.ItemName;
                stockItemPanel2.ItemName = "";

                // 画像のセット
                sprite1.sprite = sprite2.sprite;
                sprite2.sprite = null;

                // stealFlagをtrue
                stockItemPanel1.StealFlag = true;
            }
            else
            {
                stockItemPanel1.ItemName = "";
                sprite1.sprite = null;
            }
        }
        else
        {
            if (stockItemPanel1.ItemName != "")
            {
                Debug.Log("2P");
                // 名前のセット
                stockItemPanel2.ItemName = stockItemPanel1.ItemName;
                stockItemPanel1.ItemName = "";

                // 画像のセット
                sprite2.sprite = sprite1.sprite;
                sprite1.sprite = null;

                // stealFlagをtrue
                stockItemPanel2.StealFlag = true;
            }
            else
            {
                stockItemPanel2.ItemName = "";
                sprite2.sprite = null;
            }
        }
    }
}
