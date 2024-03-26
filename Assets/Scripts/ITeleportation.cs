using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ITeleportation : Interaction
{
    private GameObject player;
    public override void interact()
    {
        if (SystemInfo.deviceType == DeviceType.Desktop && !Input.GetKeyDown(KeyCode.JoystickButton0))
            return;
        else if (SystemInfo.deviceType == DeviceType.Handheld && !Input.GetKeyDown(KeyCode.JoystickButton3))
            return;
        if (DebugMode)
            Debug.Log("Player: " + player.transform.position);

        player.transform.position = this.transform.position;

        if (DebugMode)
            Debug.Log("Player: " + player.transform.position);

        Physics.SyncTransforms();
        Destroy(gameObject);
    }

    public void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

}
