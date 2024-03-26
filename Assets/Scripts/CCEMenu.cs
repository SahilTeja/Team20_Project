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

    }

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
        menuMan.exitMenu();
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


}