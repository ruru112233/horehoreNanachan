using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopScript : MonoBehaviour
{

    float stopTime = 2.0f;
    float player1StopTime = 0
        , player2StopTime = 0;

    private void Update()
    {

        if (GameManager.instance.player1Stop)
        {
            player1StopTime += Time.deltaTime;
            if (player1StopTime > stopTime)
            {
                player1StopTime = 0;
                GameManager.instance.player1Stop = false;
            }
        }

        if (GameManager.instance.player2Stop)
        {
            player2StopTime += Time.deltaTime;
            if (player2StopTime > stopTime)
            {
                player2StopTime = 0;
                GameManager.instance.player2Stop = false;
            }
        }
    }

    public void ItemUse(string tag)
    {
        if (tag == "Player")
        {
            GameManager.instance.player2Stop = true;
        }
        else
        {
            GameManager.instance.player1Stop = true;   
        }
    }


}


