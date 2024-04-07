using UnityEngine;
using System;

public class ObjectResizer : MonoBehaviour
{
    private bool isGrowing = false; // Flag to track growth state
    public float growTime = 1.0f;
    private float growthEnd = 0;

    public int numStages = 3;
    private int currentStage = 0;

    public float growthAmount = 0.1f; // Amount to grow when it's night

    private DummyPlant soil;

    public void Start()
    {
        growthEnd=Time.time;
        soil = GetComponentInParent<DummyPlant>();
    }

    // Start growing the object
    public void OnDayNightChangeHandler()
    {
        Debug.Log("Time Change");
        // Check if it's night and the object should grow
        if (DayNightCycleManager.Instance.IsDay() && (soil.WaterLevel >= soil.neededWater))
        {
            Debug.Log("DayTime");
            growthEnd = Time.time + growTime;
            currentStage++;
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

    void Update()
    {
        // If it's growing, increase the size
        if (growthEnd > Time.time)
        {
            Grow();
        }
        
    }

    // Increase the size of the object
    void Grow()
    {
        if (currentStage <= numStages)
        {
            transform.localScale += Vector3.one * growthAmount * Time.deltaTime;
        }
            
    }

    bool isHarvestable()
    {
        return currentStage >= 3;
    }
    
}
