using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private GameObject currentMenu = null;
    private GameObject player;
    private PerspectiveController control;
    private ViewActive VA;
    private RaycastActions RA;
    private GameObject camera;

    public void Start()
    {
        player = GameObject.FindWithTag("Player");
        control = player.GetComponent<PerspectiveController>();
        VA = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ViewActive>();
        RA = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<RaycastActions>();
        camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    public void openMenu(GameObject menu)
    {
        if (currentMenu != null)
            currentMenu.SetActive(false);
        currentMenu = menu;
        currentMenu.SetActive(true);
        control.SetCharacterController(false);
    }

    public void openMainMenu(GameObject menu)
    {
        menu.transform.position = player.transform.position + camera.transform.forward * 3 + Vector3.up*1.5f;
        openMenu(menu);
        VA.active = false;
        RA.enabled = false;
    }

    public void exitMenu()
    {
        if (currentMenu!=null)
        currentMenu.SetActive(false);
        control.SetCharacterController(true);
        currentMenu = null;
        VA.active = true;
        RA.enabled = true;
    }
}
