using UnityEngine;
using System;

public class ObjectResizer : MonoBehaviour
{
    private bool isGrowing = false; // Flag to track growth state
    public float growTime = 1.0f;
    private float growthEnd = 0;
    private GameObject effect;

    public int numStages = 3;
    public int currentStage = 0;

    public float growthAmount = 0.1f; // Amount to grow when it's night

    public int plantType;

    private DummyPlant soil;

    public void Start()
    {
        growthEnd=Time.time;
        soil = GetComponentInParent<DummyPlant>();
        effect = transform.GetChild(0).gameObject;
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
            growthEnd = Time.time + growTime;
            currentStage++;
            if(currentStage >= numStages)
            {
                effect.SetActive(true);
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

    public bool isHarvestable()
    {
        return currentStage >= numStages;
    }

    public void Harvest()
    {
        Destroy(gameObject);
    }
    
}
