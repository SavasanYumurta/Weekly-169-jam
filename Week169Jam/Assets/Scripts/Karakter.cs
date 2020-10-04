using UnityEngine;

public class Karakter : MonoBehaviour
{
    [SerializeField]private int speed, jumpSpeed, climbSpeed;

    
    Animator animator;
    Rigidbody2D rb;
    public bool isMermi;
    private bool isGround = true,faceRight = true;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (moveInput > 0 || moveInput < 0)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        if (faceRight == true && moveInput < 0)
        {

            Flip();
        }
        else if (faceRight == false && moveInput > 0)
        {
            Flip();
        }
    }

    private void Jump()
    {
        if (isGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            isGround = false;
        }
    }

    private void Flip()
    {
        faceRight = !faceRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

     public void OnCollisionEnter2D(Collision2D collision)
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        isGround = true;
        if(collision.transform.tag == "Gemi")
        {
            this.transform.SetParent(collision.transform);
        }
    }
    public void OnCollisionStay2D(Collision2D collision)
    {
        if (!isGround)
        {
        isGround = true;
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "ladder" && Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, climbSpeed);
        }
        else if (collision.transform.tag == "ladder" && Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector2(rb.velocity.x, -climbSpeed);
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, 2);
        }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        isGround = false;
        if (collision.transform.tag == "Gemi")
        {
            this.transform.SetParent(null);
        }
    }
  

}
