using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaDeathScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    public int GoombaValue = 100;

    [SerializeField]
    private Animator animator;

    public PlayerHealthScript playerHealthScript;

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
            playerHealthScript.takeDamage(damage);
        }
    }
    


    public void OnDeathAnimationFinished()
    {
        Destroy(gameObject);
    }

}
