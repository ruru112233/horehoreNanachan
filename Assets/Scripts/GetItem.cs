using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumsScript;

public class GetItem : CommonBlock
{
    [SerializeField] HatenaBlock hatenaBlock;

    //[SerializeField] Sprite groundSprite;

    public Enums.ITEM item;

    private string changeTarget;

    public string ChangeTarget
    {
        get { return changeTarget; }
        set { changeTarget = value; }
    }

    float playerDistance = 0;
    float maxDistance = 4;


    private TsuritenjouSpeedUpRule tsuritenjou;

    public override void Start()
    {
        base.Start();

        //if(MasterData.playerMode == "P2PLAY")
        //{
            tsuritenjou = GameObject.FindWithTag("UseManager").GetComponent<TsuritenjouSpeedUpRule>();
        //}
    }

    private void Update()
    {
        if (playerPos != null)
        {
            playerDistance = DistanceValue(this.gameObject.transform.position, playerPos.position);
        }

        if (playerDistance < maxDistance && playerDistance > 1)
        {
            //this.gameObject.GetComponent<SpriteRenderer>().color = Color.black;
            ChangeTarget = Enums.ChangeTarget.TAGET.ToString();
        }
        else if (ChangeTarget == "TAGET")
        {
            //this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            ChangeTarget = Enums.ChangeTarget.NONE.ToString();
        }

        if (GameManager.instance.p1ChangeFlag)
        {
            if (ChangeTarget == "TAGET" && playerPos.gameObject.name == "Player2")
            {
                ChangeNomalBlock();
            }
        }

        if (GameManager.instance.p2ChangeFlag)
        {
            if (changeTarget == "TAGET" && playerPos.gameObject.name == "Player")
            {
                ChangeNomalBlock();
            }
        }
    }

    // ノーマルブロックにチェンジする
    void ChangeNomalBlock()
    {

        SpriteRenderer spriteRenderer = this.GetComponent<SpriteRenderer>();

        spriteRenderer.sprite = GameManager.instance.groundSprite;
        spriteRenderer.color = Color.white;

        this.gameObject.transform.localScale = new Vector3(1, 1, 1);

        foreach (Transform child in this.gameObject.transform)
        {
            child.gameObject.SetActive(false);
        }

        BoxCollider2D boxCollider = this.GetComponent<BoxCollider2D>();
        boxCollider.isTrigger = false;
        boxCollider.offset = new Vector2(0, 0);
        boxCollider.size = new Vector2(1.0f, 1.0f);

        this.gameObject.AddComponent<Block>();

        GetItem getItem = this.GetComponent<GetItem>();
        getItem.enabled = false;
    }

    float DistanceValue(Vector3 pos1, Vector3 pos2)
    {
        float a = Mathf.Abs(pos1.y);
        float b = Mathf.Abs(pos2.y);

        float ans = a - b;

        return ans;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("tsuritenjou"))
        {
            ObjDel();
        }

        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Player2")
        {
            AudioManager.instance.PlaySE(2);

            if (Enums.ITEM.HATENA == item)
            {
                hatenaBlock.SetItemBox();
                StartCoroutine(ColDestroyObj());
                return;
            }

            if (Enums.ITEM.SHINGLEDRILL == item)
            {
                if (collision.gameObject.CompareTag("Player"))
                {
                    GameManager.instance.itemCountManager.DrillCount1++;
                }
                else
                {
                    GameManager.instance.itemCountManager.DrillCount2++;
                }
            }
            else if (Enums.ITEM.DOUBLEDRILL == item)
            {
                if (collision.gameObject.CompareTag("Player"))
                {
                    GameManager.instance.itemCountManager.DrillCount1 += 2;
                }
                else
                {
                    GameManager.instance.itemCountManager.DrillCount2 += 2;
                }
                
            }
            else if (Enums.ITEM.BOM == item)
            {
                if (collision.gameObject.CompareTag("Player"))
                {
                    GameManager.instance.itemCountManager.BomCount1++;
                }
                else
                {
                    GameManager.instance.itemCountManager.BomCount2++;
                }
            }
            else if (Enums.ITEM.SPEEDDOWN == item)
            {
                if (collision.gameObject.CompareTag("Player"))
                {
                    tsuritenjou.tsuritenjou1.TsuritenjouSpeed -= 0.1f;
                }
                else
                {
                    tsuritenjou.tsuritenjou2.TsuritenjouSpeed -= 0.1f;
                }
            }
            else if (Enums.ITEM.SPEEDUP == item)
            {
                if (collision.gameObject.CompareTag("Player"))
                {
                    tsuritenjou.tsuritenjou1.TsuritenjouSpeed += 0.1f;
                }
                else
                {
                    tsuritenjou.tsuritenjou2.TsuritenjouSpeed += 0.1f;
                }
            }
            else if (Enums.ITEM.MUTEKi == item)
            {
                if (collision.gameObject.CompareTag("Player"))
                {
                    GameManager.instance.MutekiTime1 = 0;
                    GameManager.instance.MutekiFlag1 = true;

                    if (GameManager.instance.ora1 != null)
                        GameManager.instance.ora1.SetActive(true);

                    //AudioManager.instance.PlayBGM(1);
                }
                else
                {
                    GameManager.instance.MutekiTime2 = 0;
                    GameManager.instance.MutekiFlag2 = true;

                    if (GameManager.instance.ora2 != null)
                        GameManager.instance.ora2.SetActive(true);

                    //AudioManager.instance.PlayBGM(1);
                }
                
            }

            ObjDel();
        }
    }

    // 時間制限でオブジェクトを削除する
    IEnumerator ColDestroyObj()
    {
        // コライダーを無効にする
        BoxCollider2D col = this.GetComponent<BoxCollider2D>();
        col.enabled = false;

        // 色を透明にする
        SpriteRenderer sr = this.GetComponent<SpriteRenderer>();
        sr.color = new Color(0,0,0,0);

        yield return new WaitForSeconds(3);

        ObjDel();

    }

    void ObjDel()
    {
        this.gameObject.SetActive(false);
    }

}
