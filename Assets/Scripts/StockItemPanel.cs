using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockItemPanel : MonoBehaviour
{
 
    private string itemName = "";

    public string ItemName
    {
        get { return itemName; }
        set { itemName = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(ItemName);
    }
}
