using UnityEngine;

public class Playermovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] bool isGrounded;
    [SerializeField] float groundCheckRadius;
    bool facingRight = true;
    [SerializeField] GameObject gun;

    [SerializeField] Transform groundcheck;
    [SerializeField] LayerMask groundLayer;

    Rigidbody2D rb;
    Vector2 playerInput;
    SpriteRenderer SpriteRenderer;

    public bool isShoting;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SpriteRenderer = rb.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        playerInput.x = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(0, 0);
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);

            
        }
        isGrounded = Physics2D.OverlapCircle(groundcheck.position, groundCheckRadius, groundLayer);

        if (playerInput.x > 0 && !facingRight)
        {
            Flip();
        }
        else if (playerInput.x < 0 && facingRight)
        {
            Flip();
        }
    }
    private void FixedUpdate()
    {
        if ((!isShoting))
        {
            rb.linearVelocity = new Vector2(playerInput.x * speed, rb.linearVelocity.y);
        }
       
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundcheck.position, groundCheckRadius);
    }

    void Flip()
    {
        
        facingRight = !facingRight;

        
        if (facingRight)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
