using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 7f;
    private float _axis = 0;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnMove(InputValue value)
    {
        _axis = value.Get<float>();
    }
    private void OnJump()
    {
        
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
    void Update()
    {
        //deplacement horizontal
       
        rb.velocity = new Vector2(_axis * speed, rb.velocity.y);

        ////saut
        //if (InputGetKeyDown(KeyCode.Space)&& isGrounded)
        //{
        //    rb.velocity = new Vector2(rb.velocity.x, jumpFo rce);
        //}   
    }

    //    void OnCollisionEnter2d(Collision2D collision)
    //    {
    //        if (collision.gameObject.CompareTag("Ground"))
    //        {
    //            isGrounded = true;
    //        }
    //    }
    //    void OnCollisionExit2D(Collision2D collision)
    //    {
    //        if (collision.gameObject.CompareTag("Ground"))
    //        {
    //            isGrounded = false;
    //        }
    //    }
}
