using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public GameObject startUI;
    public GameObject perfectUI;
    public GameObject goodUI;
    public GameObject longUI;    
    public GameObject objFinishUI;

    public PlayerController playerObject;
    public Text txtGameResult;

    public List<AIPlayerController> AIplayer;
    public List<Text> txtRanking;

    int iRank ;

    bool bFinished;
    bool bStart;

    // Start is called before the first frame update
    void Start()
    {
        
        /* Set Player Names */
        
         txtRanking[0].text = "Mary";
         txtRanking[1].text = "Christi";
         txtRanking[2].text = "Michael";
         txtRanking[3].text = "Charles";

        /* Before Start show UI to get ready (Hold to start) */

        startUI.SetActive(true);        

        // Init

        bStart = false; 
        bFinished = false;
        iRank = 0;
    }

    public void AIFinished( )
    {
        /*
        if AI player is reached to the end, it increases ranking value
        */

        iRank ++;
    }

    public void GameFaild()
    {
        iRank = 3;
        Invoke("GameFinished", 1.0f);
        //GameFinished();
    }
    
    public void GameFinished( )
    {

        if(iRank == 0)
            txtGameResult.text = "Game Completed";
        else    
            txtGameResult.text = "Game Failed";

        objFinishUI.SetActive(true);
        txtRanking[iRank].text = "You";
        txtRanking[iRank].color = Color.red;
        bFinished = true;

    }

    // Update is called once per frame
    void Update()
    {
        
        if( Input.GetMouseButtonDown(0)  )
        {
            
            if(bFinished == true)
            {
                //Reload Game
                SceneManager.LoadScene("GameScene");
                return;
            }

            if(bStart == false)
            {
                //Start Game
                bStart = true;
                startUI.SetActive(false);
                playerObject.SetStarted();

                for(int i = 0 ; i < AIplayer.Count ; i ++ )
                {
                    //Make AI players to start jumping
                    AIplayer[i].SetStarted();
                }

            }

        }
    }

    public void ShowPerfectUI()
    {
        perfectUI.SetActive(true);
        Invoke("HidePerfectUI", 0.5f);
    }

    public void ShowGoodUI()
    {
        goodUI.SetActive(true);
        Invoke("HideGoodUI", 0.5f);
    }

    public void ShowLongUI()
    {
        longUI.SetActive(true);
        Invoke("HideLongUI", 0.5f);
    }

    void HideLongUI()
    {
        longUI.SetActive(false);
    }

    void HideGoodUI()
    {
        goodUI.SetActive(false);
    }
    
    void HidePerfectUI()
    {
        perfectUI.SetActive(false);
    }
}

