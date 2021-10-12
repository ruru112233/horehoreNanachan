using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private float holeTime = 0;

    bool drillFlag = false;

    int seCount = 0;

    public float HoleTime
    {
        get { return holeTime; }
        set { holeTime = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (drillFlag)
        {

            if (seCount < 1)
            {

                AudioManager.instance.PlaySE(0);
            }
            seCount++;


        }
        else
        {
            //AudioManager.instance.StopSe(0);
            seCount = 0;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bom")
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "drill")
        {
            HoleTime += Time.deltaTime;

            drillFlag = true;

            if (HoleTime > 0.8f && !GameManager.instance.MutekiFlag)
            {
                GameManager.instance.DrillCount--;
                Destroy(gameObject);
            }
            else if (HoleTime > 0.4f && GameManager.instance.MutekiFlag)
            {
                GameManager.instance.DrillCount--;
                Destroy(gameObject);
            }

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "drill")
        {
            AudioManager.instance.StopSe(0);
            drillFlag = false;

        }
    }



}
