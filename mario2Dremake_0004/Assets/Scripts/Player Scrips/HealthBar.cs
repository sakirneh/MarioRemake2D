using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public PlayerHealthScript playerHealthScript;

    [SerializeField] public Sprite fullHeart;
    [SerializeField] public Sprite emptyHeart;
    public Image[] hearts;

    int health = PlayerHealthScript.playerH;

   
    public int numOfHearts;


    private void Start()
    {
        numOfHearts = health;
    }

    void Update()
    {
        health = PlayerHealthScript.playerH;

        if (health > numOfHearts)
        {
            health = numOfHearts;

        }



        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                if(health < 1)
                {
                    health = 0;
                    hearts[i].enabled = false;
                }
                hearts[i].sprite = emptyHeart;
            }

            if(i < hearts.Length)
            {
                hearts[i].enabled = true;

            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }


}
