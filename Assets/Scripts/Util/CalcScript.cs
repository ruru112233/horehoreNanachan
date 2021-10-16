using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CalcScript
{
    // ランダムの数字(整数)を計算して値を返す。
    public static int RandInt(int minNum, int maxNum)
    {
        int randNum = Random.Range(minNum, maxNum);

        return randNum;
    }

    // ランダムの数字(小数点あり)を計算して値を返す。
    public static float RandFloat(float minNum, float maxNum)
    {
        float randNum = Random.Range(minNum, maxNum);

        return randNum;
    }

}
