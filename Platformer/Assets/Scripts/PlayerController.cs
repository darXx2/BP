using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidBody2d;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider2D;
    [SerializeField] private LayerMask ground;


    private float directionX;
    [SerializeField] private float movementSpeed = 7f;
    [SerializeField] private float jumpPower = 14f;

    private enum ControllerState {idle, run, jump, fall}

    [SerializeField] private AudioSource jumpSound;

    // Start is called before the first frame update
    private void Start()
    {
        rigidBody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        directionX = Input.GetAxisRaw("Horizontal");

        rigidBody2d.velocity = new Vector2(directionX * movementSpeed, rigidBody2d.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            jumpSound.Play();
            rigidBody2d.velocity = new Vector2(rigidBody2d.velocity.x, jumpPower);
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        ControllerState state;

        if (directionX > 0f)
        {
            state = ControllerState.run;
            spriteRenderer.flipX = false;
        }
        else if (directionX < 0f)
        {
            state = ControllerState.run;
            spriteRenderer.flipX = true;
        }
        else
        {
            state = ControllerState.idle;
        }

        if(rigidBody2d.velocity.y > 0.1f)
        {
            state = ControllerState.jump;
        }
        else if(rigidBody2d.velocity.y < -0.1f)
        {
            state = ControllerState.fall;
        }

        animator.SetInteger("animState", (int)state);
    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, 0.1f, ground);
    }

}
