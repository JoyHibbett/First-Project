using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class helper : MonoBehaviour
{
    public void FlipSprite(bool flipLeft)
    {
        Rigidbody2D rb;
        SpriteRenderer sr;
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        if (rb.linearVelocityX < -0.1f)
        {
            sr.flipX = flipLeft;
        }
        if (rb.linearVelocityX > 0.1f)
        {
            sr.flipX = !flipLeft;
        }

    }

    public void GoBoom()
    {
        if (Keyboard.current.bKey.wasPressedThisFrame)
        {
            Destroy(gameObject);
        }
    }



    public bool RayCollisionCheck(float xoffs, float yoffs, float zoffs)
    {
        LayerMask groundLayerMask;
    groundLayerMask = LayerMask.GetMask("Ground");
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