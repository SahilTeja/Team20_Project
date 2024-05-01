/*using UnityEngine;
using UnityEngine.UI;

public class ProgressBarManager : MonoBehaviour
{
    public Slider progressBar;
    public int maxWaterLevel = 20; // Maximum water level for the progress bar

    // Update the progress bar based on the water level
    public void UpdateProgressBar(int waterLevel)
    {
        progressBar.value = (float)waterLevel / maxWaterLevel;
    }
}*/


using UnityEngine;
using UnityEngine.UI;

public class ProgressBarManager : MonoBehaviour
{
    public Slider progressBar;
    public int maxWaterLevel = 20; // Maximum water level for the progress bar

    private void Start()
    {
        progressBar.gameObject.SetActive(false); // Hide the progress bar initially
    }

    // Update the progress bar based on the water level
    public void UpdateProgressBar(int waterLevel)
    {
        if (!progressBar.gameObject.activeSelf && waterLevel > 0)
        {
            progressBar.gameObject.SetActive(true); // Show the progress bar when watering starts
        }

        progressBar.value = (float)waterLevel / maxWaterLevel;

        if (waterLevel >= maxWaterLevel)
        {
            progressBar.gameObject.SetActive(false); // Hide the progress bar when it reaches the limit
        }
    }
}


