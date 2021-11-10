using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonFX : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource fx;
    public AudioClip click;
    public AudioClip hover;

    private void Start()
    {
        fx = this.GetComponent<AudioSource>();
    }
    public void Hover()
    {
        fx.PlayOneShot(hover);
    }
    public void Click()
    {
        fx.PlayOneShot(click);
    }
}
