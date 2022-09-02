using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthScript : MonoBehaviour
{
    [SerializeField]
    PlayerInfo playerInfo;

    [SerializeField]
    public int playerH;



    public int maxHealth = 3;

    // Start is called before the first frame update
    void Start()
    {
    
        playerH = playerInfo.health;

        playerH = maxHealth;
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(int amount) // amount is how much dmg taken.
    {
        playerH -= amount;
        if (playerH <= 0)
        {
            Destroy(gameObject);
        }
    }

    

}
