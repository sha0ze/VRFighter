using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    //public float delay = 3f;
    public float radius = 5f;
    public float force = 700f;

    public GameObject effect;

    float countdown;
    bool isExploded = true;
    //public AudioSource src;
    // Start is called before the first frame update
    void Start()
    {
        //countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        //countdown -= Time.deltaTime;
        if (!isExploded)
        {
            Explode();
            isExploded = true;

        }
    }

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "target")
        {
            isExploded = false;
        }
    }

    void Explode()
    {
        //Debug.Log("boom!");
        //src.Play();
        GameObject explosion = Instantiate(effect, transform.position, transform.rotation) as GameObject;
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }
        ParticleSystem parts = explosion.GetComponent<ParticleSystem>();
        //float totalDuration = parts.duration + parts.startLifetime;
        Destroy(explosion, parts.duration);
        
        Destroy(gameObject);
    }
}
