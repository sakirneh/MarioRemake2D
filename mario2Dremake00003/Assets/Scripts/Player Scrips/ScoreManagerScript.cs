using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoreManagerScript : MonoBehaviour
{

    public static ScoreManagerScript instance;
    public TextMeshProUGUI text;

    [SerializeField]
    PlayerInfo playerinfo;


    // Start is called before the first frame update
    void Start()
    {

        playerinfo.highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();

        if(instance == null)
        {
            instance = this;
        }
    }

    public void ChangeScore(int coinValue)
    {
        playerinfo.score += coinValue;
        text.text = "x " + playerinfo.score.ToString();

        

        if(playerinfo.score > PlayerPrefs.GetInt("HightScore", 0))
        {
            
            playerinfo.highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        }
        
    }

    
    /* // time based + to score
     * private float timer = 0;
     * 
     * timer += Time.deltaTime;
        
        if(timer > 5f)
        {
            score += 5;

            text.text = "x " + score.ToString();

            timer = 0f;
        }
     */

    void Update()
    {



    }


    public void ResetScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
        playerinfo.highScore.text = "0";

    }



}
