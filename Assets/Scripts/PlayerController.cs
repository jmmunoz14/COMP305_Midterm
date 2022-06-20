using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;

    private Animator animator;

    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private float speed = 10.0f;

    [SerializeField]
    private float jumpForce = 50.0f;

    [SerializeField]
    private float groundCheckRadius = 0.15f;

    [SerializeField]
    private Transform groundCheckPos;

    [SerializeField]
    private LayerMask whatIsGround;

    [SerializeField]
    private bool isGrounded = false;

    [SerializeField]
    private bool isDucking = false;

    private bool isFacingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("xSpeed", Mathf.Abs(rb.velocity.x));
        animator.SetFloat("ySpeed", rb.velocity.y);
        animator.SetBool("isGrounded", isGrounded);
        animator.SetBool("isDucking", isDucking);
        Duck();
    }

    private void FixedUpdate()
    {
        float horizontalAxis = isDucking ? 0 : Input.GetAxis("Horizontal");

        isGrounded = GroundCheck();

        if (isGrounded && Input.GetAxis("Jump") > 0)
        {
            rb.AddForce(new Vector2(0.0f, jumpForce));
            isGrounded = false;
        }

        if (isFacingRight && rb.velocity.x < -0.001)
        {
            Flip();
        }
        else if (!isFacingRight && rb.velocity.x > 0.001)
        {
            Flip();
        }

        rb.velocity = new Vector2(horizontalAxis * speed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if( Input.GetKey(KeyCode.E) && collision.gameObject.name == "Chest")
        {
            Debug.Log("collision" + collision.gameObject.name);

            collision.gameObject.GetComponent<ChestController>().OpenChest();
        }
    }

    private bool GroundCheck()
    {
        return Physics2D.OverlapCircle(groundCheckPos.position, groundCheckRadius, whatIsGround);

    }

    private void Flip()
    {
        Vector3 temp = transform.localScale;
        temp.x *= -1;
        transform.localScale = temp;

        isFacingRight = !isFacingRight;
    }

    private void Duck()
    {
        if (Input.GetAxis("Vertical") < 0)
        {
            isDucking = true;
        }
        else
        {
            isDucking = false;
        }
    }

}
