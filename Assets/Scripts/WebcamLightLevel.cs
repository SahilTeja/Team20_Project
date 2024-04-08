using UnityEngine;

public class WebcamLightLevel : MonoBehaviour
{
    public bool webcamEnabled = true;
    public float scaleRatio = 8f;
    public float lowLightThreshold = 90f;
    public float transitionDuration = 0.25f;
    public GUIStyle guiStyle = new GUIStyle();
    public bool showWebcamAndLight = true;

    private WebCamTexture webcamTexture;
    private Rect webcamRect;
    private Rect lightLevelRect;

    private float transitionTimer = 0f;

    private DayNightCycleManager dayManager;

    void Start()
    {
        webcamTexture = new WebCamTexture();
        webcamTexture.Play();

        guiStyle.fontSize = 16;
        guiStyle.normal.textColor = Color.white;
        webcamRect = new Rect(Screen.width - Screen.width / scaleRatio, Screen.height - Screen.height / scaleRatio, Screen.width / scaleRatio, Screen.height / scaleRatio);
        lightLevelRect = new Rect(Screen.width - 210, Screen.height - 30, 200, 20);
        dayManager = DayNightCycleManager.Instance;
    }

    void Update()
    {
        if (!webcamEnabled)
            return;

        float lightLevel = CalculateLightLevel();

        if (dayManager.IsDay())
        {
            if (lightLevel < lowLightThreshold)
            {
                transitionTimer += Time.deltaTime;

                if (transitionTimer >= transitionDuration)
                {
                    dayManager.setDay(false);
                    transitionTimer = 0f;
                }
            }
            else
            {
                transitionTimer = 0f;
            }
        }
        else
        {
            if (lightLevel > lowLightThreshold)
            {
                transitionTimer += Time.deltaTime;

                if (transitionTimer >= transitionDuration)
                {
                    dayManager.setDay(true);
                    transitionTimer = 0f;
                }
            }
            else
            {
                transitionTimer = 0f;
            }
        }
    }

    void OnGUI()
    {
        if(!webcamEnabled)
            return;

        if (showWebcamAndLight)
        {
            GUI.DrawTexture(webcamRect, webcamTexture, ScaleMode.ScaleToFit);
            GUI.Label(lightLevelRect, "Light Level: " + CalculateLightLevel().ToString("F2"), guiStyle);
        }
    }

    float CalculateLightLevel()
    {
        Color32[] pixels = webcamTexture.GetPixels32();

        float totalBrightness = 0;

        // Iterate through each pixel
        foreach (Color32 pixel in pixels)
        {
            float brightness = (pixel.r + pixel.g + pixel.b) / 3.0f;
            totalBrightness += brightness;
        }
        float averageBrightness = totalBrightness / pixels.Length;

        return averageBrightness;
    }

    void OnDisable()
    {
        if (webcamTexture != null && webcamTexture.isPlaying)
        {
            webcamTexture.Stop();
        }
    }
}
