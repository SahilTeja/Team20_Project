using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerbedSeed : MonoBehaviour
{
    private GameObject[] dirtPiles;
    [SerializeField]
    private float maxDistance = 0.1f;

    [SerializeField]
    private GameObject daikon;
    [SerializeField]
    public GameObject radish;
    [SerializeField]
    public GameObject parsnip;
    [SerializeField]
    public GameObject beet;

    //DaikonParsnipRadishBeet

    void Start()
    {
        // Find Dirt_Pile objects by their tags
        dirtPiles = GameObject.FindGameObjectsWithTag("DirtPile");
        
        // Check if any Dirt_Pile objects are found
        if (dirtPiles.Length == 0)
        {
            Debug.LogWarning("No Dirt_Pile objects found.");
        }
    }


    void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        if (SystemInfo.deviceType == DeviceType.Desktop && (Input.GetKeyDown(KeyCode.JoystickButton1) || Input.GetKeyDown(KeyCode.N)) || (SystemInfo.deviceType == DeviceType.Handheld && Input.GetKeyDown(KeyCode.JoystickButton10)))
        {
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("DirtPile")){
                        if (hit.collider.gameObject.transform.childCount == 0)
                            InstantiateSeed(hit.collider.gameObject);
                }
            }
        }
        
    }

    void InstantiateSeed(GameObject parent)
    {
        // Adjust the position slightly above the dirt pile's position
        //position += Vector3.up * 0.1f;
        GameObject obj = parsnip;

        switch(CCEMenu.getSelection())
        {
            case "Daikon":
                obj = daikon;
                break;
            case "Beet":
                obj = beet;
                break;
            case "Radish":
                obj = radish;
                break;
            case "Parsnip":
                obj = parsnip;
                break;
        }
        Quaternion randomRotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
        Instantiate(obj, parent.transform.position, randomRotation,parent.transform );
    }
}