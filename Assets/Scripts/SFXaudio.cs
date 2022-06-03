using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXaudio : MonoBehaviour
{
    public AudioSource fireball;
    public AudioSource explosion;
    public AudioSource hadouken;
    public AudioSource energizing;
    public AudioSource destroy;
    // Start is called before the first frame update
    public void PlayFireball()
    {
        fireball.Play();
    }
}
