using UnityEngine;
using TMPro; // N�cessaire pour g�rer le texte UI

public class PlayerInventory : MonoBehaviour
{
    public int itemCount = 0; // Nombre d'objets collect�s
    public TextMeshProUGUI itemText; // R�f�rence vers le texte UI

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

