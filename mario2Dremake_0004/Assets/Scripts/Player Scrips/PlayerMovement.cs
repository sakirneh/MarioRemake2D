using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    private float horizontal;
    private float vertical;
    public float Speed = 10f;
    public float jumpingPower = 15f;
    private bool isfacingright = true;


    public float KBForce, KBCounter, KBTotalTime;

    public bool KBFromRight;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundlayer;

    public Animator animator;

    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private AudioSource collectCoins;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontal));


        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");



        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded()) //stopping player from jumping if there is no ground.
        {
            jumpSoundEffect.Play(); // plays referenced sound effect.

            Jump();
            
            animator.SetBool("isJumping", true);
            
        }
        else
        {
            animator.SetBool("isJumping", false);
        }


        Flip();

        if(rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallmultiplier - 1) * Time.deltaTime;
        }
        else if(rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowjumpmiltiplier - 1) * Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {

        if (KBCounter <=0)
        {
            rb.velocity = new Vector2(horizontal * Speed, rb.velocity.y);
        }
        else
        {
            if (KBFromRight == true)
            {
                rb.velocity = new Vector2(-KBForce, KBForce);
            }
            if (KBFromRight == false)
            {
                rb.velocity = new Vector2(KBForce, KBForce);
            }
            KBCounter -= Time.deltaTime;
        }
        
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundlayer); //uses an empty child object of player to create a circle to check for a ground. 
    }

    private void Flip() // flips the player object horizontally.
    {
        if (isfacingright && horizontal < 0f || !isfacingright && horizontal > 0f)
        {
            isfacingright = !isfacingright;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }


    public float fallmultiplier = 3f;
    public float lowjumpmiltiplier = 2f;

    private void Jump()// if imput is space and y velocity is lower
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        //rb.velocity = Vector2.up * jumpingPower;
        if (Input.GetKeyDown(KeyCode.Space) && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }


    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coins"))
        {
            collectCoins.Play();
            Destroy(other.gameObject);
        }

        //if (other.gameObject.CompareTag("Enemy"))
        //{

        //}


    }






}