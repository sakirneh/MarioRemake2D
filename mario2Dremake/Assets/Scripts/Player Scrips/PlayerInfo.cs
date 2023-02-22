using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInfo : MonoBehaviour
{

    public int score;

    
    public int health = 3;

    
    public TextMeshProUGUI highScore;

    [SerializeField]
    public int curScene;

    [SerializeField]
    string stringscore;

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        health = data.health;
        score = data.score;
        stringscore = data.highscore.ToString();
        

    }

}
