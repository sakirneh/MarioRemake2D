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
    

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundlayer;

    public Animator animator;



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
            Jump();
            
            
            animator.SetBool("isJumping", true);
           
            
            
        }
        else
        {
            animator.SetBool("isJumping", false);
        }


        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * Speed, rb.velocity.y);

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
            Destroy(other.gameObject);


        }

        //if (other.gameObject.CompareTag("Enemy"))
        //{
            
        //}

    }





}