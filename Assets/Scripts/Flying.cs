using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying : MonoBehaviour
{
    public Animator anim;
    public GameObject counter;
    void Start()
    {
        InvokeRepeating("TurnLeft", 1.21f, 1.2f);
    }

    void TurnLeft()
    {
        for (int i = 0; i < 9; i++)
        {
            transform.Rotate(new Vector3(0, -10, 0));
        }   
    }

    void Update()
    {
        anim.SetFloat("speed", 5 - counter.GetComponent<CountNum>().num);
    }
}
