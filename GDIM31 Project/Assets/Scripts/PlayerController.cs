using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
<<<<<<< Updated upstream

    [SerializeField] public float speed;

    [SerializeField] public float jumpForce;

    private float moveInput;

    [SerializeField] private Rigidbody2D rb;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;

    [SerializeField] private LayerMask whatIsGround;

    private float jumpTimeCounter;
    [SerializeField] private float jumpTime;
    private bool isJumping;


    // Start is called before the first frame update
    void Start()
    {
        
=======
    public float speed;
    public float jumpForce;
    float moveInput;

    Rigidbody2D rb;

    bool facingRight = true;

    bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if(!facingRight && moveInput > 0)
        {
            Flip();
        }
        else if(facingRight && moveInput < 0)
        {
            Flip();
        }
>>>>>>> Stashed changes
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if(isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }

        if (Input.GetKey(KeyCode.Space) && isJumping)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        

        if(Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
=======
        if(isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
>>>>>>> Stashed changes
    }
}
