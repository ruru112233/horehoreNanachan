using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Photon.Pun;
using UnityEngine.UI;
using SelectItem;

public class Player : MonoBehaviour
{

    SpriteRenderer spriteRenderer;

    public PlayerType playerType;

    public Sprite idleSprite;
    public Sprite drillSprite, drillSprite2;

    float moveX = 5.0f;

    Image sprite1, sprite2;

    [SerializeField] GameObject bom;
    BoxCollider2D bomCol;

    public GameObject explosion;

    bool waitFlag = false;

    Vector2 colSize;

    public GameObject downDrill,rightDrill,leftDrill;

    public GameObject startPos, endPos;

    float time;
    float bomWaitTime;

    UseScript useScript;

    int drillCount = 0;
    int bomCount = 0;

    Animator anime;

    // キー操作
    KeyCode downKey,
            rightKey,
            leftKey,
            digKey,
            bomKey,
            itemUseKey,
            startKey,
            selectKey;

    MasterKeyController keyData;

    void Start()
    {
        //spriteRenderer = GetComponent<SpriteRenderer>();

        bomCol = bom.GetComponent<BoxCollider2D>();
        colSize = bomCol.size;
        bomCol.enabled = false;
        
        if(MasterData.playerMode == "P2PLAY")
        {
            useScript = GameObject.FindWithTag("UseManager").GetComponent<UseScript>();
            sprite1 = GameObject.FindWithTag("P1ItemPanel").GetComponent<Image>();
            sprite2 = GameObject.FindWithTag("P2ItemPanel").GetComponent<Image>();
        }

        keyData = MasterKeyController.instance;
        SetKey();

        anime = gameObject.transform.GetChild(0).GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.name == "Player")
        {
            drillCount = GameManager.instance.itemCountManager.DrillCount1;
            bomCount = GameManager.instance.itemCountManager.BomCount1;
        }
        else
        {
            drillCount = GameManager.instance.itemCountManager.DrillCount2;
            bomCount = GameManager.instance.itemCountManager.BomCount2;
        }

        if (!GameManager.instance.player1Stop && this.gameObject.name == "Player")
        {
            PlayerDig();
            ItemUse();
        }
        else if (GameManager.instance.player1Stop && this.gameObject.name == "Player")
        {
            OffDrill();
        }

