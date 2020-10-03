using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Karakter : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    [SerializeField] private float speed, jumpSpeed;
    [SerializeField] private bool isGround,faceRight;
    public void Start()
    {
        faceRight = true;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    public void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(x, 0) * speed;
        anim.SetFloat("Hiz", x);
        if(y > 0.1)
        {
            if (isGround)
            {
                rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            }
        }
        if (faceRight == true && x < 0)
        {
            Flip();

        }
        else if (faceRight == false && x > 0)
        {
            Flip();
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
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        isGround = false;
    }
}
