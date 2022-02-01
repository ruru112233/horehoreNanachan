using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlinePrefab : MonoBehaviour
{
    public OnlineGenerateManager gene;
    public PhotonView photon;
    // Start is called before the first frame update
    void Start()
    {
        photon = GetComponent<PhotonView>();
        if (photon.isMine)
        {
            gene = GameObject.Find("GenerateManager").GetComponent<OnlineGenerateManager>();
            gene.BlockGenerate2();
            InvokeRepeating(nameof(gene.RandomPos), 0.0f, 0.5f);
        }
        
    }
}
