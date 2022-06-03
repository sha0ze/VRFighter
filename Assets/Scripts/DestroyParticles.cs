using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticles : MonoBehaviour
{
    public GameObject projectile;
    public bool isEnergize = false;
    public GameObject crosshair;
    private Vector3 scaleChange;
    private Vector3 zero;
    public Rigidbody rb;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        scaleChange = new Vector3(0.01f, 0.01f, 0.01f);
        zero = new Vector3(0f, 0f, 0f);
        Invoke("selfDestroy", time);
    }

    void Update()
    {
        if (this.gameObject.tag == "Meteor")
        {
            if (rb.velocity != zero)
            {
                this.transform.localScale += scaleChange;
                // Move upwards when the sphere hits the floor or downwards
                // when the sphere scale extends 1.0f.
                if (this.transform.localScale.y >= 0.5f)
                {
                    this.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                }
            }
        }
        
        
    }
    
    void OnCollisionEnter(Collision c)
    {
        //print(c.gameObject.tag);
        if (c.gameObject.tag == "target")
        {
            Destructibles dest = c.gameObject.GetComponent<Destructibles>();
            Debug.Log(dest.gameObject.name);
            if (dest != null)
            {
                if (dest.health != 1)
                {
                    if (this.gameObject.tag == "orb")
                    {
                        AudioManager.instance.RequestSFX(SFXTYPE.Hadouken_hit);
                    }
                    else
                    {
                        AudioManager.instance.RequestSFX(SFXTYPE.Fireball_hit);
                    }
                }
                dest.Destroy();
            }
            //Destroy(c.gameObject);
        }           
    }

    /*void OnCollisionStay(Collision c)
    {
        crosshair = GameObject.Find("crosshair");
        if (c.gameObject.tag == "meteor" && isEnergize == false)
        {
            StartCoroutine(ExampleCoroutine());
            GameObject newProjectile = Instantiate(projectile, crosshair.gameObject.transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
            print(crosshair.gameObject.transform.position);
            isEnergize = true;
            selfDestroy();
        }
    }*/
    IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(3);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
    void selfDestroy()
    {
        Destroy(gameObject);
    }
}
