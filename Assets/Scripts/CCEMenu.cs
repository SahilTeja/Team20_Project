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
    public TextMeshProUGUI tutorialText;

    public GameObject seedPrefab;
    public Transform spawnPoint;


    public GameObject instructionsPanel; // Reference to the panel containing the instructions
    public Button tutorialButton;
    public Button daikonButton;
    public Button parsnipButton;
    public Button beetButton;
    public Button radishButton;

   

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

        // Ensure the instructions panel is initially hidden
        instructionsPanel.SetActive(false);

        // Add a listener to the tutorial button's onClick event
        tutorialButton.onClick.AddListener(ShowInstructions);
    }
    
    public void ShowInstructions()
    {
        // Show the instructions panel when the tutorial button is clicked
        tutorialButton.gameObject.SetActive(false);
        daikonButton.gameObject.SetActive(false);
        parsnipButton.gameObject.SetActive(false);
        beetButton.gameObject.SetActive(false);
        radishButton.gameObject.SetActive(false);
        instructionsPanel.SetActive(true);
    }

    public void Copy()
    {
        clipboard.Copy(transform.root.gameObject);
        clipboard.setCopy(true);
        Daikon();
    }

    public void Cut()
    {
        Copy();
        clipboard.setCopy(false);
        transform.root.gameObject.SetActive(false);
    }

    public void Daikon()
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

    public void Parsnip()
    {
        
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

    public void Radish()
    {
       
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

    public void Beet()
    {
        
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

    
    }

    
