using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CalcScript
{
    // �����_���̐���(����)���v�Z���Ēl��Ԃ��B
    public static int RandInt(int minNum, int maxNum)
    {
        int randNum = Random.Range(minNum, maxNum);

        return randNum;
    }

    // �����_���̐���(�����_����)���v�Z���Ēl��Ԃ��B
    public static float RandFloat(float minNum, float maxNum)
    {
        float randNum = Random.Range(minNum, maxNum);

        return randNum;
    }

}
