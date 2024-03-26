using UnityEngine;
using UnityEngine.Events;

public class DayNightCycleManager : MonoBehaviour
{
    public static event UnityAction<bool> OnDayNightChange;

    private bool isDayTime = true; // Assuming it starts as daytime

    // Method to toggle day/night cycle
    public void ToggleDayNightCycle()
    {
        isDayTime = !isDayTime;
        if (OnDayNightChange != null)
        {
            OnDayNightChange.Invoke(isDayTime);
        }
    }
}

