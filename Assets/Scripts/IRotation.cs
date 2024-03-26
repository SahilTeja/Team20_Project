using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IRotation : Interaction
{
    public float speed = 50f;
    public bool joystickMode = false;

    public override void interact()
    {
        if (SystemInfo.deviceType == DeviceType.Desktop && !Input.GetKey(KeyCode.JoystickButton1))
            return;
        else if (SystemInfo.deviceType == DeviceType.Handheld && !Input.GetKey(KeyCode.JoystickButton2))
            return;
        if (DebugMode)
            Debug.Log(gameObject.transform.rotation);
        gameObject.transform.Rotate(0, Time.deltaTime * speed, 0);

        if (DebugMode)
            Debug.Log(gameObject.transform.rotation);
        Physics.SyncTransforms();

    }

    public void Update() { }

    public void Start() { }

}

