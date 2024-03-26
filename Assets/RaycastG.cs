using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

public class RaycastG : MonoBehaviour
{

    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;
    Button activeButton;


    void Start()
    {
        m_Raycaster = GetComponent<GraphicRaycaster>();
        m_EventSystem = GetComponent<EventSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        m_PointerEventData = new PointerEventData(m_EventSystem);
        m_PointerEventData.position = new Vector3(Screen.width / 2, Screen.height / 2);
        List<RaycastResult> results = new List<RaycastResult>();
        m_Raycaster.Raycast(m_PointerEventData, results);

        foreach (RaycastResult result in results)
        {
            Button button = result.gameObject.GetComponent<Button>();
            if (button)
            {
                if (activeButton && activeButton != button)
                    activeButton.OnPointerExit(m_PointerEventData);
                activeButton = button;
                button.OnPointerEnter(m_PointerEventData);
            }
        }

        if (results.Count == 0 && activeButton)
        {
            activeButton.OnPointerExit(m_PointerEventData);
        }

        // Return if not a "b" button
        if (SystemInfo.deviceType == DeviceType.Desktop && !Input.GetKeyDown(KeyCode.JoystickButton10))
            return;
        else if (SystemInfo.deviceType == DeviceType.Handheld && !Input.GetKeyDown(KeyCode.JoystickButton5))
            return;

        //Set up the new Pointer Event
        m_PointerEventData = new PointerEventData(m_EventSystem);
        //Set the Pointer Event Position to that of the mouse position
        m_PointerEventData.position = new Vector3(Screen.width / 2, Screen.height / 2);

        //Create a list of Raycast Results
        results = new List<RaycastResult>();

        //Raycast using the Graphics Raycaster and mouse click position
        m_Raycaster.Raycast(m_PointerEventData, results);

        //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
        foreach (RaycastResult result in results)
        {
            Button button = result.gameObject.GetComponent<Button>();
            if (button)
            {
                button.onClick.Invoke();
            }     
        }
        
    }
}
