using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTitle : MonoBehaviour
{
    MasterKeyController masterKeyController;

    MasterKeyController.KeyData keyData;

    // Start is called before the first frame update
    void Start()
    {
        masterKeyController = GameObject.FindWithTag("MasterController").GetComponent<MasterKeyController>();
        keyData = masterKeyController.P1Controller();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyData.upKey))
        {
            Debug.Log("è„Ç™ì¸óÕÇ≥ÇÍÇΩ");
        }

        
    }
}
