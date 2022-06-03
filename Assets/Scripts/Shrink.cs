using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrink : MonoBehaviour
{
    private float currentScale = 0.5f;
    private float scaleLimit = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag("orb"))
            StartCoroutine(ShrinkWave());
    }

    private IEnumerator ShrinkWave()
    {
        while (currentScale >= scaleLimit)
        {
            currentScale -= 0.1f;
            Vector3 hadoukenScale = new Vector3(currentScale, currentScale, currentScale);
            transform.localScale = hadoukenScale;
            yield return new WaitForSeconds(0.1f);
        }
        //leftController.transform.GetChild(0).gameObject.SetActive(false);
        //rightController.transform.GetChild(0).gameObject.SetActive(false);
    }
}
