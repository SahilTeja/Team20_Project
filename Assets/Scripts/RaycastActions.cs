using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastActions: MonoBehaviour
{
    public float distance = 50;
    private Clipboard clipboard;
    private GameObject gameController;
    private GameObject player;
    private bool isActive = true;
    private bool hasPlant;
    private AudioSource audio;
    public AudioClip harvest;
    public AudioClip box;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
        clipboard = gameController.GetComponent<Clipboard>();
        player = GameObject.FindGameObjectWithTag("Player");
        audio = GetComponent<AudioSource>();
        if (!gameController)
        {
            Debug.LogError("GameController not found");
            return;
        }
        if (!player)
        {
            Debug.LogError("Player not found");
            return;
        }
        if (!clipboard)
            Debug.LogError("Clipboard not found on GameController");

        hasPlant = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive)
            return;
        if (Physics.Raycast(transform.position, transform.forward, out var hit, distance))
        {
            if (IsAPressed())
            {
                Debug.Log("A Pressed");
                GameObject obj = hit.transform.gameObject;
                Debug.Log("Hit: " + obj.name + ", " + obj.tag);
                if(obj.tag == "TurnIn")
                {
                    if(hasPlant)
                    {
                        Debug.Log("Plant Turned In");
                        audio.PlayOneShot(box, 0.7f);
                        GameObject player = GameObject.FindGameObjectWithTag("Player");
                        player.GetComponent<WeaponSwitcher>().changeWeapon(0);
                        hasPlant = false;
                        return;
                    }
                }
                else if(obj.tag == "Plant")
                {   
                    Debug.Log("Detected Plant");
                    if(obj.GetComponent<ObjectResizer>().isHarvestable() && !hasPlant)
                    {
                        Debug.Log("Plant is Harvestable");
                        audio.PlayOneShot(harvest, 0.7f);
                        player.GetComponent<WeaponSwitcher>().changeWeapon(obj.GetComponent<ObjectResizer>().plantType);
                        obj.GetComponent<ObjectResizer>().Harvest();
                        hasPlant = true;
                        return;
                    }
                    Debug.Log("Plant is not Harvestable");
                    return;
                }   
            }
            else if (IsYPressed())
            {
                player.transform.position = hit.point+ new Vector3(0f, 0.5f, 0f);
                Debug.Log("Teleport");
                Physics.SyncTransforms();
            }

        }
    }

    private bool IsYPressed()
    {
        if (SystemInfo.deviceType == DeviceType.Desktop && !Input.GetKeyDown(KeyCode.JoystickButton0))
            return false;
        else if (SystemInfo.deviceType == DeviceType.Handheld && !Input.GetKeyDown(KeyCode.JoystickButton3))
            return false;
        return true;
    }

    private bool IsAPressed()
    {
        if (SystemInfo.deviceType == DeviceType.Desktop && !Input.GetKeyDown("k"))
            return false;
        else if (SystemInfo.deviceType == DeviceType.Handheld && !Input.GetKeyDown(KeyCode.JoystickButton5))
            return false;
        return true;
    }
}
