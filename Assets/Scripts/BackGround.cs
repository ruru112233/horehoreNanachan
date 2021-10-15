using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerType
{
    Player1,
    Player2,
}

public class BackGround : MonoBehaviour
{
    GameObject player;

    public PlayerType playerType;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerType.Player1 == playerType)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        else if (PlayerType.Player2 == playerType)
        {
            player = GameObject.FindGameObjectWithTag("Player2");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            transform.position = player.transform.position;

        }
    }
}
