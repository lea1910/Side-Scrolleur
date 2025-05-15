using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : MonoBehaviour
{
    public GameObject Canva;

    private void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CompareTag("Player"))
            Canva.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision) => Canva.SetActive(true);
}
