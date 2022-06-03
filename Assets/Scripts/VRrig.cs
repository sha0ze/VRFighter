using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class VRMap
{
    public Transform vrTarget;
    public Transform rigTarget;
    public Vector3 posOffset;
    public Vector3 rotOffset;

    public void Map()
    {
        rigTarget.position = vrTarget.TransformPoint(posOffset);
        rigTarget.rotation = vrTarget.rotation * Quaternion.Euler(rotOffset);
    }
}
public class VRrig : MonoBehaviour
{
    public VRMap vrHead;
    public VRMap leftHand;
    public VRMap rightHand;

    public Transform head;
    public Vector3 headOffset;
    // Start is called before the first frame update
    void Start()
    {
        headOffset = transform.position - head.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = headOffset + head.position;
        transform.forward = Vector3.Lerp(transform.forward, Vector3.ProjectOnPlane(head.up, Vector3.up).normalized, Time.deltaTime * 3);

        vrHead.Map();
        leftHand.Map();
        rightHand.Map();
    }
}
