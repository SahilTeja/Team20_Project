using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CCEMenu : MonoBehaviour
{

    private Clipboard clipboard;
    private GameObject gameController;
    private MenuManager menuMan;
    private int[] speed = { 5, 10, 20 };
    private int speedIndex = 1;
    private int[] raycast = {50, 10, 1};
    private int rayIndex = 0;
    private CharacterMovement CM;
    private ViewActive VA;
    private TextMeshProUGUI textbox;


    public GameObject seedPrefab;
    public Transform spawnPoint;
    public GameObject menu;
    private bool ismenuOpen = false;
    

    // Start is called before the first frame update
    void Start()
    {
         
        CM = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>();
        gameController = GameObject.FindGameObjectWithTag("GameController");
        clipboard = gameController.GetComponent<Clipboard>();
        menuMan = gameController.GetComponent<MenuManager>();
        textbox = GetComponentInChildren<TextMeshProUGUI>();
        VA = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ViewActive>();
        if (!gameController)
        {
            Debug.LogError("GameController not found");
            return;
        }
        if(!menuMan)
            Debug.LogError("MenuManager not found on GameController");
        if (!clipboard)
            Debug.LogError("Clipboard not found on GameController");


        if (spawnPoint == null)
        {
            spawnPoint = transform;
        }

    }

    /*void Update()
    {
       /* if (SystemInfo.deviceType == DeviceType.Desktop && (Input.GetKey(KeyCode.JoystickButton3) && Input.GetKey(KeyCode.B)))
        {
            
            return;
        }
            
        else if (SystemInfo.deviceType == DeviceType.Handheld && Input.GetKey(KeyCode.JoystickButton3))
        {
            
            return;
        }
        if (Input.GetButtonDown("js3") && ismenuOpen == false)
        {
            Debug.LogError("open");
            menu.SetActive(true);
            ismenuOpen = true;


        }
        else if (Input.GetButtonDown("js3") && ismenuOpen == true)
        {
            Debug.LogError("close");
            menu.SetActive(false);
            ismenuOpen = false;

        }




    }*/

    public void Copy()
    {
        clipboard.Copy(transform.root.gameObject);
        clipboard.setCopy(true);
        Exit();
    }

    public void Cut()
    {
        Copy();
        clipboard.setCopy(false);
        transform.root.gameObject.SetActive(false);
    }

    public void Exit()
    {
        //menuMan.exitMenu();
        if (seedPrefab != null)
        {
            // Instantiate the seed prefab at the spawn point
            Instantiate(seedPrefab, spawnPoint.position, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Seed prefab is not assigned!");
        }
    }

    public void Raycast()
    {
        int temp = raycast[++rayIndex % raycast.Length];
        VA.distance = temp;
        textbox.text = "Raycast: " + temp;
    }

    public void Speed()
    {
        int temp = speed[++speedIndex % (speed.Length)];
        CM.speed = temp;
        textbox.text = "Speed: " + temp;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ToggleMenu()
    {
        
        
    }
    
}
    
