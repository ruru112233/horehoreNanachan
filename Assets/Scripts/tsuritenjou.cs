using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tsuritenjou : MonoBehaviour
{
    float speedTime = 0;

    private float tsuritenjouSpeed = 0.2f;

    public float TsuritenjouSpeed
    {
        get { return tsuritenjouSpeed; }
        set { tsuritenjouSpeed = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.GameOverFlag)
        {
            speedTime += Time.deltaTime;

            if (speedTime > 15.4f)
            {
                //GameManager.instance.TsuritenjouSpeed += 0.2f;
                TsuritenjouSpeed += 0.2f;
                speedTime = 0;
            }

            //transform.position -= new Vector3(0, GameManager.instance.TsuritenjouSpeed * Time.deltaTime,0);
            transform.position -= new Vector3(0, TsuritenjouSpeed * Time.deltaTime, 0);
        }
    }

}
