using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectResizer : MonoBehaviour
{
    private GameObject objectToResize;
    public float scaleFactor = 1.1f;

    // Start is called before the first frame update
    void Start()
    {
        objectToResize = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (SystemInfo.deviceType == DeviceType.Desktop && (!Input.GetKeyDown(KeyCode.JoystickButton8) && !(Input.GetKeyDown(KeyCode.R))))
            return;
        else if (SystemInfo.deviceType == DeviceType.Handheld && !Input.GetKeyDown(KeyCode.JoystickButton10))
            return;
        ResizeObject();
    }

    

    // Function to resize the object with a specified size
    public void ResizeObject()
    {
        if (objectToResize != null)
        {
            Vector3 currentScale = objectToResize.transform.localScale;
            Vector3 newScale = new Vector3(currentScale.x * scaleFactor, currentScale.y * scaleFactor, currentScale.z * scaleFactor);
            objectToResize.transform.localScale = newScale;
        }
        else
        {
            Debug.LogWarning("Object to resize is not assigned!");
        }
    }
}
