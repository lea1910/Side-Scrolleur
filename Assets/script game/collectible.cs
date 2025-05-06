using UnityEngine;

public class Collectible : MonoBehaviour
{
    public AudioClip pickupSound; // Son quand on ramasse l�objet

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // V�rifie si c'est le joueur
        {
            // Jouer un son si un AudioSource est pr�sent
            if (pickupSound != null)
            {
                AudioSource.PlayClipAtPoint(pickupSound, transform.position);
            }

            // Ajouter l'objet � l'inventaire (optionnel)
            PlayerInventory inventory = collision.GetComponent<PlayerInventory>();
            if (inventory != null)
            {
                inventory.CollectKey();
            }

            // D�truire l'objet
            Destroy(gameObject);
        }
    }
}
