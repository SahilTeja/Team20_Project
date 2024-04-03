using UnityEngine;

public class DummyPlant : MonoBehaviour
{
    public int WaterLevel;
    public ParticleSystem water;
    public Color initial;
    public Color final;
    public float maxWater;
    public Vector3 initialScale; // Store the initial scale of the object

    void Start()
    {
        WaterLevel = 0;
        initialScale = transform.localScale; // Store the initial scale
        ObjectResizer resizer = GetComponent<ObjectResizer>(); // Get ObjectResizer component
        if (resizer != null)
        {
            // Subscribe to the OnDayNightChange event
            DayNightCycleManager.Instance.OnDayNightChange.AddListener(resizer.OnDayNightChangeHandler);
        }
        else
        {
            Debug.LogError("ObjectResizer component not found on the object.");
        }
    }

    void Update()
    {
        // Existing code to maintain water level and color interpolation
        Color lerpedColor = Color.Lerp(initial, final, Mathf.Clamp(WaterLevel, 0f, maxWater) / maxWater);
        GetComponent<Renderer>().material.SetColor("_Color", lerpedColor);
    }

    void OnParticleCollision(GameObject other)
    {
        if (WaterLevel <= 20)
            WaterLevel++;
    }
}
