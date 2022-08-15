using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goombascript : MonoBehaviour
{
    const string LEFT = "left";
    const string RIGHT = "right";


    [SerializeField]
    Transform CastPos;

    public float baseCastDist;

    Rigidbody2D rb2D;
    public float moveSpeed = 5f;

    string facingDirection;

    Vector3 baseScale;


    // Start is called before the first frame update
    void Start()
    {
        baseScale = transform.localScale; 
        rb2D = GetComponent<Rigidbody2D>();

        facingDirection = RIGHT;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float vX = moveSpeed;

        if(facingDirection == LEFT)
        {
            vX = -moveSpeed;
        }
        else if(facingDirection == RIGHT)
        {
            vX = moveSpeed;
        }
        //moving game object.
        rb2D.velocity = new Vector2(vX, rb2D.velocity.y);

        if (isHittingWall() || isNearEdge())
        {
            //Debug.Log("Hitwall");

            if(facingDirection == LEFT)
            {
                ChangeFacingDirection(RIGHT);
            }
            else if(facingDirection == RIGHT)
            {
                ChangeFacingDirection(LEFT);
            }

        }
    }

    bool isHittingWall()
    {
        bool val = false;

        //hitting wall logic.
        //define the cast distance for left and right.
        float castDist = baseCastDist;
        if (facingDirection == LEFT)
        {
            castDist = -baseCastDist;
        }
        else
        {
            castDist = baseCastDist;
        }
        //determine the target destination based on the bast distance.
        Vector3 targetPos = CastPos.position;
        targetPos.x += castDist;

        Debug.DrawLine(CastPos.position, targetPos, Color.red);
        if (Physics2D.Linecast(CastPos.position, targetPos, 1 << LayerMask.NameToLayer("Groundlayer")))
        {
            val = true;
        }
        else
        {
            val = false;
        }

        return val;
    }

    bool isNearEdge()
    {
        bool val = true;

  
 
        float castDist = baseCastDist;

        //determine the target destination based on the bast distance.
        Vector3 targetPos = CastPos.position;
        targetPos.y -= castDist;

        Debug.DrawLine(CastPos.position, targetPos, Color.blue);
        if (Physics2D.Linecast(CastPos.position, targetPos, 1 << LayerMask.NameToLayer("Groundlayer")))
        {
            val = false;
        }
        else
        {
            val = true;
        }

        return val;
    }

    void ChangeFacingDirection(string newDirection)
    {
        Vector3 newScale = baseScale;
        if(newDirection == LEFT)
        {
            newScale.x = -baseScale.x;

        }
        else if(newDirection == RIGHT)
        {
            newScale.x = baseScale.x;
        }

        transform.localScale = newScale;
        facingDirection = newDirection;
    }

    

}
