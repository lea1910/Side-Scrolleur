using UnityEngine;

public class WeakSpot : MonoBehaviour
{

    public GameObject Spot;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        { 
            Destroy(Spot);
        }
    }
}