        if (!GameManager.instance.player2Stop && this.gameObject.name == "Player2")
        {
            PlayerDig();
            ItemUse();
        }
        else if(GameManager.instance.player2Stop && this.gameObject.name == "Player2")
        {
            OffDrill();
        }
    }

    void SetKey()
    {
        if (this.gameObject.name == "Player")
        {
            downKey = keyData.P1Controller().downKey;
            rightKey = keyData.P1Controller().rightKey;
            leftKey = keyData.P1Controller().leftKey;
            digKey = keyData.P1Controller().digKey;
            bomKey = keyData.P1Controller().bomKey;
            itemUseKey = keyData.P1Controller().itemUseKey;
            startKey = keyData.P1Controller().startKey;
            selectKey = keyData.P1Controller().selectKey;
        }
        else
        {
            downKey = keyData.P2Controller().downKey;
            rightKey = keyData.P2Controller().rightKey;
            leftKey = keyData.P2Controller().leftKey;
            digKey = keyData.P2Controller().digKey;
            bomKey = keyData.P2Controller().bomKey;
            itemUseKey = keyData.P2Controller().itemUseKey;
            startKey = keyData.P2Controller().startKey;
            selectKey = keyData.P2Controller().selectKey;
        }
    }

    void PlayerDig()
    {
        if (drillCount > 0)
        {
            if (Input.GetKey(downKey) && Input.GetKey(digKey))
            {
                downDrill.SetActive(true);
                rightDrill.SetActive(false);
                leftDrill.SetActive(false);

                anime.SetBool("DrillFlag", true);
                anime.SetBool("DrillSideFlag", false);
                //spriteRenderer.sprite = drillSprite;

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
                //spriteRenderer.sprite = drillSprite2;
                anime.SetBool("DrillSideFlag", true);
                anime.SetBool("DrillFlag", false);
                rightDrill.SetActive(true);
                downDrill.transform.position = startPos.transform.position;
                downDrill.SetActive(false);
                leftDrill.SetActive(false);

            }
            else if (Input.GetKey(leftKey) && Input.GetKey(digKey))
            {
                //spriteRenderer.sprite = drillSprite2;
                anime.SetBool("DrillSideFlag", true);
                anime.SetBool("DrillFlag", false);
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

        if (bomCount <= 0)
        {
            CollerGray();
        }

        if (Input.GetKeyDown(bomKey))
        {
            if (bomCount > 0)
            {
                if (bomWaitTime == 0)
                {
                    CollerGray();
                    AudioManager.instance.PlaySE(1);
                    if (this.gameObject.name == "Player")
                    {
                        GameManager.instance.itemCountManager.BomCount1--;
                    }
                    else
                    {
                        GameManager.instance.itemCountManager.BomCount2--;
                    }
                    Instantiate(explosion, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                    bomCol.enabled = true;
                }
            }
        }
        else
        {
            if (waitFlag)
            {
                bomWaitTime += Time.deltaTime;

                if (bomWaitTime >= 5.0f && bomCount > 0)
                {
                    CollerWhite();
                    bomWaitTime = 0;
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
                    time = 0;
                }
            }

        }
    }

    // ストックされたアイテムを使用する
    void ItemUse()
    {
        if (MasterData.playerMode == "P2PLAY")
        {
            if (PlayerType.Player1 == playerType)
            {
                UseSelect(sprite1);
            }
            else
            {
                UseSelect(sprite2);
            }
        }
    }

    void UseSelect(Image sprite)
    {
        StockItemPanel stockItemPanel = sprite.gameObject.GetComponent<StockItemPanel>();

        if (Input.GetKeyDown(itemUseKey) && stockItemPanel.ItemName != "")
        {
            useScript.ItemUseSelect(stockItemPanel.ItemName, this.gameObject.name, stockItemPanel.QuantityCange);

            if (stockItemPanel.StealFlag)
            {
                stockItemPanel.StealFlag = false;
            }
            else
            {
                stockItemPanel.ItemName = "";
                stockItemPanel.QuantityCange = "";
                sprite.sprite = null;
            }
            
        }
    }

    void CollerWhite()
    {
        if (this.gameObject.name == "Player")
        {
            GameManager.instance.itemCountManager.bomCountText1.color = GameManager.instance.textWhite;
            GameManager.instance.itemCountManager.bomMeiText1.color = GameManager.instance.textWhite;
        }
        else
        {
            GameManager.instance.itemCountManager.bomCountText2.color = GameManager.instance.textWhite;
            GameManager.instance.itemCountManager.bomMeiText2.color = GameManager.instance.textWhite;
        }
    }
    void CollerGray()
    {
        if (this.gameObject.name == "Player")
        {
            GameManager.instance.itemCountManager.bomCountText1.color = GameManager.instance.textGray;
            GameManager.instance.itemCountManager.bomMeiText1.color = GameManager.instance.textGray;
        }
        else
        {
            GameManager.instance.itemCountManager.bomCountText2.color = GameManager.instance.textGray;
            GameManager.instance.itemCountManager.bomMeiText2.color = GameManager.instance.textGray;
        }
    }

    void OffDrill()
    {
        //spriteRenderer.sprite = idleSprite;
        anime.SetBool("DrillFlag", false);
        anime.SetBool("DrillSideFlag", false);
        downDrill.transform.position = startPos.transform.position;
        downDrill.SetActive(false);
        rightDrill.SetActive(false);
        leftDrill.SetActive(false);
    }

    private void FixedUpdate()
    {
        // Player1の移動処理
        if (!GameManager.instance.player1Stop && this.gameObject.name == "Player")
        {
            PlayerMove();
        }

        // Player2の移動処理
        if (!GameManager.instance.player2Stop && this.gameObject.name == "Player2")
        {
            PlayerMove();
        }

    }

    void PlayerMove()
    {
        if (Input.GetKey(rightKey))
        {
            CharDirection();

            transform.position += new Vector3(moveX * Time.deltaTime, 0, 0);

            anime.SetBool("WarkFlag", true);
        }
        else if (Input.GetKey(leftKey))
        {
            CharDirection();

            transform.position -= new Vector3(moveX * Time.deltaTime, 0, 0);
            anime.SetBool("WarkFlag", true);
        }
        else
        {
            anime.SetBool("WarkFlag", false);
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
            if (MasterData.playerMode == "P1PLAY")
            {
                naichilab.RankingLoader.Instance.SendScoreAndShowRanking(Mathf.Round(GameManager.instance.YJIKU), 1);
                GameManager.instance.gameOver.SetActive(true);
            }
            else if (MasterData.playerMode == "P2PLAY")
            {
                if (this.gameObject.name == "Player")
                {
                    GameManager.instance.p2Win.SetActive(true);
                }
                else
                {
                    GameManager.instance.p1Win.SetActive(true);
                }
            }

            GameManager.instance.resultPanel.SetActive(true);

            GameManager.instance.GameOverFlag = true;
            
            Destroy(gameObject);
        }

    }

}
