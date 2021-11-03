using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonBlock : MonoBehaviour
{
    protected Transform playerPos;

    // Start is called before the first frame update
    public virtual void Start()
    {
        if (this.transform.position.x <= 6.0f)
        {
            if (GameObject.FindGameObjectWithTag("Player"))
            {
                playerPos = GameObject.FindGameObjectWithTag("Player").transform;
            }
        }
        else
        {
            if (GameObject.FindGameObjectWithTag("Player2"))
            {
                playerPos = GameObject.FindGameObjectWithTag("Player2").transform;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

}
