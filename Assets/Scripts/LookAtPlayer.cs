using System;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    private Transform target;

    void Start()
    {
        target = GameObject.FindWithTag("MainCamera").transform;
    }

    void Update()
    {
        if (target != null)
        {
            //transform.LookAt(this.transform - target);
            transform.LookAt(target);
        }
    }
}
