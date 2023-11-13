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

    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;


    [Header("Movement")]
    [SerializeField]
    float moveSpeed;
    [SerializeField]
    float jumpSpeed;

    [Header("Dashing")]
    [SerializeField]
    float dashSpeed;
    [SerializeField]
    float dashTime;
    Vector2 dashDir;
    bool isDashing;
    bool canDash = true;


    void Start()
    {

    }
    void FixedUpdate()
    {
        if(isDashing)
        {
            return;
        }


        if (!facingRight && inputX > 0)
        {
            Flip();
        }
        else if (facingRight && inputX < 0)
        {
            Flip();
        }
    }

    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        jumpInput = Input.GetKeyDown(KeyCode.Space);
        dashInput = Input.GetKeyDown(KeyCode.LeftShift);

        rb.velocity = new Vector2(inputX * moveSpeed, rb.velocity.y);

        if (jumpInput && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }

        if (isGrounded())
        {
            canDash = true;
        }

        if (dashInput && canDash)
        {
            isDashing = true;
            canDash = false;
            dashDir = new Vector2(inputX, Input.GetAxisRaw("Vertical"));
            if (dashDir == Vector2.zero)
            {
                dashDir = new Vector2(transform.localScale.x, 0);
            }
            StartCoroutine(StopDashing());
        }

        if (isDashing)
        {
            rb.velocity = dashDir.normalized * dashSpeed;
            return;
        }
    }

    private IEnumerator StopDashing()
    {
        yield return new WaitForSeconds(dashTime);
        isDashing = false;
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
    }

}
