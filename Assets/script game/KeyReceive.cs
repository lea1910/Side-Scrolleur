using UnityEngine;

public class KeyReceiver : MonoBehaviour
{
    public int requiredKeys = 5; // Nombre de clés nécessaires
    private PlayerInventory _playerInventory; // Référence au joueur
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
                _playerInventory.keyCount -= requiredKeys; // Utiliser les clés
                Debug.Log("Accès autorisé ! Action déclenchée.");
                _porte.SetActive(false);
                // Ici, ajoute l'action (ouvrir une porte, activer un mécanisme, etc.)
            }
            else
            {
                Debug.Log("Accès refusé ! Il manque des clés.");
            }
        }
    }
}