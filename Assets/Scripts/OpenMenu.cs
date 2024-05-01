using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenu : Interaction
{

    private MenuManager menuMan;
    private GameObject menu;
    
    private void Start()
    {
        menuMan = GameObject.FindGameObjectWithTag("GameController").GetComponent<MenuManager>();
        menu = transform.root.Find("Canvas").gameObject;
        
    }

    public override void interact()
    {
        // Button is "x"
        if (SystemInfo.deviceType == DeviceType.Desktop && !Input.GetKeyDown(KeyCode.JoystickButton1))
            return;
        else if (SystemInfo.deviceType == DeviceType.Handheld && !Input.GetKeyDown(KeyCode.JoystickButton2))
            return;

        if (DebugMode)
            Debug.Log("Interacting");

        

        menuMan.openMenu(menu);
        
    }
}
