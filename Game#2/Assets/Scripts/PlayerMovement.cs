using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer player;
    private Animator animation;
    private BoxCollider2D coll;
    private float dirX = 0f;
    private float jumpForce = 14f;
    private float speed = 7f;
    private int counter = 0;
    [SerializeField] private LayerMask jumpGround;

    [SerializeField] private AudioSource jumpSound;
    [SerializeField] private AudioSource jumpPlatform;
    private enum MovementState { idle, jump, fall, run, doubleJump };

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<SpriteRenderer>();
        animation = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
        //jumpSound = GetComponent<AudioSource>();
    }


    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * speed, rb.velocity.y);
        if (Input.GetButtonDown("Jump") && counter < 1)
        {
            counter++;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpSound.Play();

        }
        if (IsGrounded())
        {
            counter = 0;
        }
        UpdateAnimation(counter);
    }

    private void UpdateAnimation(int counter)
    {
        MovementState state;
        if (dirX > 0f && IsGrounded())
        {
            state = MovementState.run;
            player.flipX = false;
        }
        else if (dirX < 0f && IsGrounded())
        {
            state = MovementState.run;
            player.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            if (counter == 1)
            {
                state = MovementState.doubleJump;
            }
            else
            {
                state = MovementState.jump;
            }
            
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.fall;
        }
        animation.SetInteger("state", (int)state);
    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpGround);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag(("JumpPlatform")))
        {
            jumpPlatform.Play();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Fan"))
        {
            rb.velocity = new Vector2(rb.velocity.x, 10f);
        }

        if (other.gameObject.CompareTag("Ladder"))
        {
            float dirY = Input.GetAxisRaw("Vertical");
            if (Input.GetKey("up"))
            {
                Physics2D.gravity = Vector2.zero;
                rb.velocity = new Vector2(rb.velocity.x, dirY*speed);
            }

            if (Input.GetKeyUp("up"))
            {
                rb.velocity = new Vector2(0, 0);
            }
            if (Input.GetKey("down") && !IsGrounded())
            {
                rb.velocity = new Vector2(0, dirY*speed);
            }
            if (Input.GetKeyUp("down"))
            {
                rb.velocity = new Vector2(0, 0);
            }
            if (IsGrounded())
            {
                Physics2D.gravity = new Vector2(0, -9.8f);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ladder"))
        {
            Physics2D.gravity = new Vector2(0, -9.8f);
        }
    }
}
