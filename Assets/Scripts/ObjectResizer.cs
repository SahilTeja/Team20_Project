using UnityEngine;
using System;

public class ObjectResizer : MonoBehaviour
{
    private bool isGrowing = false; // Flag to track growth state
    public float growTime = 1.0f;
    private float growthEnd = 0;

    public float growthAmount = 0.1f; // Amount to grow when it's night

    public void Start()
    {
        growthEnd=Time.time;
    }

    // Start growing the object
    public void OnDayNightChangeHandler()
    {
        Debug.Log("Time Change");
        // Check if it's night and the object should grow
        if (DayNightCycleManager.Instance.IsDay() && (GetComponent<DummyPlant>().WaterLevel >= GetComponent<DummyPlant>().neededWater))
        {
            Debug.Log("DayTime");
            growthEnd = Time.time + growTime;
            GetComponent<DummyPlant>().WaterLevel = (GetComponent<DummyPlant>().WaterLevel - GetComponent<DummyPlant>().neededWater);
            if(GetComponent<DummyPlant>().WaterLevel < 0)
            {
                GetComponent<DummyPlant>().WaterLevel = 0;
            }
            return;
        }
        if(DayNightCycleManager.Instance.IsDay() && (GetComponent<DummyPlant>().WaterLevel < GetComponent<DummyPlant>().neededWater))
        {
            GetComponent<DummyPlant>().WaterLevel = (GetComponent<DummyPlant>().WaterLevel - GetComponent<DummyPlant>().neededWater);
            if(GetComponent<DummyPlant>().WaterLevel < 0)
            {
                GetComponent<DummyPlant>().WaterLevel = 0;
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
        transform.localScale += Vector3.one * growthAmount * Time.deltaTime;
        
    }
}
