using UnityEngine;
using UnityEngine.InputSystem;

public class helper : MonoBehaviour
{
    public void FlipSprite( bool flipLeft )
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
}