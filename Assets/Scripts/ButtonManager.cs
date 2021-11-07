using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    int rankingNo = 0;

    [SerializeField] OptionManager optionManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReTryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void TitleButton()
    {
        SceneManager.LoadScene("TitleScene2");
    }

    public void Ranking()
    {
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(rankingNo, 0);
    }

    public void P1PlayButton()
    {
        MasterData.playerMode = EnumsScript.Enums.PlayerMode.P1PLAY.ToString();
        SceneManager.LoadScene("MainScene");
    }

    public void P2PlayButton()
    {
        MasterData.playerMode = EnumsScript.Enums.PlayerMode.P2PLAY.ToString();
        SceneManager.LoadScene("Main2PScene");
    }

    public void OptionButton()
    {
        Debug.Log("66666666666666");
        TitleManager2.instance.SelectNum = 0;
        TitleManager2.instance.optionPanel.SetActive(true);
        TitleManager2.instance.OptionFlag = true;
        optionManager.OptionSelectNum = 0;
    }

    public void OptionOff()
    {
        Debug.Log("333333333333333");
        TitleManager2.instance.optionPanel.SetActive(false);
        TitleManager2.instance.SelectNum = 0;
        TitleManager2.instance.OptionFlag = false;
        optionManager.OptionSelectNum = 0;
        
    }

}
