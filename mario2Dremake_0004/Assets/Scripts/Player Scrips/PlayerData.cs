using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class PlayerData
{

    
    public int health;
    public int score;
    public int highscore;
    public int curScene;
    

    public PlayerData(PlayerInfo playerinfo)
    {
        
        health = playerinfo.health;
        score = playerinfo.score;
        highscore = PlayerPrefs.GetInt("HighScore");
        curScene = SceneManager.GetActiveScene().buildIndex;
    }
}
