using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed = 2f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool movingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = new Vector2(movingRight ? speed : -speed, rb.velocity.y);

        // Vérifier si l'ennemi touche un bord ou un mur
        RaycastHit2D groundInfo = Physics2D.Raycast(groundCheck.position, Vector2.down, 1f, groundLayer);
        if (!groundInfo.collider)
        {
            Flip();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            Flip();
        }
    }

    void Flip()
    {
        movingRight = !movingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}

