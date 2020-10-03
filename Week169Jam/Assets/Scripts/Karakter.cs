using UnityEngine;
public class Karakter : MonoBehaviour
{
    public int speed;
    public int jumpSpeed;

    Animator animator;
    Rigidbody2D rb;

    public bool isGround = true;
    bool faceRight = true;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
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

        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("zıp");
            Jump();
        }
    }

    private void Jump()
    {
        if (isGround)
        {
            rb.AddForce(Vector2.up * jumpSpeed);
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
        isGround = true;
        if(collision.transform.tag == "Gemi")
        {
            this.transform.SetParent(collision.transform);
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
