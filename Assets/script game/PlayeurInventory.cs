using UnityEngine;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    public int itemCount = 0;
    public int keyCount = 0; // 🔑 Nombre de clés collectées
    public TextMeshProUGUI itemText;

    void Start()
    {
        UpdateUI();
    }

    public void CollectItem()
    {
        itemCount++;
        UpdateUI();
    }

    public void CollectKey()
    {
        keyCount++;
        Debug.Log("Clé collectée ! Total : " + keyCount);
        UpdateUI();
    }

    void UpdateUI()
    {
        if (itemText != null)
        {
            itemText.text = "Objets : " + itemCount + " | Clés : " + keyCount;
        }
    }
}
