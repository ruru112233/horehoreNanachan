using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : CommonBlock
{
    private float holeTime = 0;

    bool drillFlag = false;

    int seCount = 0;

    string playerName = "";

    public float HoleTime
    {
        get { return holeTime; }
        set { holeTime = value; }
    }

    Animator anime;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        //if (this.transform.position.x <= 6.0f)
        //{
        //    playerName = GameObject.FindGameObjectWithTag("Player").gameObject.name;
        //}
        //else
        //{
        //    playerName = GameObject.FindGameObjectWithTag("Player2").gameObject.name;
        //}

        anime = GetComponent<Animator>();

        if (playerPos)
        {
            playerName = playerPos.gameObject.name;
        }

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
            ObjDel();
        }

        if (collision.gameObject.CompareTag("tsuritenjou"))
        {
            anime.SetTrigger("LockBreak");
            ObjDel();
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "drill")
        {
            if (collision.gameObject.name == "Player")
            {
                DrillCount(this.playerName);
            }
            else
            {
                DrillCount(this.playerName);
            }

        }


    }

    void DrillCount(string playerName)
    {
        HoleTime += Time.deltaTime;

        drillFlag = true;

        if (playerName == "Player")
        {
            if (HoleTime > 0.8f && !GameManager.instance.MutekiFlag1)
            {
                Player1DrillCount();
            }
            else if (HoleTime > 0.4f && GameManager.instance.MutekiFlag1)
            {
                Player1DrillCount();
            }
        }
        else
        {
            if (HoleTime > 0.8f && !GameManager.instance.MutekiFlag2)
            {
                Player2DrillCount();
            }
            else if (HoleTime > 0.4f && GameManager.instance.MutekiFlag2)
            {
                Player2DrillCount();
            }
        }

    }

    void Player1DrillCount()
    {
        GameManager.instance.itemCountManager.DrillCount1--;
        ObjDel();
    }

    void Player2DrillCount()
    {
        GameManager.instance.itemCountManager.DrillCount2--;
        ObjDel();
    }

    void ObjDel()
    {
        this.gameObject.SetActive(false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("drill"))
        {
            AudioManager.instance.StopSe(0);
            drillFlag = false;
        }

    }


}
