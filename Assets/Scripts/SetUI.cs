using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUI : MonoBehaviour
{

    GameObject obj;
    GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas = transform.Find("Canvas").gameObject;
        obj = GetComponentInChildren<Rigidbody>().gameObject;
        transform.position = obj.transform.position;
        obj.transform.localPosition = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        canvas.transform.position = obj.transform.position + Vector3.up * 2;
    }

    Transform FindWithTag(Transform root, string tag)
    {
        foreach (Transform t in root.GetComponentsInChildren<Transform>())
        {
            if (t.CompareTag(tag)) return t;
        }
        return null;
    }
}
