using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    //variables
    InputAction moveAction;
    InputAction jumpAction;
    Rigidbody2D rb;
    bool isGrounded;
    Animator anim;
    SpriteRenderer sr;
    public LayerMask groundLayer;
    public LayerMask groundLayerMask;
    bool result;
    

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        isGrounded = false;
        anim = GetComponent<Animator>();
        groundLayerMask = LayerMask.GetMask("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        FlipSprite();
        Vector2 moveVel = moveAction.ReadValue<Vector2>();
        //lets player move
        rb.linearVelocity = new Vector2(moveVel.x *5, rb.linearVelocity.y);
        if (rb.linearVelocityX != 0)
        {
            anim.SetBool("walk", true);
        }
        else
        {
            anim.SetBool("walk", false);
        }
        if (moveVel.y < -0.1f)
        {
            anim.SetBool("crouch", true);
        }
        else
        {
            anim.SetBool("crouch", false);
        }
        //player animation
        print(moveVel.y);

        isGrounded = RayCollisionCheck(0, 0);
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



    void FlipSprite()
    {
        if (rb.linearVelocityX < -0.1f)
        {
            sr.flipX = true;
        }
        if (rb.linearVelocityX > 0.1f)
        {
            sr.flipX = false;
        }

    }
    //flips player in walking direction
    void Jump()
    {
        if ((jumpAction.WasPressedThisFrame()) && (isGrounded == true))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 10);
        }
    }


    bool IsGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 1.0f;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        if (hit.collider != null)
        {
            return true;
        }

        return false;
    }


}

