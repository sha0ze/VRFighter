using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hadoken : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject leftController;
    public GameObject rightController;
    public GameObject crosshair;
    public GameObject projectile;
    public GameObject projectile2;
    private GameObject newProjectile;
    private GameObject leftProjectile;
    private GameObject rightProjectile;
    public GameObject sphere;

    public Transform parent;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        crosshair.transform.position = Vector3.Lerp(leftController.transform.position, rightController.transform.position, 0.5f);
        crosshair.transform.rotation = Quaternion.Euler((leftController.transform.eulerAngles.x + rightController.transform.eulerAngles.x) /2, 
            (leftController.transform.eulerAngles.y + rightController.transform.eulerAngles.y) / 2, 
            (leftController.transform.eulerAngles.z + rightController.transform.eulerAngles.z) / 2);
        /*Vector3 left_dir = leftController.transform.position - sphere.transform.position;
        Vector3 right_dir = rightController.transform.position - sphere.transform.position;
        crosshair.transform.rotation = Quaternion.Euler((left_dir.x + right_dir.x) / 2,
            (left_dir.y + right_dir.y) / 2, (left_dir.z + right_dir.z) / 2);*/

        if (GameObject.FindWithTag("meteor") == null)
        {
            if ((leftController.transform.position - rightController.transform.position).sqrMagnitude < 0.15f)
            {
                //print((leftController.transform.position - rightController.transform.position).sqrMagnitude);
                /*if (projectile2 && !leftProjectile && !rightProjectile)
                {
                    leftProjectile = Instantiate(projectile2, leftController.transform.position, Quaternion.Euler(0, 0, 0), parent) as GameObject;
                    rightProjectile = Instantiate(projectile2, rightController.transform.position, Quaternion.Euler(0, 0, 0), parent) as GameObject;
                }*/
                if (GameObject.FindWithTag("meteor") == null)
                {
                    leftController.transform.GetChild(0).gameObject.SetActive(true);
                    rightController.transform.GetChild(0).gameObject.SetActive(true);
                }
                    
            }
            else
            {
                leftController.transform.GetChild(0).gameObject.SetActive(false);
                rightController.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
            

        if ((leftController.transform.position - rightController.transform.position).sqrMagnitude < 0.05f)
        {
            //leftController.transform.GetChild(0).gameObject.SetActive(false);
            //rightController.transform.GetChild(0).gameObject.SetActive(false);
            //print((leftController.transform.position - rightController.transform.position).sqrMagnitude);
            if (projectile && !newProjectile && GameObject.FindWithTag("meteor") == null)
            {
                newProjectile = Instantiate(projectile, crosshair.gameObject.transform.position, Quaternion.Euler(0, 0, 0), parent) as GameObject;
            }
            GameObject orb = GameObject.FindWithTag("orb");
            if (orb)
            {
                if (orb.GetComponent<Rigidbody>().velocity != Vector3.zero)
                {
                    leftController.transform.GetChild(0).gameObject.SetActive(false);
                    rightController.transform.GetChild(0).gameObject.SetActive(false);
                }
            }
        }
        else
        {
            if (newProjectile)
            {
                Destroy(newProjectile);
            }
        }
    }
}
