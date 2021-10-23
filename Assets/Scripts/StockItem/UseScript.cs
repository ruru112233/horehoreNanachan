using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseScript : MonoBehaviour
{
    public TsuritenjouSpeedUpRule tsuritenjouSpeedUpRule;
    public StealItem stealItem;
    public DrillBomUpDown drillBomUpDown;

    public void ItemUseSelect(string type, string tag, string quantityCangeType)
    {
        switch (type)
        {
            case "SPEEDUP":
                tsuritenjouSpeedUpRule.ItemUse(tag);
                break;
            case "STEAL":
                stealItem.ItemUse(tag);
                break;
            case "DRILL":
                drillBomUpDown.ItemUse(tag, type, quantityCangeType);
                break;
            case "BOM":
                drillBomUpDown.ItemUse(tag, type, quantityCangeType);
                break;
        }
    }

}
