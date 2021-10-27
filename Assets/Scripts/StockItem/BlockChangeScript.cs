using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SelectItem 
{

    public class BlockChangeScript : MonoBehaviour
    {

        float time1 = 0
            , time2 = 0;

        float waitTime = 0.5f;

        // Start is called before the first frame update
        void Start()
        {
            
        }

        private void Update()
        {
            if (GameManager.instance.p1ChangeFlag)
            {
                time1 += Time.deltaTime;

                if (time1 > waitTime)
                {
                    GameManager.instance.p1ChangeFlag = false;
                    time1 = 0;
                }
            }

            if (GameManager.instance.p2ChangeFlag)
            {
                time2 += Time.deltaTime;

                if (time2 > waitTime)
                {
                    GameManager.instance.p2ChangeFlag = false;
                    time2 = 0;
                }
            }

        }

        public void ItemUse(string tag)
        {

            if (tag == "Player")
            {
                GameManager.instance.p1ChangeFlag = true;
            }
            else
            {
                GameManager.instance.p2ChangeFlag = true;
            }
        }


    }

}

