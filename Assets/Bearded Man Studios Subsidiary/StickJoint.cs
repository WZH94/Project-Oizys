using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickJoint : MonoBehaviour
{
    public Transform parentTransform;
    public float distanceToParent;

    // Start is called before the first frame update
    void Awake()
    {
        parentTransform = transform.parent;
        distanceToParent = Vector3.Distance(transform.position, parentTransform.position);
    }
}
