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
    helper helper;


    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        direction = 2;
        groundLayerMask = LayerMask.GetMask("Ground");
        helper = gameObject.AddComponent<helper>();
    }
    void Update()
    {
        helper.FlipSprite(false);
        helper.GoBoom();
        TurnAround();
        TurnAroundBump();
    }

    void TurnAround()
    {
        bool left, right;
        left = RayCollisionCheck(-0.5f, 0, 0);
        right = RayCollisionCheck(0.5f, 0, 0);

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
        upleft = RayCollisionCheck(-0.7f, 0, 90f);
        upright = RayCollisionCheck(0.7f, 0, -90f);

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


    public bool RayCollisionCheck(float xoffs, float yoffs, float zoffs)
    {
        float rayLength = 0.5f; // length of raycast
        float sideRayLength = 0.2f;
        bool hitSomething = false;

        // convert x and y offset into a Vector3 
        Vector3 offset = new Vector3(xoffs, yoffs, zoffs);
        Vector3 offsetr = new Vector3(xoffs, yoffs, zoffs);
        Vector3 offsetl = new Vector3(xoffs, yoffs, zoffs);

        //cast a ray starting at the sprite's position
        RaycastHit2D hitdown;
        RaycastHit2D hitright;
        RaycastHit2D hitleft;

        hitdown = Physics2D.Raycast(transform.position + offset, Vector2.down, rayLength, groundLayerMask);
        hitright = Physics2D.Raycast(transform.position + offsetr, Vector2.right, sideRayLength, groundLayerMask);
        hitleft = Physics2D.Raycast(transform.position + offsetl, Vector2.left, sideRayLength, groundLayerMask);

        Color hitdownColor = Color.red;
        Color hitrightColor = Color.red;
        Color hitleftColor = Color.red;


        if (hitdown.collider != null)
        {
            hitdownColor = Color.green;
            hitSomething = true;
        }
        if (hitright.collider != null)
        {
            hitrightColor = Color.green;
            hitSomething = true;
        }
        if (hitleft.collider != null)
        {
            hitleftColor = Color.green;
            hitSomething = true;
        }
        // draw a debug ray to show ray's position
        // You need to enable gizmos in the editor to see these
        Debug.DrawRay(transform.position + offset, Vector2.down * rayLength, hitdownColor);
        return hitSomething;
        Debug.DrawRay(transform.position + offsetr, Vector2.right * rayLength, hitdownColor);
        return hitSomething;
        Debug.DrawRay(transform.position + offsetl, Vector2.left * rayLength, hitdownColor);
        return hitSomething;
    }

}
