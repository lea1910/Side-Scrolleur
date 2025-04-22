using UnityEngine;

public class KeyReceiver : MonoBehaviour
{
    public int requiredKeys = 2; // Nombre de clés nécessaires
    private PlayerInventory playerInventory; // Référence au joueur

    void Start()
    {
        // Trouver automatiquement le PlayerInventory sur le joueur
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerInventory = player.GetComponent<PlayerInventory>();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && playerInventory != null)
        {
            if (playerInventory.keyCount >= requiredKeys)
            {
                playerInventory.keyCount -= requiredKeys; // Utiliser les clés
                Debug.Log("Accès autorisé ! Action déclenchée.");
                // Ici, ajoute l'action (ouvrir une porte, activer un mécanisme, etc.)
            }
            else
            {
                Debug.Log("Accès refusé ! Il manque des clés.");
            }
        }
    }
}

