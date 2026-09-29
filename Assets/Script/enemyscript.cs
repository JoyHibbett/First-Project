using Unity.VisualScripting;
using UnityEngine;

public class enemyscript : MonoBehaviour
{
    public GameObject player;

    //variables
    SpriteRenderer sr;
    float direction;
    Rigidbody2D rb;
    public LayerMask groundLayerMask;


    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        direction = 2;
        groundLayerMask = LayerMask.GetMask("Ground");
    }
    void Update()
    {

        float px, ex;
        bool left, right;

        left = RayCollisionCheck(-0.5f, 0);
        right = RayCollisionCheck(0.5f, 0);

        px = player.transform.position.x;
        ex = transform.position.x;

        if (px < ex)
        {
            sr.flipX = false;
        }
        else
        {
            sr.flipX = true;
        }

        // gets player position, enemy faces player


        //print("player x = " + px);
        //print("enemy x = " + ex);

        //detect left side of object
        if( left == false && direction < 0 )
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

    public bool RayCollisionCheck(float xoffs, float yoffs)
    {
        float rayLength = 0.5f; // length of raycast
        bool hitSomething = false;

        // convert x and y offset into a Vector3 
        Vector3 offset = new Vector3(xoffs, yoffs, 0);

        //cast a ray downward starting at the sprite's position
        RaycastHit2D hit;

        hit = Physics2D.Raycast(transform.position + offset, Vector2.down, rayLength, groundLayerMask);

        Color hitColor = Color.red;


        if (hit.collider != null)
        {
            print("Player has collided with Ground layer");
            hitColor = Color.green;
            hitSomething = true;
        }
        // draw a debug ray to show ray's position
        // You need to enable gizmos in th e editor to see these
        Debug.DrawRay(transform.position + offset, Vector2.down * rayLength, hitColor);
        return hitSomething;
    }
}
