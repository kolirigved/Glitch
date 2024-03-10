using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gliding : MonoBehaviour
{
    public float glidingSpeed = 1.0f;
    public float initialGravityScale;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialGravityScale = rb.gravityScale;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("Space") && rb.velocity.y < 0)
        {
            rb.gravityScale = 0;
            rb.velocity = new Vector2(rb.velocity.x, -glidingSpeed);

        }
        else
        {
            rb.gravityScale = initialGravityScale;
        }
    }
}
