using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerScript : MonoBehaviour
{
    //variables
    InputAction moveAction;
    InputAction jumpAction;
    InputAction attackAction;
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sr;
    helper helper;
    public LayerMask groundLayer;
    public LayerMask groundLayerMask;
    public GameObject weapon;
    bool isGrounded;
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
        helper = gameObject.AddComponent<helper>();
        attackAction = InputSystem.actions.FindAction("Attack");
    }

    void Update()
    {
        Move();

        Jump();

        Shoot();

        helper.FlipSprite(true);

        isGrounded = RayCollisionCheck(0, 0);
    }
    void Move()
    {
        Vector2 moveVel = moveAction.ReadValue<Vector2>();
        rb.linearVelocity = new Vector2(moveVel.x * 5, rb.linearVelocity.y);
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
            hitColor = Color.green;
            hitSomething = true;
        }
        Debug.DrawRay(transform.position + offset, Vector2.down * rayLength, hitColor);
        return hitSomething;
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

    // sparkle attack
    void Shoot()
    {
        Vector2 moveVel = moveAction.ReadValue<Vector2>();
       

        

        if (attackAction.WasPressedThisFrame())
        {
            // Instantiate the bullet at the position and rotation of the player
            GameObject clone;
            clone = Instantiate(weapon, transform.position, transform.rotation);

            Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();

            // set the position close to the player
            rb.transform.position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z + 1);

            //shoots the weapon the way the player is facing
            if (sr.flipX == false )
                rb.linearVelocity = new Vector2(15, 0);
            else
                rb.linearVelocity = new Vector2(-15, 0);
        }
    }
}