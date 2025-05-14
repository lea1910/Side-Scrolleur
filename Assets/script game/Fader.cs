using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : MonoBehaviour
{
    public GameObject Canva1;

    private void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CompareTag("Player"))
            Canva1.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Canva1?.SetActive(false);
    }
}
