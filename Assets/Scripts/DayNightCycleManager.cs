using UnityEngine;
using UnityEngine.Events;

public class DayNightCycleManager : MonoBehaviour
{
    // Event declaration
    public UnityEvent OnDayNightChange = new UnityEvent();

    public Color dayColor;
    public Color nightColor;
    public Color dayFog;
    public Color nightFog;
    public float dayDensity;
    public float nightDensity;
    public float dayIntensity;
    public float nightIntensity;
    public float duration = 0.5f;
    private bool isDay;
    private float changeTime = 0f;
    private int numberOfDays = 0;

    // Static instance property
    private static DayNightCycleManager _instance;
    public static DayNightCycleManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<DayNightCycleManager>();
                if (_instance == null)
                {
                    Debug.LogError("No DayNightCycleManager instance found in the scene.");
                }
            }
            return _instance;
        }
    }

    void Start()
    {
        RenderSettings.skybox = new Material(RenderSettings.skybox);
        isDay = true;
        changeTime = -duration;
    }

    public void changeDay()
    {
        changeTime = Time.time;
        isDay = !isDay;
        numberOfDays++;

        // Trigger the event when day/night changes
        OnDayNightChange?.Invoke();
    }

    public bool IsDay()
    {
        return isDay;
    }

    public int GetNumDays()
    {
        return numberOfDays / 2;
    }

    void Update()
    {
        float lerp = Mathf.PingPong(Mathf.Clamp(Time.time - changeTime, 0f, duration), duration) / duration;

        if (isDay)
        {
            RenderSettings.skybox.SetColor("_Tint", Color.Lerp(nightColor, dayColor, lerp));
            RenderSettings.fogColor = Color.Lerp(nightFog, dayFog, lerp);
            RenderSettings.fogDensity = Mathf.Lerp(nightDensity, dayDensity, lerp);
            RenderSettings.ambientIntensity = Mathf.Lerp(nightIntensity, dayIntensity, lerp);
        }
        else
        {
            RenderSettings.skybox.SetColor("_Tint", Color.Lerp(dayColor, nightColor, lerp));
            RenderSettings.fogColor = Color.Lerp(dayFog, nightFog, lerp);
            RenderSettings.fogDensity = Mathf.Lerp(dayDensity, nightDensity, lerp);
            RenderSettings.ambientIntensity = Mathf.Lerp(dayIntensity, nightIntensity, lerp);
        }

        if (SystemInfo.deviceType == DeviceType.Desktop && (!Input.GetKeyDown(KeyCode.JoystickButton9) && !(Input.GetKeyDown(KeyCode.C))))
            return;
        else if (SystemInfo.deviceType == DeviceType.Handheld && !Input.GetKeyDown(KeyCode.JoystickButton11))
            return;
        changeDay();

    }
}
