using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockItemPanel : MonoBehaviour
{

    private string itemName = "";
    private string quantityCange = "";
    private bool stealFlag = false;

    public string ItemName
    {
        get { return itemName; }
        set { itemName = value; }
    }

    public string QuantityCange
    {
        get { return quantityCange; }
        set { quantityCange = value; }
    }

    public bool StealFlag
    {
        get { return stealFlag; }
        set { stealFlag = value; }
    }

}
