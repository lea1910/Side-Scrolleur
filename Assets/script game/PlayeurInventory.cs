using UnityEngine;
using TMPro; // Nécessaire pour gérer le texte UI

public class PlayerInventory : MonoBehaviour
{
    public int itemCount = 0; // Nombre d'objets collectés
    public TextMeshProUGUI itemText; // Référence vers le texte UI

    void Start()
    {
        UpdateUI();
    }

    public void CollectItem()
    {
        itemCount++;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (itemText != null)
        {
            itemText.text = "Objets : " + itemCount;
        }
    }
}

