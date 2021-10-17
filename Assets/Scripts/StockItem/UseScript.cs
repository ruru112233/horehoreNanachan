using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseScript : MonoBehaviour
{
    public TsuritenjouSpeedUpRule tsuritenjouSpeedUpRule;

    public void ItemUseSelect(string type, string tag)
    {
        switch (type)
        {
            case "SPEEDUP":
                tsuritenjouSpeedUpRule.ItemUse(tag);
                break;
        }
    }

}
