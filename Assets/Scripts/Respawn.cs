using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    //public GameObject projectile;
    public float waitTime = 5f;
    void Start()
    {
        StartCoroutine(wait());
    }

    private IEnumerator wait()
    {
        yield return new WaitForSeconds(waitTime);
        this.gameObject.SetActive(false);
        //Vector3 pos = new Vector3(0f, 1.6f, -4.5f);
        //Instantiate(projectile, pos, Quaternion.Euler(0, 30, 0));
    }
}
