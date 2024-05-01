using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class NoJerryDontMove : MonoBehaviour
{
    private Vector3 startLocalPosition;

    void Start()
    {
        // Save the initial local position of the object
        startLocalPosition = transform.localPosition;
    }

    void Update()
    {
        // Lock the object to its initial local position
        transform.localPosition = startLocalPosition;
    }
}
