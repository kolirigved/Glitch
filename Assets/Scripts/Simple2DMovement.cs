using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Simple2dmovement : MonoBehaviour
{
    public float moveSpeed=5f;
    private Rigidbody2D rb;
    // private SpriteRenderer ab;
    // public Sprite sprite;

    void Start()
    {
        // ab=GetComponent<SpriteRenderer>();
        // ab.sprite=sprite;
        rb=GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float horizontalInput=0f;
        float verticaInput=0f;
    
        if(Input.GetKey(KeyCode.A))
        {
            horizontalInput=-1f;
        }
        
        if(Input.GetKey(KeyCode.D))
        {
            horizontalInput=1f;
        }
        Vector2 movement =new Vector2(horizontalInput,verticaInput).normalized*moveSpeed;
        rb.velocity=movement;
    }
}
