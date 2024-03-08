using UnityEngine;

public class AutoJump : MonoBehaviour
{
    public float jumpVelocity = 10f; // The velocity applied to make the player jump
    public float jumpInterval = 2f; // The interval between jumps
    private float nextJumpTime = 0f; // The time when the next jump will occur

    private Rigidbody2D rb; // Reference to the player's Rigidbody component
    private bool isGrounded = false; // Whether the player is grounded or not

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody component
    }

    void FixedUpdate()
    {
        // Check if it's time to jump and the player is grounded
        if (Time.time >= nextJumpTime && isGrounded)
        {
            Debug.Log("WTF");
            // Apply the jump velocity
            rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
            // Update the next jump time
            nextJumpTime = Time.time + jumpInterval;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Contact Ground");
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // Check if the collision is with the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
