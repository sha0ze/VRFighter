using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushOrb : MonoBehaviour
{
    private bool isStayed = false;
    public GameObject bullet;
    public GameObject leftController;
    public GameObject rightController;
    public GameObject sphere;
    //public Transform parent;

    void Update()
    {
        leftController = this.transform.parent.transform.parent.transform.GetChild(1).gameObject;
        rightController = this.transform.parent.transform.parent.transform.GetChild(2).gameObject;
        sphere = this.transform.parent.transform.parent.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
    }

    void OnTriggerStay(Collider other)
    {
        isStayed = true;
        //Debug.Log(other.name);
    }

    void OnTriggerExit()
    {
        if (isStayed)
        {
            Debug.Log("Shoot");
            //Vector3 left_dir = leftController.transform.position - sphere.transform.position;
            //Vector3 right_dir = rightController.transform.position - sphere.transform.position;
            Vector3 dir = this.transform.position - sphere.transform.position;
            //this.GetComponent<Rigidbody>().AddForce(transform.forward * 20f, ForceMode.VelocityChange);
            this.gameObject.GetComponent<Rigidbody>().AddForce((dir - 0.1f * Vector3.up) * 10f, ForceMode.VelocityChange);
            //this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            AudioManager.instance.RequestSFX(SFXTYPE.Hadouken_shoot);
        }
        isStayed = false;
    }
}
