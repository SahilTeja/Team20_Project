using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectResizer : MonoBehaviour
{
    public GameObject objectToResize;
    public float scaleFactor = 1.2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check if input button "js1" is pressed
        if (Input.GetButtonDown("js1"))
        {
            ResizeObject();
        }
    }

    

    // Function to resize the object with a specified size
    public void ResizeObject()
    {
        if (objectToResize != null)
        {
            Vector3 currentScale = objectToResize.transform.localScale;
            Vector3 newScale = new Vector3(currentScale.x * scaleFactor, currentScale.y * scaleFactor, currentScale.z);
            objectToResize.transform.localScale = newScale;
        }
        else
        {
            Debug.LogWarning("Object to resize is not assigned!");
        }
    }
}
