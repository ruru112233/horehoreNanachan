using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCountManager : MonoBehaviour
{
    public Text drillCountText1
              , drillCountText2
              , bomCountText1
              , bomCountText2
              , bomMeiText1
              , bomMeiText2;

    private int drillCount1 = 21
              , drillCount2 = 21;
    private int bomCount1 = 3
              , bomCount2 = 3;

    public int DrillCount1
    {
        get { return drillCount1; }
        set { drillCount1 = value; }
    }

    public int DrillCount2
    {
        get { return drillCount2; }
        set { drillCount2 = value; }
    }

    public int BomCount1
    {
        get { return bomCount1; }
        set { bomCount1 = value; }
    }

    public int BomCount2
    {
        get { return bomCount2; }
        set { bomCount2 = value; }
    }

    private void Start()
    {
        CounterView();
    }

    private void Update()
    {
        CounterView();
    }

    // ドリル数とボム数をテキストに反映
    void CounterView()
    {
        if (DrillCount1 < 0)
        {
            DrillCount1 = 0;
        }

        if (DrillCount2 < 0)
        {
            DrillCount2 = 0;
        }

        // ドリル数の反映
        if (drillCountText1) drillCountText1.text = DrillCount1.ToString();
        if (drillCountText2) drillCountText2.text = DrillCount2.ToString();

        // ボム数の反映
        if (bomCountText1) bomCountText1.text = BomCount1.ToString();
        if (bomCountText2) bomCountText2.text = BomCount2.ToString();
    }



}
