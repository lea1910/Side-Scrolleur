using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionFade : MonoBehaviour
{
    public Image _image;
    public Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _image = this.gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    public void Fade()
    {
        _animator.SetTrigger("Fade");
    }
}
