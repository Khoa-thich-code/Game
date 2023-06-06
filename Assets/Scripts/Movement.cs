using UnityEngine;

public class Movement : MonoBehaviour
{
    private bool isFacingRight = true;
    public float speed;
    private float horizontalInput;
    private Rigidbody2D rb;
    private Animator anim;
    private bool canJump = true;  // Variable to check if the character can jump
    public float jumpForce = 5f;  // Jump force

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
        Flip();
        anim.SetFloat("move", Mathf.Abs(horizontalInput));

        if (Input.GetKeyDown(KeyCode.Space) && canJump)  // Check if the user pressed the Space key and the character can jump
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);  // Apply jump force to the character
        canJump = false;  // Set canJump to false to prevent the character from jumping again
    }

    void Flip()
    {
        if (isFacingRight && horizontalInput < 0 || !isFacingRight && horizontalInput > 0)
        {
            isFacingRight = !isFacingRight;
            Vector3 scale = transform.localScale;
            scale.x = scale.x * -1;
            transform.localScale = scale;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))  // Check if the character collides with the ground
        {
            canJump = true;  // Set canJump to true when the character lands on the ground, allowing jumping again
        }
    }
}
