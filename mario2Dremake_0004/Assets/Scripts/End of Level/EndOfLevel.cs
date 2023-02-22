using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfLevel : MonoBehaviour
{
    public PlayerInfo playerInfo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Time.timeScale = 0f;
            
            SaveSystem.SavePlayer(playerInfo);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            SaveSystem.LoadPlayer();
            
        }
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /*
     *     private float timer = 0;


        void Update()
        {

            timer += Time.deltaTime;

            if (timer > 5f)
            {
                score += 5;

                text.text = "x " + score.ToString();

                timer = 0f;
            }
        }
     */


}
