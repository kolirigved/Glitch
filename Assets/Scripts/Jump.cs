using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    Rigidbody2D rb;
    bool OnGround;
    public float fallMultiplier;
    public float jumpTime;
    public float jumpMultiplier;
    public float JumpForce = 5f;
    //public Animator animator;
    Vector2 vecGravity;
    bool isJumping;
    float jumpCounter;
    //[SerializeField] private AudioSource jumpSoundEffect;


    // Start is called before the first frame update
    void Start()
    {
       OnGround=true;
       vecGravity = new Vector2(0,-Physics2D.gravity.y);
       rb=GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Space)&& OnGround)
       {
            //animator.SetBool("IsJumping",true);
            //rb.velocity=new Vector2(rb.velocity.x,jumpSpeed);
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
            isJumping = true;
            jumpCounter = 0;
            //rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            
        }
        if(rb.velocity.y > 0 && isJumping)
        {
            jumpCounter += Time.deltaTime;
            
            if (jumpCounter > jumpTime)
            {
                isJumping=false;
            }
            float t = jumpCounter / jumpTime;
            float currentJumpMultiplier = jumpMultiplier;
            if (t > 0.5f)
            {
                currentJumpMultiplier = jumpMultiplier * (1 - t);
            }
            rb.velocity += vecGravity * currentJumpMultiplier * Time.deltaTime;

        }
        if(Input.GetKeyUp(KeyCode.Space)) 
        { 
            //jumpSoundEffect.Play();
            isJumping=false;
            jumpCounter=0;
            if (rb.velocity.y > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x,rb.velocity.y*0.6f);
            }
        }
        if (rb.velocity.y < 0)
        {
            if(rb.velocity.y > -30) rb.velocity -= vecGravity * fallMultiplier * Time.deltaTime;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            //animator.SetBool("IsJumping", false);
            OnGround = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            OnGround=false;
        }
    }
}
