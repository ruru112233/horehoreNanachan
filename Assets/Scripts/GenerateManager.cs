using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateManager : MonoBehaviour
{
    public GameObject BlockPrefab0, BlockPrefab1, BlockPrefab2, BlockPrefab3, 
                      BlockPrefab4, BlockPrefab5, BlockPrefab6, BlockPrefab7, BlockPrefab8, BlockPrefab9;

    float pos = -4;

    //スタートポジション
    float startPos = 5;

    
    int block1MaxNo = 10;
    int block3MaxNo = 12;
    int block5MaxNo = 0;
    int block6MaxNo = 0;
    int block7MaxNo = 0;
    int block8MaxNo = 0;
    int block9MaxNo = 0;

    int randomCount = 0;

    int randomMaxNo;

    int a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p;

    int[][] blockImage =
        {
            new int [] { 0, 1, 1, 1, 1, 1, 1, 1, 1 , 0, -1, -1, -1, -1, -1, 0, 1, 1, 1, 1, 1, 1, 1, 1 , 0 },
            new int [] { 0, 1, 1, 1, 1, 1, 1, 1, 1 , 0, -1, -1, -1, -1, -1, 0, 1, 1, 1, 1, 1, 1, 1, 1 , 0 },
            new int [] { 0, 1, 1, 1, 1, 1, 1, 1, 1 , 0, -1, -1, -1, -1, -1, 0, 1, 1, 1, 1, 1, 1, 1, 1 , 0 },
            new int [] { 0, 4, 4, 4, 4, 4, 4, 4, 4 , 0, -1, -1, -1, -1, -1, 0, 4, 4, 4, 4, 4, 4, 4, 4 , 0 },
            new int [] { 0, -1, -1, -1, -1, -1, -1, -1, -1, 0, -1, -1, -1, -1, -1, 0, -1, -1, -1, -1, -1, -1, -1, -1, 0 },
            new int [] { 0, -1, -1, -1, -1, -1, -1, -1, -1, 0, -1, -1, -1, -1, -1, 0, -1, -1, -1, -1, -1, -1, -1, -1, 0 },
            new int [] { 0, -1, -1, -1, -1, -1, -1, -1, -1, 0, -1, -1, -1, -1, -1, 0, -1, -1, -1, -1, -1, -1, -1, -1, 0 },
            new int [] { 0, -1, -1, -1, -1, -1, -1, -1, -1, 0, -1, -1, -1, -1, -1, 0, -1, -1, -1, -1, -1, -1, -1, -1, 0 },
            new int [] { 0, -1, -1, -1, -1, -1, -1, -1, -1, 0, -1, -1, -1, -1, -1, 0, -1, -1, -1, -1, -1, -1, -1, -1, 0 },
            new int [] { 0, -1, -1, -1, -1, -1, -1, -1, -1, 0, -1, -1, -1, -1, -1, 0, -1, -1, -1, -1, -1, -1, -1, -1, 0 },
            new int [] { 0, -1, -1, -1, -1, -1, -1, -1, -1, 0, -1, -1, -1, -1, -1, 0, -1, -1, -1, -1, -1, -1, -1, -1, 0 },
            new int [] { 0, -1, -1, -1, -1, -1, -1, -1, -1, 0, -1, -1, -1, -1, -1, 0, -1, -1, -1, -1, -1, -1, -1, -1, 0 },
            new int [] { 0, -1, -1, -1, -1, -1, -1, -1, -1, 0, -1, -1, -1, -1, -1, 0, -1, -1, -1, -1, -1, -1, -1, -1, 0 }
        };

    // Start is called before the first frame update
    void Start()
    {
     
        BlockGenerate();

        InvokeRepeating("RandomPos", 0.0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BlockGenerate()
    {
        for (int i = 0; i < blockImage.Length; i++)
        {
            for (int j = 0; j < blockImage[i].Length; j++)
            {
                if (blockImage[i][j] == 0)
                {
                    Instantiate(BlockPrefab0, new Vector3(j - startPos, i - 4.0f, 0), Quaternion.identity);
                }
                else if(blockImage[i][j] == 1)
                {

                    Instantiate(BlockPrefab1, new Vector3(j - startPos, i - 4.0f, 0), Quaternion.identity);
                }
                else if (blockImage[i][j] == 2)
                {

                    Instantiate(BlockPrefab2, new Vector3(j - startPos, i - 4.0f, 0), Quaternion.identity);
                }
                else if (blockImage[i][j] == 3)
                {

                    Instantiate(BlockPrefab3, new Vector3(j - startPos, i - 4.0f, 0), Quaternion.identity);
                }
                else if(blockImage[i][j] == 4)
                {
                    Instantiate(BlockPrefab4, new Vector3(j - startPos, i - 4.0f, 0), Quaternion.identity);
                }

            }

        }
    }

    void RandomPos()
    {
        randomCount++;

        if (randomCount >= 5 && randomCount < 10)
        {
            block1MaxNo = 8;
            block3MaxNo = 9;
        }
        else if (randomCount >= 10)
        {
            block1MaxNo = 4;
            block3MaxNo = 5;
        }
        randomMaxNo = block3MaxNo + 1;

        

        if (randomCount % 5 == 0)
        {
            Clear();
            block1MaxNo = 10;
            block3MaxNo = 11;
            block5MaxNo = 12;
            randomMaxNo = block5MaxNo + 1;
        }

        if (randomCount % 7 == 0)
        {
            Clear();
            block1MaxNo = 8;
            block3MaxNo = 9;
            block5MaxNo = 10;
            block7MaxNo = 11;
            block8MaxNo = 12;
            randomMaxNo = block8MaxNo + 1;
        }

        if (randomCount % 18 == 0)
        {
            Clear();
            block1MaxNo = 8;
            block3MaxNo = 9;
            block6MaxNo = 10;
            randomMaxNo = block6MaxNo + 1;
        }

        // スターを出現
        if (randomCount % 17 == 0)
        {
            Clear();
            block1MaxNo = 9;
            block3MaxNo = 10;
            block5MaxNo = 11;
            block7MaxNo = 12;
            block8MaxNo = 13;
            block9MaxNo = 14;

            randomMaxNo = block9MaxNo + 1;
        }

        a = Random.Range(1, randomMaxNo);
        b = Random.Range(1, randomMaxNo);
        c = Random.Range(1, randomMaxNo);
        d = Random.Range(1, randomMaxNo);
        e = Random.Range(1, randomMaxNo);
        f = Random.Range(1, randomMaxNo);
        g = Random.Range(1, randomMaxNo);
        h = Random.Range(1, randomMaxNo);

        i = Random.Range(1, randomMaxNo);
        j = Random.Range(1, randomMaxNo);
        k = Random.Range(1, randomMaxNo);
        l = Random.Range(1, randomMaxNo);
        m = Random.Range(1, randomMaxNo);
        n = Random.Range(1, randomMaxNo);
        o = Random.Range(1, randomMaxNo);
        p = Random.Range(1, randomMaxNo);

        int[][] blockImage2 =
        {
            new int [] { 0, a, b, c, d, e, f, g, h, 0, -1, -1, -1, -1, -1, 0, i, j, k, l, m, n, o, p}
        };

        BlockMove(blockImage2);
    }

    void Clear()
    {
        block5MaxNo = 0;
        block6MaxNo = 0;
        block7MaxNo = 0;
        block8MaxNo = 0;
        block9MaxNo = 0;
    }

    void BlockMove(int[][] blockImage2)
    {

        for (int i = 0; i < blockImage2.Length; i++)
        {
            pos--;
            for (int j = 0; j < blockImage2[i].Length; j++)
            {
                if (blockImage[i][j] == 0)
                {
                    Instantiate(BlockPrefab0, new Vector3(j - startPos, pos, 0), Quaternion.identity);
                }
                else if(blockImage2[i][j] >= 1 && blockImage2[i][j] < block1MaxNo)
                {
                    Instantiate(BlockPrefab1, new Vector3(j - startPos, pos, 0), Quaternion.identity);
                }
                else if (blockImage2[i][j] >= block1MaxNo && blockImage2[i][j] < block3MaxNo)
                {
                    Instantiate(BlockPrefab2, new Vector3(j - startPos, pos, 0), Quaternion.identity);
                }
                else if (blockImage2[i][j] == block3MaxNo)
                {
                    Instantiate(BlockPrefab3, new Vector3(j - startPos, pos, 0), Quaternion.identity);
                }
                else if (blockImage2[i][j] == block5MaxNo)
                {
                    Instantiate(BlockPrefab5, new Vector3(j - startPos, pos, 0), Quaternion.identity);
                }
                else if (blockImage2[i][j] == block6MaxNo)
                {
                    Instantiate(BlockPrefab6, new Vector3(j - startPos, pos, 0), Quaternion.identity);
                }
                else if (blockImage2[i][j] == block7MaxNo)
                {
                    Instantiate(BlockPrefab7, new Vector3(j - startPos, pos, 0), Quaternion.identity);
                }
                else if (blockImage2[i][j] == block8MaxNo)
                {
                    Instantiate(BlockPrefab8, new Vector3(j - startPos, pos, 0), Quaternion.identity);
                }
                else if (blockImage2[i][j] == block9MaxNo)
                {
                    Instantiate(BlockPrefab9, new Vector3(j - startPos, pos, 0), Quaternion.identity);
                }

            }

        }

    }

    

}
