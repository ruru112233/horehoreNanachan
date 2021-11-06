using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnumsScript
{
    public class Enums : MonoBehaviour
    {
        // はてなブロックから取得できるアイテム
        public enum HtenaItemType
        {
            SPEEDUP, // 相手の吊り天井のスピードを上げる
            STEAL, // 相手のアイテムを盗む
            DRILL, // ドリルの個数関係
            BOM, // ボムの個数関係
            BLOCKCHANGE, // 相手のアイテムブロックを土ブロックに変える
            NOPLAY, // 相手を一定時間操作無効にする
        }

        public enum ITEM
        {
            SHINGLEDRILL,
            DOUBLEDRILL,
            BOM,
            SPEEDDOWN,
            SPEEDUP,
            MUTEKi,
            HATENA,
        }

        public enum ChangeTarget
        {
            TAGET,
            NONE,
        }

        public enum CountType
        {
            DRILL,
            BOM,
        }

        public enum QuantityCangeType
        {
            UP,
            DOWN,
        }

        public enum PlayerMode
        {
            P1PLAY,
            P2PLAY,
        }

        public enum SelectMode
        {
            P1BUTTON,
            P2BUTTON,
            OPTION,
        }
    }
}

