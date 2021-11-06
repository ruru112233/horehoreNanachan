using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MasterKeyController : MonoBehaviour
{

    [Header("[P1のコントローラー]")]
    public KeyCode upP1Key = KeyCode.None;
    public KeyCode downP1Key = KeyCode.None;
    public KeyCode rightP1Key = KeyCode.None;
    public KeyCode leftP1Key = KeyCode.None;
    public KeyCode digP1Key = KeyCode.None;
    public KeyCode bomP1Key = KeyCode.None;
    public KeyCode itemUseP1Key = KeyCode.None;
    public KeyCode startP1Key = KeyCode.None;
    public KeyCode selectP1Key = KeyCode.None;

    [Header("[P2のコントローラー]")]
    public KeyCode upP2Key = KeyCode.None;
    public KeyCode downP2Key = KeyCode.None;
    public KeyCode rightP2Key = KeyCode.None;
    public KeyCode leftP2Key = KeyCode.None;
    public KeyCode digP2Key = KeyCode.None;
    public KeyCode bomP2Key = KeyCode.None;
    public KeyCode itemUseP2Key = KeyCode.None;
    public KeyCode startP2Key = KeyCode.None;
    public KeyCode selectP2Key = KeyCode.None;

    // キーの色
    public Color defaultColor = Color.white;
    public Color selectColor = Color.blue;

    public static MasterKeyController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        if (this != instance)
        {
            Destroy(this.gameObject);

            return;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public class KeyData
    {
        public KeyCode upKey = KeyCode.None;
        public KeyCode downKey = KeyCode.None;
        public KeyCode rightKey = KeyCode.None;
        public KeyCode leftKey = KeyCode.None;
        public KeyCode digKey = KeyCode.None;
        public KeyCode bomKey = KeyCode.None;
        public KeyCode itemUseKey = KeyCode.None;
        public KeyCode startKey = KeyCode.None;
        public KeyCode selectKey = KeyCode.None;
    }

    public KeyData P1Controller()
    {

        KeyData keyData = new KeyData();

        keyData.upKey = upP1Key;
        keyData.downKey = downP1Key;
        keyData.rightKey = rightP1Key;
        keyData.leftKey = leftP1Key;
        keyData.digKey = digP1Key;
        keyData.bomKey = bomP1Key;
        keyData.itemUseKey = itemUseP1Key;
        keyData.startKey = startP1Key;
        keyData.selectKey = selectP1Key;

        return keyData;
    }

    public KeyData P2Controller()
    {
        KeyData keyData = new KeyData();

        keyData.upKey = upP2Key;
        keyData.downKey = downP2Key;
        keyData.rightKey = rightP2Key;
        keyData.leftKey = leftP2Key;
        keyData.digKey = digP2Key;
        keyData.bomKey = bomP2Key;
        keyData.itemUseKey = itemUseP2Key;
        keyData.startKey = startP2Key;
        keyData.selectKey = selectP2Key;

        return keyData;
    }
}
