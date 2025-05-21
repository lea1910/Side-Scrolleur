using UnityEngine;

public class KeyReceiver : MonoBehaviour
{
    public int requiredKeys = 5; // Nombre de cl�s n�cessaires
    private PlayerInventory _playerInventory; // R�f�rence au joueur
    public GameObject _porte; 

    void Start()
    {
        // Trouver automatiquement le PlayerInventory sur le joueur
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            _playerInventory = player.GetComponent<PlayerInventory>();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && _playerInventory != null)
        {
            if (_playerInventory.keyCount >= requiredKeys)
            {
                _playerInventory.keyCount -= requiredKeys; // Utiliser les cl�s
                Debug.Log("Acc�s autoris� ! Action d�clench�e.");
                _porte.SetActive(false);
                // Ici, ajoute l'action (ouvrir une porte, activer un m�canisme, etc.)
            }
            else
            {
                Debug.Log("Acc�s refus� ! Il manque des cl�s.");
            }
        }
    }
}