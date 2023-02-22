using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthScript : MonoBehaviour
{
    [SerializeField]
    PlayerInfo playerInfo;


    [Header ("Health")]
    [SerializeField]
    static public int playerH = 3;
    [SerializeField]
    public Animator animator;

    [SerializeField] private AudioSource playerDeathaudio;

    [SerializeField] AudioSource backgroundMusic;

    [SerializeField] GameObject playerObject;

    public int maxHealth = 3;

    [Header("iFrames")]
    [SerializeField] private float iFrameDuration;
    [SerializeField] private float numberOfFlashes;
    private SpriteRenderer spriteRend;

    // Start is called before the first frame update
    private void Awake()
    {
        spriteRend = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
    
        playerH = playerInfo.health;

        playerH = maxHealth; // set current health to max health  at the start of the game.
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(int amount) // amount is how much dmg taken.
    {
        playerH -= amount;
        if (playerH > 0)
        {
            StartCoroutine(Invulnerability());
        }

        if (playerH <= 0)
        {

            
            playerDeathaudio.Play();
            PlayerDeathAnim();
            backgroundMusic.Stop(); // stops playing the background music from the background music audio source.
            SaveSystem.SavePlayer(playerInfo); // save player info - health, coins, 
            SceneManager.LoadScene(0); // loads main menu

            
        }
    }

    public void PlayerDeathAnim() // function to call the player death animation - could wrap in a seperate class to call but cba for now.
    {
        animator.SetTrigger("isDead");
    }

    private IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(8,9, true);
        //invulnerability duration
        for (int i =0; i< numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1,0,0, 0.5f);
            yield return new WaitForSeconds(iFrameDuration/ (numberOfFlashes * 4));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFrameDuration / (numberOfFlashes * 4));
        }
        //turn collision back on
        Physics2D.IgnoreLayerCollision(8,9, false);
    }

}
