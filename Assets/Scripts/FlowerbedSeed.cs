using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerbedSeed : MonoBehaviour
{
    public GameObject[] dirtPiles;
    public float maxDistance = 0.1f; 

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

        if (SystemInfo.deviceType == DeviceType.Desktop && (Input.GetKeyDown(KeyCode.JoystickButton1) || Input.GetKeyDown(KeyCode.B)) || (SystemInfo.deviceType == DeviceType.Handheld && Input.GetKeyDown(KeyCode.JoystickButton2)))
        {
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.green); // Draw the raycast for debugging

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
        // Adjust the position slightly above the dirt pile's position
        position += Vector3.up * 0.1f;

        Debug.Log("Seed instantiated at position: " + position);

        GameObject seed = GameObject.CreatePrimitive(PrimitiveType.Sphere); // Create a sphere object
        seed.transform.position = position; // Set the position to the dirt pile's position
        seed.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f); // Adjust scale as needed
        seed.GetComponent<Renderer>().material.color = Color.yellow; // Adjust color as needed
    }
}
