using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumsScript;
using SelectItem;

public class GetItem : MonoBehaviour
{
    [SerializeField] HatenaBlock hatenaBlock;

    [SerializeField] Sprite groundSprite;

    public Enums.ITEM item;

    private string changeTarget;

    public string ChangeTarget
    {
        get { return changeTarget; }
        set { changeTarget = value; }
    }

    float distance = 4;

    Transform playerPos;

    BlockChangeScript blockChangeScript = new BlockChangeScript();

    private TsuritenjouSpeedUpRule tsuritenjou;

    private void Start()
    {
        tsuritenjou = GameObject.FindWithTag("UseManager").GetComponent<TsuritenjouSpeedUpRule>();

        if (this.transform.position.x <= 6.0f)
        {
            playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        }
        else
        {
            playerPos = GameObject.FindGameObjectWithTag("Player2").transform;
        }
    }

    private void Update()
    {
        float distance = DistanceValue(this.gameObject.transform.position, playerPos.position);

        if (distance < this.distance && distance > 1)
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

        spriteRenderer.sprite = groundSprite;
        spriteRenderer.color = Color.white;

        foreach (Transform child in this.gameObject.transform)
        {
            child.gameObject.SetActive(false);
        }

        BoxCollider2D boxCollider = this.GetComponent<BoxCollider2D>();
        boxCollider.isTrigger = false;
        boxCollider.offset = new Vector2(0, 0);
        boxCollider.size = new Vector2(4.8f, 4.8f);

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
                GameManager.instance.DrillCount++;
            }
            else if (Enums.ITEM.DOUBLEDRILL == item)
            {
                GameManager.instance.DrillCount += 2;
            }
            else if (Enums.ITEM.BOM == item)
            {
                GameManager.instance.BomCount++;
                //GameManager.instance.bomText.color = GameManager.instance.textWhite;
                //GameManager.instance.bomMei.color = GameManager.instance.textWhite;
            }
            else if (Enums.ITEM.SPEEDDOWN == item)
            {
                if (collision.gameObject.tag == "Player")
                {
                    tsuritenjou.tsuritenjou1.TsuritenjouSpeed -= 0.1f;
                }
                else
                {
                    tsuritenjou.tsuritenjou2.TsuritenjouSpeed -= 0.1f;
                }
                //GameManager.instance.TsuritenjouSpeed -= 0.1f;
            }
            else if (Enums.ITEM.SPEEDUP == item)
            {
                if (collision.gameObject.tag == "Player")
                {
                    tsuritenjou.tsuritenjou1.TsuritenjouSpeed += 0.1f;
                }
                else
                {
                    tsuritenjou.tsuritenjou2.TsuritenjouSpeed += 0.1f;
                }
                GameManager.instance.TsuritenjouSpeed += 0.1f;
            }
            else if (Enums.ITEM.MUTEKi == item)
            {
                GameManager.instance.MutekiTime = 0;
                GameManager.instance.MutekiFlag = true;

                if (GameManager.instance.ora != null)
                {
                    GameManager.instance.ora.SetActive(true);
                }
                
                AudioManager.instance.PlayBGM(1);
            }

            Destroy(gameObject);
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

        Destroy(gameObject);

    }

}
