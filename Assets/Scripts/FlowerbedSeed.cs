using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerbedSeed : MonoBehaviour
{
    public GameObject[] dirtPiles = new GameObject[7]; // Array to store the Dirt_Pile objects
    public float maxDistance = 0.1f; // Maximum distance from raycast hit point to dirt pile

    void Start()
    {

        string debugArray = "";
        // Find Dirt_Pile objects by their tags
        GameObject[] allDirtPiles = GameObject.FindGameObjectsWithTag("DirtPile");
        for (int i = 0; i < Mathf.Min(allDirtPiles.Length, dirtPiles.Length); i++)
        {
            dirtPiles[i] = allDirtPiles[i];
            debugArray += dirtPiles[i].name + " ";
        }

        Debug.Log(debugArray);

        // Check if the number of Dirt_Pile objects found matches the array size
        if (allDirtPiles.Length < dirtPiles.Length)
        {
            Debug.LogWarning("Number of Dirt_Pile objects found is less than expected.");
        }
    }

    void Update()
    {
        // Create a ray from the center of the screen
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        if (SystemInfo.deviceType == DeviceType.Desktop && (Input.GetKeyDown(KeyCode.JoystickButton1) || Input.GetKeyDown(KeyCode.B)) || (SystemInfo.deviceType == DeviceType.Handheld && Input.GetKeyDown(KeyCode.JoystickButton2)))
        {
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.green); // Draw the raycast for debugging

                if(hit.transform.CompareTag("DirtPile"))
                {
                    Debug.Log("Hit " + hit.transform.name);
                }

                for (int i = 0; i < dirtPiles.Length; i++)
                {
                    if (hit.collider.gameObject == dirtPiles[i] && Vector3.Distance(hit.point, dirtPiles[i].transform.position) < maxDistance)
                    {
                        Debug.Log("Raycast hit dirt pile " + dirtPiles[i].name);
                        InstantiateSeed(dirtPiles[i].transform.position);
                        break;
                    }
                }
            }
        }
        
    }

    void InstantiateSeed(Vector3 position)
    {
        position += Vector3.up * 0.1f;
        Debug.Log("Seed instantiated at position: " + position);

        GameObject seed = GameObject.CreatePrimitive(PrimitiveType.Sphere); // Create a sphere object
        seed.transform.position = position; // Set the position to the dirt pile's position
        seed.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f); // Adjust scale as needed
        seed.GetComponent<Renderer>().material.color = Color.yellow; // Adjust color as needed
    }
}
