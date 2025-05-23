using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fader : MonoBehaviour
{
    public GameObject Canva;
    public Animator _animator;
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CompareTag("Player"))
            Canva.SetActive(true);
        player.GetComponent<Rigidbody2D>().isKinematic = true;
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        player.GetComponent<Renderer>().enabled = false;
        player.GetComponent<PlayerMovement>().enabled = false;
        _animator.SetTrigger("Fade");

    }

    private void OnTriggerExit2D(Collider2D collision) => Canva.SetActive(true);
    
    public void jaaj()
    {
        SceneManager.LoadScene("Credits");
    }
}
