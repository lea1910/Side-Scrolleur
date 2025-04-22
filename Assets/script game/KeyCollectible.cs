using UnityEngine;

public class KeyCollectible : MonoBehaviour
{
    public AudioClip pickupSound;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (pickupSound != null)
            {
                AudioSource.PlayClipAtPoint(pickupSound, transform.position);
            }

            PlayerInventory inventory = collision.GetComponent<PlayerInventory>();
            if (inventory != null)
            {
                inventory.CollectKey(); // Appelle la méthode sur le joueur
            }

            Destroy(gameObject);
        }
    }
}
