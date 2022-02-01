using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlineCamera : MonoBehaviour
{
    public GameObject Player;
    public bool playercheck;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playercheck == true || Player == null)
        {
            Player = GameObject.Find("Player");
        }else if(playercheck == false || Player == null)
        {
            Player = GameObject.Find("Player2");
        }
    }
}
