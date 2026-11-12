using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class enemyscript : MonoBehaviour
{
    public GameObject player;

    //variables
    SpriteRenderer sr;
    float direction;
    Rigidbody2D rb;
    public LayerMask groundLayerMask;
    helper helper;


    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        direction = -2;
        groundLayerMask = LayerMask.GetMask("Ground");
        helper = gameObject.AddComponent<helper>();
    }
    void Update()
    {
        helper.FlipSprite(true);
        helper.GoBoom();
        //TurnAround();
        //TurnAroundBump();
        Patrol();
        UpPatrol();
    }

    /*
    void TurnAround()
    {
        bool left, right;
        left = RayCollisionCheck(-0.5f, -1);
        right = RayCollisionCheck(0.5f, -1);

        if (left == false && direction < 0)
        {
            direction = 2;
        }

        if (right == false && direction > 0)
        {
            direction = -2;
        }

        rb.linearVelocityX = direction;
        //if (dir < 0 && left == false) ;
    }

    void TurnAroundBump()
    {
        bool upleft, upright;
        upleft = RayCollisionCheck(-0.7f, 0);
        upright = RayCollisionCheck(0.7f, 0);

        if (upleft == false && direction < 0)
        {
            direction = 2;
        }

        if (upright == false && direction > 0)
        {
            direction = -2;
        }

        rb.linearVelocityX = direction;
        //if (dir < 0 && left == false) ;
    }
    */

    void Patrol()
    {
        rb.linearVelocityX = direction;

        bool hit =false;
        //work out which way I am travelling

        if( direction > 0 )
        {
            hit = RayCollisionCheck(0.7f, 0);
            if ( hit == false )
            {
                direction = -direction;
                return;
            }
        }

        if (direction < 0)
        {
            hit = RayCollisionCheck(-0.7f, 0);

            if (hit == false)
            {
                direction = -direction;
            }

        }
    }

    void UpPatrol()
    {
        rb.linearVelocityX = direction;

        bool uphit = false;
      
        if (direction > 0)
        {
            uphit = RayCollisionCheck(1.1f, 0.5f);
           // uphit = Physics2D.Raycast(Vector2.right);

            if (uphit == true )
            {
                direction = -direction;
            }
        }

        if (direction < 0)
        {
            uphit = RayCollisionCheck(-1.1f, 0.5f);

            if (uphit == true)
            {
                direction = -direction;
            }

        }
    }

    public bool RayCollisionCheck(float xoffs, float yoffs)
    {
        float rayLength = 1.0f; // length of raycast
        bool hitSomething = false;

        // convert x and y offset into a Vector3 
        Vector3 offset = new Vector3(xoffs, (float)(yoffs - 0.5), 0);

        //cast a ray downward starting at the sprite's position
        RaycastHit2D hit;

        hit = Physics2D.Raycast(transform.position + offset, Vector2.down, rayLength, groundLayerMask);

        Color hitColor = Color.red;


        if (hit.collider != null)
        {
            hitColor = Color.green;
            hitSomething = true;
        }
        Debug.DrawRay(transform.position + offset, Vector2.down * rayLength, hitColor);
        return hitSomething;
    }
}


//public bool CheckGround()
// {
// bool leftRay = RayCollisionCheck(-0.2f, 0);

// }
//RaycastHit2D hitright;
//float sideRayLength = 0.2f;
//bool RayCollisionCheck(float xoffs, float yoffs, float zoffs);
//Vector3 offsetr = new Vector3(xoffs, yoffs, zoffs);
//hitright = Physics2D.Raycast(transform.position + offsetr, Vector2.right, sideRayLength, groundLayerMask);