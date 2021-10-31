using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockItemPanel : MonoBehaviour
{
 
    private string itemName = "";
    private string quantityCange = "";

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

    private void Update()
    {
        Debug.Log("ItemName:" + ItemName);
        Debug.Log("QuantityCange:" + QuantityCange);
    }

}
