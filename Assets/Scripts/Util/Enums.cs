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
            SPEEDUP, // ����݂̒�V��̃X�s�[�h���グ��
            STEAL, // ����̃A�C�e���𓐂�
            DRILL, // �h�����̌��֌W
            BOM, // �{���̌��֌W
            BLOCKCHANGE, // ����̃A�C�e���u���b�N��y�u���b�N�ɕς���
            NOPLAY, // �������莞�ԑ��얳���ɂ���
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

