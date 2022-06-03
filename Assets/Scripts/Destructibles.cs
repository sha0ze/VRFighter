using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructibles : MonoBehaviour
{
    public GameObject destroyedVersion;
    public float health = 2f;

    public void Destroy()
    {
        health--;
        if (health == 0f)
        {
            Debug.Log("Destroy!");
            Instantiate(destroyedVersion, transform.position, transform.rotation);
            Destroy(gameObject);
            AudioManager.instance.RequestSFX(SFXTYPE.Explosion);
        }
    }
}
