using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fallen : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(wait());
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y <= 0f)
        {
            transform.position = new Vector3(transform.position.x, 1f, transform.position.z);
        }
    }

    private IEnumerator wait()
    {
        yield return new WaitForSeconds(5f);
    }
}
