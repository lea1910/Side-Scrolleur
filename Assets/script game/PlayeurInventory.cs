using UnityEngine;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    public int keyCount = 0; //  Nombre de clés collectées
    public TextMeshProUGUI itemText;

    void Start()
    {
        UpdateUI();
    }


    public void CollectKey()
    {
        keyCount++;
        Debug.Log("Clé collectée ! Total : " + keyCount);
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (itemText != null)
        {
            itemText.text = "Objets : " + keyCount;
        }
    }
}