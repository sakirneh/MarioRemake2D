using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthScript : MonoBehaviour
{
    public int health;
    public int maxHealth = 3;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(int amount) // amount is how much dmg taken.
    {
        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
