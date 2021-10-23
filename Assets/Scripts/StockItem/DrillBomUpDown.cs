using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumsScript;

public class DrillBomUpDown : MonoBehaviour
{

    public void ItemUse(string tag, string itemType, string quantityCangeType)
    {
        if (itemType == Enums.CountType.DRILL.ToString())
        {
            if (quantityCangeType == Enums.QuantityCangeType.UP.ToString())
            {
                if (tag == "Player")
                {
                    GameManager.instance.itemCountManager.DrillCount1 = DobulePoint(GameManager.instance.itemCountManager.DrillCount1);
                }
                else
                {
                    GameManager.instance.itemCountManager.DrillCount2 = DobulePoint(GameManager.instance.itemCountManager.DrillCount2);
                }
            }
            else if (quantityCangeType == Enums.QuantityCangeType.DOWN.ToString())
            {
                if (tag == "Player")
                {
                    GameManager.instance.itemCountManager.DrillCount2 = DividePoint(GameManager.instance.itemCountManager.DrillCount2);
                }
                else
                {
                    GameManager.instance.itemCountManager.DrillCount1 = DividePoint(GameManager.instance.itemCountManager.DrillCount1);
                }
            }
        }
        else if (itemType == Enums.CountType.BOM.ToString())
        {
            if (quantityCangeType == Enums.QuantityCangeType.UP.ToString())
            {
                if (tag == "Player")
                {
                    GameManager.instance.itemCountManager.BomCount1 = DobulePoint(GameManager.instance.itemCountManager.BomCount1);
                }
                else
                {
                    GameManager.instance.itemCountManager.BomCount2 = DobulePoint(GameManager.instance.itemCountManager.BomCount2);
                }
            }
            else if (quantityCangeType == Enums.QuantityCangeType.DOWN.ToString())
            {
                if (tag == "Player")
                {
                    GameManager.instance.itemCountManager.BomCount2 = DividePoint(GameManager.instance.itemCountManager.BomCount2);
                }
                else
                {
                    GameManager.instance.itemCountManager.BomCount1 = DividePoint(GameManager.instance.itemCountManager.BomCount1);
                }
            }
        }
    }

    // êîílÇ2î{Ç…Ç∑ÇÈ
    int DobulePoint(float point)
    {
        float ans = Mathf.Ceil(point * 2);
        return (int)ans;
    }

    // êîílÇîºï™Ç…Ç∑ÇÈ
    int DividePoint(float point)
    {
        float ans = Mathf.Ceil(point / 2);

        return (int)ans;
    }
}


