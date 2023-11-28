using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UIElements;


/*
 * What we want
 * basic movement
 * wall jumps
 * clamped fall speed
 * dashing
 */

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rb;

    float inputX;
    bool jumpInput;
    bool dashInput;
    bool facingRight = true;

    float checkRadius = .2f;

    Vector2 dashDir;
    bool canDash = true;
    bool isDashing;

    bool isWallSliding;
    bool isWallJumping;

    float wallJumpingDirection;
    float wallJumpingCounter;

    [Header("Movement")]
    [SerializeField]
    float moveSpeed;
    [SerializeField]
    float jumpSpeed;
    [SerializeField]
    Transform groundCheck;
    [SerializeField]
    LayerMask whatIsGround;

    [Header("Dashing")]
    [SerializeField]
    float dashSpeed;
    [SerializeField]
    float dashTime;
    [SerializeField]
    TrailRenderer tr;

    [Header("WallSliding")]
    [SerializeField]
    float wallSlidingSpeed;
    [SerializeField]
    Transform wallCheck;
    [SerializeField]
    LayerMask whatIsWall;

    [Header("WallJumping")]
    [SerializeField]
    float wallJumpingTime;
    [SerializeField]
    float wallJumpingDuration;
    [SerializeField]
    Vector2 wallJumpingPower;


    void FixedUpdate()
    {
        if (isDashing)
        {
            rb.velocity = dashDir.normalized * dashSpeed;
            return;
        }
        if (isWallJumping)
        {
            return;
        }
        rb.velocity = new Vector2(inputX * moveSpeed, rb.velocity.y);
    }

    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        jumpInput = Input.GetKeyDown(KeyCode.Space);
        dashInput = Input.GetKeyDown(KeyCode.LeftShift);


        if (jumpInput && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }

        if (IsGrounded()) { canDash = true; }

        if (dashInput && canDash)
        {
            StartCoroutine(Dash());
        }

        if (isWallSliding)
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

        if (jumpInput && isWallSliding)
        {
            StartCoroutine(WallJump());
        }

        WallSlide();

        if (!isWallJumping)
        {
            Flip();
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Finish"))
        {
            Debug.Log("GameOver");
        }
    }
    private IEnumerator Dash()
    {
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        isDashing = true;
        canDash = false;
        dashDir = new Vector2(transform.localScale.x, Input.GetAxisRaw("Vertical"));
        tr.emitting = true;

        rb.gravityScale = originalGravity;
        yield return new WaitForSeconds(dashTime);
        isDashing = false;
        tr.emitting = false;
    }


    bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
    }

    private void WallSlide()
    {
        if (IsWalled() && !IsGrounded() && inputX != 0)
        {
            isWallSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }
        else { isWallSliding = false; }
    }

    private IEnumerator WallJump()
    {
        isWallJumping = true;
        rb.velocity = new Vector2(wallJumpingDirection * wallJumpingPower.x, wallJumpingPower.y);
        wallJumpingCounter = 0f;

        if (transform.localScale.x != wallJumpingDirection)
        {
            facingRight = !facingRight;
            Vector3 Scaler = transform.localScale;
            Scaler.x *= -1;
            transform.localScale = Scaler;
        }
        yield return new WaitForSeconds(wallJumpingDuration);
        isWallJumping = false;
    }

    private void StopWallJumping()
    {
        isWallJumping = false;
    }

    bool IsWalled()
    {
        return Physics2D.OverlapCircle(wallCheck.position, checkRadius, whatIsWall);
    }
    void Flip()
    {
        if (!facingRight && inputX > 0 || facingRight && inputX < 0)
        {
            facingRight = !facingRight;
            Vector3 Scaler = transform.localScale;
            Scaler.x *= -1;
            transform.localScale = Scaler;
        }
    }
}
