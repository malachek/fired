/*
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;


*
 * What we want
 * basic movement
 * wall jumps
 * clamped fall speed
 * dashing
 *

public class PlayerController1 : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rb;

    float moveInput;
    bool facingRight = true;
    
    bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;


    [Header("Movement")]
    [SerializeField]
    float moveSpeed;
    [SerializeField]
    float jumpForce;

    [Header("Dashin")]
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

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if(!facingRight && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight && moveInput < 0)
        {
            Flip();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded)
        {
            canDash = true;
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = Vector2.up * jumpForce;
            }
        }

        if (canDash && Input.GetKeyDown(KeyCode.LeftShift))
        {
            isDashing = true;
            canDash = false;
            dashDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
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

}
*/
