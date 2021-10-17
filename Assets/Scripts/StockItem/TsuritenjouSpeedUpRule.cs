using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TsuritenjouSpeedUpRule : MonoBehaviour
{
    public tsuritenjou tsuritenjou1,
                        tsuritenjou2;

    public void ItemUse(string tag)
    {
        if (tag == "Player")
        {
            tsuritenjou2.TsuritenjouSpeed += 0.1f;
        }
        else
        {
            tsuritenjou1.TsuritenjouSpeed += 0.1f;
        }

    }
}
