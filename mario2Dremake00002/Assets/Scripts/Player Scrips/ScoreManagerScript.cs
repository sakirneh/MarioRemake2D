using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoreManagerScript : MonoBehaviour
{

    public static ScoreManagerScript instance;
    public TextMeshProUGUI text;
    int score;


    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void ChangeScore(int coinValue)
    {
        score += coinValue;
        text.text = "x " + score.ToString();
    }

    private float timer = 0;
    

    void Update()
    {
        timer += Time.deltaTime;
        
        if(timer > 5f)
        {
            score += 5;

            text.text = "x " + score.ToString();

            timer = 0f;
        }
    }

}
