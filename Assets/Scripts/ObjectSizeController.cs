using UnityEngine;

public class ObjectSizeController : MonoBehaviour
{
    public int waterComponent = 0; // Water component as integer value
    public float maxScale = 2.0f;
    public float minScale = 0.5f;
    public string controllerButton = "ButtonX"; // Name of the button on the controller

    private ObjectResizer objectResizer;
    private DayNightCycleManager dayNightCycleManager;
    private int previousWaterComponent = 0;

    private void Start()
    {
        // Get reference to ObjectResizer
        objectResizer = FindObjectOfType<ObjectResizer>();

        // Get reference to DayNightCycleManager
        dayNightCycleManager = FindObjectOfType<DayNightCycleManager>();

        // Subscribe to the day/night change event
        if (dayNightCycleManager != null)
        {
            dayNightCycleManager.OnDayNightChange += OnDayNightChangeHandler;
        }
    }

    private void OnDestroy()
    {
        // Unsubscribe from the events to prevent memory leaks
        if (dayNightCycleManager != null)
        {
            dayNightCycleManager.OnDayNightChange -= OnDayNightChangeHandler;
        }
    }

    private void Update()
    {
        // Your existing code for handling water pouring
        if (Input.GetButtonDown("js1"))
        {
            // Check if the raycast hits this object
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.up, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    // Increase the water component
                    waterComponent++;
                }
            }
        }
    }

    private void OnDayNightChangeHandler(bool isDayTime)
    {
        // Check if a full day/night cycle has passed and waterComponent is greater than 0
        if (isDayTime && waterComponent > 0)
        {
            // Resize the object
            if (objectResizer != null)
            {
                objectResizer.ResizeObject();
            }
        }

        // Update previous water component
        previousWaterComponent = waterComponent;
    }
}
