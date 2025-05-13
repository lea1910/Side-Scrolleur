 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInter : MonoBehaviour
{
    public TransitionFade _TransFade;
    public GameObject _canvas;
    public Transform _image;
    // Start is called before the first frame update
    void Start()
    {
        _canvas = GameObject.Find("Canvas");
        _image = _canvas.transform.Find("black");
        _TransFade = _image.GetComponent<TransitionFade>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Teleport"))
        {
            _TransFade.Fade();
        }
    }
}
