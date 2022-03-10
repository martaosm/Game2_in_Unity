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
    private enum MovementState { idle, jump, fall, run, doubleJump };

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<SpriteRenderer>();
        animation = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
    }


    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * speed, rb.velocity.y);
        if (Input.GetButtonDown("Jump") && counter < 1)
        {
            counter++;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

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
}
