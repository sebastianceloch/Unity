using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 5f;
    public float jump = 3f;
    public float acceleration = 1.5f;
    private bool isLookingRight = true;
    private float pom;
    private float horizontal;

    public bool isWallSliding;
    private float wallSlidingSpeed = 2f;

    private bool isWallJumping;
    private float wallJumpingDirection;
    private float wallJumpingDuration = 0.4f;
    private float wallJumpingCounter;
    private float wallJumpingTime = 0.2f;
    private Vector2 wallJumpingPower = new Vector2(4f, 8f);

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask wallLayer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        //Debug.Log("czy sciana" + isWallSliding);
       // Debug.Log("czy skacze " + isWallJumping);
        
       

        if(Input.GetButtonDown("Jump") && isGrounded())
        {
            Jump();
        }

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            pom = speed;
            speed = speed * acceleration;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = pom;
        }

        
        WallSlide();
        WallJump();

        if(!isWallJumping)
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        if(!isWallJumping)
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }

    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jump);
    }

    private void WallJump()
    {
        if(isWallSliding)
        {
            isWallJumping = false;
            wallJumpingDirection = -transform.localScale.x;
            wallJumpingCounter = wallJumpingTime;
            CancelInvoke(nameof(StopWallJumping));
        }
        else
        {
            wallJumpingCounter -= Time.deltaTime;

        }

        if(Input.GetButtonDown("Jump") && wallJumpingCounter > 0f)
        {
            isWallJumping = true;
            rb.velocity = new Vector2(wallJumpingDirection * wallJumpingPower.x, wallJumpingPower.y);
            wallJumpingCounter = 0f;

            if(transform.localScale.x != wallJumpingDirection)
            {
                isLookingRight = !isLookingRight;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }

            Invoke(nameof(StopWallJumping), wallJumpingDuration);
        }
    }

    private void StopWallJumping()
    {
        isWallJumping = false;
    }

    private void Flip()
    {
        if(isLookingRight && horizontal < 0f || !isLookingRight && horizontal > 0f)
        {
            isLookingRight = !isLookingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private bool isWall()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);
    }

    private void WallSlide()
    {
        if(isWall() && !isGrounded() && horizontal != 0f)
        {
            isWallSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }
        else
        {
            isWallSliding = false;
        }
    }
}
