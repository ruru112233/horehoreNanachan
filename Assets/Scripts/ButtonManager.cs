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
        AudioManager.instance.PlaySE(3);

        GameManager.instance.fade.FadeIn(1f, () =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        });
    }

    public void TitleButton()
    {
        AudioManager.instance.PlaySE(3);
        GameManager.instance.fade.FadeIn(1f, () =>
        {
            SceneManager.LoadScene("TitleScene2");
        });
    }

    public void Ranking()
    {
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(rankingNo, 0);
    }

    public void P1PlayButton()
    {
        AudioManager.instance.PlaySE(3);
        MasterData.playerMode = EnumsScript.Enums.PlayerMode.P1PLAY.ToString();

        TitleManager2.instance.fade.FadeIn(1f, () =>
        {
            SceneManager.LoadScene("MainScene");
        });
    }

    public void OnlineButton()
    {
        AudioManager.instance.PlaySE(3);
        MasterData.playerMode = EnumsScript.Enums.PlayerMode.P2PLAY.ToString();
        TitleManager2.instance.fade.FadeIn(1f, () => SceneManager.LoadScene("OnlineScene"));
    }

    public void P2PlayButton()
    {
        AudioManager.instance.PlaySE(3);
        MasterData.playerMode = EnumsScript.Enums.PlayerMode.P2PLAY.ToString();
       
        TitleManager2.instance.fade.FadeIn(1f, () =>
        {
            SceneManager.LoadScene("Main2PScene");
        });
    }

    public void OptionButton()
    {
        AudioManager.instance.PlaySE(3);
        TitleManager2.instance.SelectNum = 0;
        TitleManager2.instance.optionPanel.SetActive(true);
        TitleManager2.instance.OptionFlag = true;
        optionManager.OptionSelectNum = 0;
    }

    public void OptionOff()
    {
        AudioManager.instance.PlaySE(3);
        TitleManager2.instance.optionPanel.SetActive(false);
        TitleManager2.instance.SelectNum = 0;
        TitleManager2.instance.OptionFlag = false;
        optionManager.OptionSelectNum = 0;
        
    }

}
