using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Photon.Pun;

public class Player : MonoBehaviour
{

    SpriteRenderer spriteRenderer;

    public Sprite idleSprite;
    public Sprite drillSprite, drillSprite2;

    float moveX = 5.0f;

    GameObject bom;
    BoxCollider2D bomCol;

    public GameObject explosion;

    bool waitFlag = false;

    Vector2 colSize;

    public GameObject downDrill,rightDrill,leftDrill;

    public GameObject startPos, endPos;

    float time;

    void Start()
    {
        bom = GameObject.FindGameObjectWithTag("bom");
        spriteRenderer = GetComponent<SpriteRenderer>();

        bomCol = bom.GetComponent<BoxCollider2D>();
        colSize = bomCol.size;
        bomCol.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        PlayerMove();

    }

    void PlayerMove()
    {
        if (GameManager.instance.DrillCount > 0)
        {
            if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.V))
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
            else if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.V))
            {

                spriteRenderer.sprite = drillSprite2;
                rightDrill.SetActive(true);
                downDrill.transform.position = startPos.transform.position;
                downDrill.SetActive(false);
                leftDrill.SetActive(false);

            }
            else if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.V))
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

        if (Input.GetKeyDown(KeyCode.Space))
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

  

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(moveX * Time.deltaTime,0,0);

            
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= new Vector3(moveX * Time.deltaTime, 0, 0);
            
        }
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
