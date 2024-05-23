using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float MovementSpeed = 5f;
    [SerializeField] float Jumpspeed = 5f;
    bool grounded = false;
    Rigidbody2D rb;
    SpriteRenderer sp;
    public PowerTimer powerRefill;
    [SerializeField] float TimeFactor = 0.2f;
    [SerializeField] public AudioSource jumpsound;
    [SerializeField] public Animator animator;
    float JumpCount = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        float input = Input.GetAxis("Horizontal");
        if (input > 0)
        {
            sp.flipX = true;
        }
        else if (input < 0)
        {
            sp.flipX = false;
        }
        transform.position = new Vector2(transform.position.x + MovementSpeed * input * Time.deltaTime * (1 / Time.timeScale), transform.position.y);
        animator.SetFloat("speed", Mathf.Abs(input));
        if (Input.GetKeyDown(KeyCode.Space) && JumpCount<2)
        {
            jumpsound.Play();
            rb.velocity = new Vector2(rb.velocity.x, Jumpspeed);
            JumpCount++;
            animator.SetBool("isJumping", true);
        }

        if (powerRefill.timer.fillAmount == 1 && Input.GetKeyDown(KeyCode.LeftShift))
        {
            powerRefill.PowerUp(TimeFactor);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        {
            JumpCount = 0;
            grounded = true;
            transform.rotation = Quaternion.identity;
            animator.SetBool("isJumping", false);

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        {
            grounded = false;
        }
    }
}
