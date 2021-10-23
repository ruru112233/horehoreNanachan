using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumsScript;

public class GetItem : MonoBehaviour
{
    [SerializeField] HatenaBlock hatenaBlock;


    public Enums.ITEM item;

    private TsuritenjouSpeedUpRule tsuritenjou;

    private void Start()
    {
        tsuritenjou = GameObject.FindWithTag("UseManager").GetComponent<TsuritenjouSpeedUpRule>();
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
