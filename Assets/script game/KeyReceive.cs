using UnityEngine;

public class KeyReceiver : MonoBehaviour
{
    public int requiredKeys = 2; // Nombre de cl�s n�cessaires
    private PlayerInventory playerInventory; // R�f�rence au joueur

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
                playerInventory.keyCount -= requiredKeys; // Utiliser les cl�s
                Debug.Log("Acc�s autoris� ! Action d�clench�e.");
                // Ici, ajoute l'action (ouvrir une porte, activer un m�canisme, etc.)
            }
            else
            {
                Debug.Log("Acc�s refus� ! Il manque des cl�s.");
            }
        }
    }
}

