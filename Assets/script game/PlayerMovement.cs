using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 7f;
    private float _axis = 0;
    private Rigidbody2D rb;
    public GameObject zonz;
    public LayerMask terrain;
    public bool GroundCheck;

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
      

        if (GroundCheck) 
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
    void Update()
    {
        //deplacement horizontal
       
        rb.velocity = new Vector2(_axis * speed, rb.velocity.y);

        GroundCheck = Physics2D.Raycast(zonz.transform.position, Vector2.down, 0.1f, terrain);

    }


}
