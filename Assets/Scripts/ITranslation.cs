using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ITranslation : Interaction
{
    public float speed = 5f;
    public override void interact()
    {
        if (SystemInfo.deviceType == DeviceType.Desktop && !Input.GetKey(KeyCode.JoystickButton1))
            return;
        else if (SystemInfo.deviceType == DeviceType.Handheld && !Input.GetKey(KeyCode.JoystickButton2))
            return;
        if (DebugMode)
            Debug.Log(gameObject.transform.position);
        gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (DebugMode)
            Debug.Log(gameObject.transform.position);
        Physics.SyncTransforms();   
    }

    public void Update() {
     
    }

    public void Start() { }
}
