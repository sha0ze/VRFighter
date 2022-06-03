using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grow : MonoBehaviour
{
    private float currentScale = 1f;
    private float scaleLimit = 1.5f;
    public GameObject leftController;
    public GameObject rightController;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GrowHadouken());
        //StartCoroutine(ShrinkWave());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator GrowHadouken()
    {
        while (currentScale < scaleLimit)
        {
            currentScale += 0.1f;
            Vector3 hadoukenScale = new Vector3(currentScale, currentScale, currentScale);
            transform.localScale = hadoukenScale;
            yield return new WaitForSeconds(0.1f);
        }
        //leftController.transform.GetChild(0).gameObject.SetActive(false);
        //rightController.transform.GetChild(0).gameObject.SetActive(false);
    }

    /*private IEnumerator ShrinkWave()
    {
        float curr = 0f;
        if (GameObject.FindWithTag("wave"))
        {
            curr = GameObject.FindWithTag("wave").transform.localScale.x;
        }
        while (curr > 0f)
        {
            curr -= 0.1f;
            Vector3 waveScale = new Vector3(curr, curr, curr);
            GameObject.FindWithTag("wave").transform.localScale = waveScale;
            yield return new WaitForSeconds(0.1f);
        }
        //leftController.transform.GetChild(0).gameObject.SetActive(false);
        //rightController.transform.GetChild(0).gameObject.SetActive(false);
    }*/
}
