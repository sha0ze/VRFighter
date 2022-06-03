using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject pivot;
    //private float prev;
    //private float now;
    private bool isStayed = false;
    public GameObject bullet;
    public GameObject projectile;
    private GameObject newProjectile;
    //public Transform parent;

    void OnTriggerStay(Collider other)
    {
        isStayed = true;
    }

    void OnTriggerExit()
    {
        if (isStayed && !newProjectile)
        {
            if (GameObject.FindWithTag("orb") == null)
            {
                //this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
                newProjectile = Instantiate(projectile, this.gameObject.transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
                newProjectile.GetComponent<Rigidbody>().AddForce((this.gameObject.transform.forward - 0.1f * Vector3.up) * 5f, ForceMode.VelocityChange);
                AudioManager.instance.RequestSFX(SFXTYPE.Fireball_cast);
                //this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
        isStayed = false;
    }
}
