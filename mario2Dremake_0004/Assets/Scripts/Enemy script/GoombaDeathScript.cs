using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GoombaDeathScript : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        
    }

    private void FixedUpdate()
    {
        
    }

    public int GoombaValue = 100;

    [SerializeField]
    private Animator animator;

    public PlayerHealthScript playerHealthScript;

    public PlayerMovement playerMovement;

    public int damage = 1;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ScoreManagerScript.instance.ChangeScore(GoombaValue);
            animator.SetBool("isDead", true);

            
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            
            playerMovement.KBCounter = playerMovement.KBTotalTime;

            if (other.transform.position.x <= transform.position.x)
            {
                playerMovement.KBFromRight = true;
            }
            if (other.transform.position.x >= transform.position.x)
            {
                playerMovement.KBFromRight = false;
            }

            playerHealthScript.takeDamage(damage);
           
        }
    }
    


    public void OnDeathAnimationFinished()
    {
        Destroy(gameObject);
    }

}
