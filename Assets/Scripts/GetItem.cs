using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    public enum ITEM
    {
        SHINGLEDRILL,
        DOUBLEDRILL,
        BOM,
        SPEEDDOWN,
        SPEEDUP,
        MUTEKi
    }

    public ITEM item;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AudioManager.instance.PlaySE(2);

            if (ITEM.SHINGLEDRILL == item)
            {
                GameManager.instance.DrillCount++;
            }
            else if (ITEM.DOUBLEDRILL == item)
            {
                GameManager.instance.DrillCount += 2;
            }
            else if (ITEM.BOM == item)
            {
                GameManager.instance.BomCount++;
                GameManager.instance.bomText.color = GameManager.instance.textWhite;
                GameManager.instance.bomMei.color = GameManager.instance.textWhite;
            }
            else if (ITEM.SPEEDDOWN == item)
            {
                GameManager.instance.TsuritenjouSpeed -= 0.1f;
            }
            else if (ITEM.SPEEDUP == item)
            {
                GameManager.instance.TsuritenjouSpeed += 0.1f;
            }
            else if (ITEM.MUTEKi == item)
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
}
