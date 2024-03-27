using UnityEngine;

public class ObjectSizeController : MonoBehaviour
{
    public int waterComponent = 0; // Water component as integer value
    private ObjectResizer objectResizer;
    private int previousWaterComponent = 0;

    private void Start()
    {
        // Get reference to ObjectResizer
        objectResizer = FindObjectOfType<ObjectResizer>();

        // Subscribe to the day/night change event
        DayNightCycleManager.OnDayNightChange += OnDayNightChangeHandler;
    }

    private void OnDestroy()
    {
        // Unsubscribe from the event to prevent memory leaks
        DayNightCycleManager.OnDayNightChange -= OnDayNightChangeHandler;
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
