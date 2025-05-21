using UnityEngine;
using UnityEngine.Animations;
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
    public float minX = -20.5f;
    public Animator animator;
    private float _visibleAxis;
   
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
        if (GroundCheck)
        {
            animator.SetBool("grounded", true);
        }
        else
        {
            animator.SetBool("grounded", false);
        }
        //deplacement horizontal

        rb.velocity = new Vector2(_axis * speed, rb.velocity.y);

        GroundCheck = Physics2D.Raycast(zonz.transform.position, Vector2.down, 0.1f, terrain);
        Debug.Log(GroundCheck);
        Debug.DrawRay(zonz.transform.position, Vector2.down, Color.blue);

        Vector3 position = transform.position;
        position.x = Mathf.Max(position.x, minX);
        transform.position = position;

        if (_axis != 0)
        {
            _visibleAxis = _axis;
        }
        animator.SetBool("isGoingRight", _visibleAxis > 0);
        animator.SetBool("nomove", _axis == 0);
    }


}
