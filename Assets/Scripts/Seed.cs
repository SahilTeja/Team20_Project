using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{
    private int numStages = 1;
    public int currentStage = 0;
    private DummyPlant soil;
    private ObjectResizer crop;

    public void Start()
    {
        Transform parentTransform = transform.parent;
        if (parentTransform != null)
        {
            // Iterate over the parent's children to find the desired component
            foreach (Transform child in parentTransform)
            {
                // Check if the child has the desired component
                crop = child.GetComponent<ObjectResizer>();
                if (crop != null)
                {
                    // Found the component in one of the parent's children
                    Debug.Log("Found ObjectResizer in child: " + child.name);
                    break; // Exit the loop if component is found
                }
            }
        }
        else
        {
            // No parent GameObject
            Debug.Log("No parent GameObject found.");
        }
        soil = GetComponentInParent<DummyPlant>();
        DayNightCycleManager.Instance.OnDayNightChange.AddListener(this.OnDayNightChangeHandler);
    }

    // Start growing the object
    public void OnDayNightChangeHandler()
    {
        Debug.Log("Time Change");
        // Check if it's night and the object should grow
        if (DayNightCycleManager.Instance.IsDay() && (soil.WaterLevel >= soil.neededWater))
        {
            Debug.Log("DayTime");
            currentStage++;
            if(currentStage >= numStages)
            {
                crop.gameObject.SetActive(true);
                Destroy(this.gameObject);
            }
            soil.WaterLevel = (soil.WaterLevel - soil.neededWater);
            if(soil.WaterLevel < 0)
            {
                soil.WaterLevel = 0;
            }
            return;
        }
        if(DayNightCycleManager.Instance.IsDay() && (soil.WaterLevel < soil.neededWater))
        {
            soil.WaterLevel = (soil.WaterLevel - soil.neededWater);
            if(soil.WaterLevel < 0)
            {
                soil.WaterLevel = 0;
            }

            return;
        }
    }
}
