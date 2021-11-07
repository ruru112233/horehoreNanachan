using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    public enum CAMERAPATTEN
    {
        MAIN,
        MINIMAP1,
        MINIMAP2,
    }

    public CAMERAPATTEN camera;

    // Start is called before the first frame update
    void Start()
    {
        if (MasterData.miniMapFlag)
        {
            if (CAMERAPATTEN.MINIMAP1 == camera || CAMERAPATTEN.MINIMAP2 == camera)
            {
                this.gameObject.SetActive(true);
            }
        }
        else
        {
            if (CAMERAPATTEN.MINIMAP1 == camera || CAMERAPATTEN.MINIMAP2 == camera)
            {
                this.gameObject.SetActive(false);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        */

        if (player != null)
        {
            if (CAMERAPATTEN.MAIN == camera)
            {
                transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
            }
            else if(CAMERAPATTEN.MINIMAP1 == camera)
            {
                transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 50, -10);
            }
            else if (CAMERAPATTEN.MINIMAP2 == camera)
            {
                transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 50, -10);
            }
        }

    }
}
