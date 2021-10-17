using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Photon.Pun;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    SpriteRenderer spriteRenderer;

    public PlayerType playerType;

    public Sprite idleSprite;
    public Sprite drillSprite, drillSprite2;

    float moveX = 5.0f;

    Image sprite;

    GameObject bom;
    BoxCollider2D bomCol;

    public GameObject explosion;

    bool waitFlag = false;

    Vector2 colSize;

    public GameObject downDrill,rightDrill,leftDrill;

    public GameObject startPos, endPos;

    float time;

    // キー操作
    public KeyCode downKey,
                   rightKey,
                   leftKey,
                   digKey,
                   bomKey,
                   itemUseKey,
                   startKey,
                   selectKey;

    void Start()
    {
        bom = GameObject.FindGameObjectWithTag("bom");
        spriteRenderer = GetComponent<SpriteRenderer>();

        bomCol = bom.GetComponent<BoxCollider2D>();
        colSize = bomCol.size;
        bomCol.enabled = false;

        if (PlayerType.Player1 == playerType)
        {
            sprite = GameObject.FindWithTag("P1ItemPanel").GetComponent<Image>();
        }
        else
        {
            sprite = GameObject.FindWithTag("P2ItemPanel").GetComponent<Image>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        ItemUse();
    }

    void PlayerMove()
    {
        if (GameManager.instance.DrillCount > 0)
        {
            if (Input.GetKey(downKey) && Input.GetKey(digKey))
            {
                downDrill.SetActive(true);
                rightDrill.SetActive(false);
                leftDrill.SetActive(false);

                spriteRenderer.sprite = drillSprite;

                if (downDrill.transform.position.y > endPos.transform.position.y)
                {
                    downDrill.transform.position -= new Vector3(0, 0.1f * Time.deltaTime, 0);
                }
                else
                {
                    downDrill.transform.position += new Vector3(0, 0.1f * Time.deltaTime, 0);
                }

            }
            else if (Input.GetKey(rightKey) && Input.GetKey(digKey))
            {

                spriteRenderer.sprite = drillSprite2;
                rightDrill.SetActive(true);
                downDrill.transform.position = startPos.transform.position;
                downDrill.SetActive(false);
                leftDrill.SetActive(false);

            }
            else if (Input.GetKey(leftKey) && Input.GetKey(digKey))
            {
                spriteRenderer.sprite = drillSprite2;
                leftDrill.SetActive(true);
                downDrill.transform.position = startPos.transform.position;
                downDrill.SetActive(false);
                rightDrill.SetActive(false);
            }
            else
            {
                OffDrill();
            }
        }
        else
        {
            OffDrill();
        }

        bom.transform.position = transform.position;

        if (GameManager.instance.BomCount <= 0)
        {
            CollerGray();
        }

        if (Input.GetKeyDown(bomKey))
        {
            if (GameManager.instance.BomCount > 0)
            {
                if (time == 0)
                {
                    CollerGray();
                    AudioManager.instance.PlaySE(1);
                    GameManager.instance.BomCount--;
                    Instantiate(explosion, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                    bomCol.enabled = true;
                }
            }
        }
        else
        {
            if (waitFlag)
            {
                time += Time.deltaTime;

                if (time >= 5.0f)
                {
                    CollerWhite();
                    time = 0;
                    waitFlag = false;
                }
            }

            if (bomCol.enabled)
            {
                time += Time.deltaTime;
                bomCol.size += new Vector2(1.7f * Time.deltaTime, 1.5f * Time.deltaTime);

                if (time >= 0.14f)
                {
                    bomCol.size = colSize;
                    bomCol.enabled = false;
                    waitFlag = true;
                }
            }

        }
    }

    // ストックされたアイテムを使用する
    void ItemUse()
    {
        StockItemPanel stockItemPanel = sprite.gameObject.GetComponent<StockItemPanel>();

        if (Input.GetKeyDown(itemUseKey) && stockItemPanel.ItemName != "")
        {
            Debug.Log("アイテムを使った");
            stockItemPanel.ItemName = "";
            sprite.sprite = null;
        }
    }


    void CollerWhite()
    {
        GameManager.instance.bomText.color = GameManager.instance.textWhite;
        GameManager.instance.bomMei.color = GameManager.instance.textWhite;
    }
    void CollerGray()
    {
        GameManager.instance.bomText.color = GameManager.instance.textGray;
        GameManager.instance.bomMei.color = GameManager.instance.textGray;
    }

    void OffDrill()
    {
        spriteRenderer.sprite = idleSprite;
        downDrill.transform.position = startPos.transform.position;
        downDrill.SetActive(false);
        rightDrill.SetActive(false);
        leftDrill.SetActive(false);
    }

    private void FixedUpdate()
    {
        
        if (Input.GetKey(rightKey))
        {
            CharDirection();

            transform.position += new Vector3(moveX * Time.deltaTime,0,0);

            
        }
        else if(Input.GetKey(leftKey))
        {
            CharDirection();

            transform.position -= new Vector3(moveX * Time.deltaTime, 0, 0);
        }
    }

    // キャラの向きを変える
    void CharDirection()
    {
        float x = Input.GetAxisRaw("Horizontal");
        Vector3 scale = transform.localScale;
        if (x < 0)
        {
            // 右方向に移動中
            scale.x = 0.1f; // そのまま（右向き）
        }
        else if (x > 0)
        {
            // 左方向に移動中
            scale.x = -0.1f; // 反転する（左向き）
        }
        // 代入し直す
        transform.localScale = scale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "tsuritenjou")
        {
            GameManager.instance.gameOver.SetActive(true);
            naichilab.RankingLoader.Instance.SendScoreAndShowRanking(Mathf.Round(GameManager.instance.YJIKU), 1);
            Destroy(gameObject);
        }

        
    }
}
