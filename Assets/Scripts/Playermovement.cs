using UnityEngine;

public class Playermovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] bool isGrounded;
    [SerializeField] float groundCheckRadius;

    [SerializeField] Transform groundcheck;
    [SerializeField] LayerMask groundLayer;

    Rigidbody2D rb;
    Vector2 playerInput;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(playerInput.x * speed, rb.linearVelocity.y);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundcheck.position, groundCheckRadius);
    }
}
