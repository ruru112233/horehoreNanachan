using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    int rankingNo = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReStartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void TitleButton()
    {
        SceneManager.LoadScene("TitleScene");
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

    }

}
