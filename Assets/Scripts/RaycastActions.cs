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

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
        clipboard = gameController.GetComponent<Clipboard>();
        player = GameObject.FindGameObjectWithTag("Player");
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
                if (clipboard.Paste())
                {
                    GameObject obj = clipboard.Paste();
                    if (clipboard.isCopy())
                        obj = Instantiate(clipboard.Paste(), hit.point + Vector3.up * (clipboard.Paste().transform.localScale.y / 2), Quaternion.identity);
                    else
                        obj.transform.position = hit.point + Vector3.up * (clipboard.Paste().transform.localScale.y / 2);
                    obj.SetActive(true);
                    obj.GetComponentInChildren<Canvas>().gameObject.SetActive(false);
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
        if (SystemInfo.deviceType == DeviceType.Desktop && !Input.GetKeyDown(KeyCode.JoystickButton8))
            return false;
        else if (SystemInfo.deviceType == DeviceType.Handheld && !Input.GetKeyDown(KeyCode.JoystickButton10))
            return false;
        return true;
    }
}
