using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnumsScript
{
    public class Enums : MonoBehaviour
    {
        // �͂Ăȃu���b�N����擾�ł���A�C�e��
        public enum HtenaItemType
        {
            SPEEDUP,
            STEAL,
            DRILL,
            BOM,
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
    }
}

