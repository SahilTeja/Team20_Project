// using UnityEngine;

// public class ObjectSizeController : MonoBehaviour
// {
//      // Water component as integer value
//     private ObjectResizer objectResizer;
//     private int previousWaterComponent = 0;
//     public Color initial;
//     public Color final;
//     public float maxWater;
//     private int WaterLevel;

//     private void Start()
//     {
//         // Get reference to ObjectResizer
//         objectResizer = FindObjectOfType<ObjectResizer>();

//         // Subscribe to the day/night change event
//         DayNightCycleManager.OnDayNightChange += OnDayNightChangeHandler;
//     }

//     private void OnDestroy()
//     {
//         // Unsubscribe from the event to prevent memory leaks
//         DayNightCycleManager.OnDayNightChange -= OnDayNightChangeHandler;
//     }

//     private void Update()
//     {
//         Color lerpedColor = Color.Lerp(initial, final, Mathf.Clamp(WaterLevel, 0f, maxWater) / maxWater);
//         GetComponent<Renderer>().material.SetColor("_Color", lerpedColor);
//     }

//         void OnParticleCollision(GameObject other)
//         {
//             if(WaterLevel <= 20)
//                 WaterLevel++;
//         }

//     private void OnDayNightChangeHandler(bool isDayTime)
//     {
//         // Check if a full day/night cycle has passed and waterComponent is greater than 0
//         if (isDayTime && WaterLevel > 0)
//         {
//             // Resize the object
//             if (objectResizer != null)
//             {
//                 objectResizer.ResizeObject();
//             }
//         }

//         // Update previous water component
//         previousWaterComponent = WaterLevel;
//     }
// }
