using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooter : MonoBehaviour
{
    public InputActionReference shootReference = null;
    public InputActionReference energizeReference = null;
    public GameObject projectile;
    public GameObject bullet;
    public Transform crosshair;
    public GameObject leftController;
    public GameObject rightController;
    private GameObject newProjectile;
    private GameObject newProjectile2;
    public GameObject sphere;

    public float duration = 3.0f;
    private float timer = 0f;
    
    private void Awake()
    {
        //energizeReference.action.started += Energize;
        shootReference.action.started += Shoot;
    }

    private void OnDestroy()
    {
        //energizeReference.action.started -= Energize;
        shootReference.action.started -= Shoot;
    }

    /*private void Energize(InputAction.CallbackContext context)
    {
        if (projectile && !newProjectile && !newProjectile2)
        {
            newProjectile = Instantiate(projectile, leftController.gameObject.transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
            newProjectile2 = Instantiate(projectile, rightController.gameObject.transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        }
        if ((leftController.transform.position - crosshair.position).sqrMagnitude < 0.05f
            && (rightController.transform.position - crosshair.position).sqrMagnitude < 0.05f)
        {
            if (projectile && !newProjectile)
            {
                newProjectile = Instantiate(projectile, crosshair.gameObject.transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
            }
            if (newProjectile)
            {
                timer += Time.deltaTime;
                print("Time: "+ timer);
            }
        }
        else
        {
            print((leftController.transform.position - crosshair.position).sqrMagnitude);
            print((rightController.transform.position - crosshair.position).sqrMagnitude);
        }
        if (timer >= 5f)
        {
            timer = 0;
        }
        
    }*/

    private void Shoot(InputAction.CallbackContext context)
    {
        bullet = GameObject.Find("orb(Clone)");
        if (bullet.GetComponent<Rigidbody>().velocity == Vector3.zero)
        {
            Vector3 left_dir = leftController.transform.position - sphere.transform.position;
            Vector3 right_dir = rightController.transform.position - sphere.transform.position;

            bullet.GetComponent<Rigidbody>().AddForce((left_dir + right_dir) / 2 * 20f, ForceMode.VelocityChange);
            //AudioManager.instance.RequestSFX(SFXTYPE.Hadouken_shoot);
        }
        
        
        //leftController.transform.GetChild(0).gameObject.SetActive(false);
        //rightController.transform.GetChild(0).gameObject.SetActive(false);
        /*{
            if ((leftController.transform.position - crosshair.position).sqrMagnitude < 0.05f && (rightController.transform.position - crosshair.position).sqrMagnitude < 0.05f)
            {
                print((leftController.transform.position - crosshair.position).sqrMagnitude);
                print((rightController.transform.position - crosshair.position).sqrMagnitude);
                GameObject newProjectile = Instantiate(projectile, crosshair.gameObject.transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
                //newProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * 20f, ForceMode.VelocityChange);
            }
        }*/
    }
}
