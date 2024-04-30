using UnityEngine;
using UnityEngine.UI;

public class ProgressBarManager : MonoBehaviour
{
    public Slider progressBar;
    public float maxWateringProgress = 20f; // Set the maximum watering progress
    private float wateringProgress = 0f;
    public CanvasGroup progressBarCanvas;

    void Start()
    {
        progressBarCanvas.alpha = 0f; // Hide the progress bar initially
        progressBarCanvas.interactable = false;
        progressBarCanvas.blocksRaycasts = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Update the slider value based on watering progress
        progressBar.value = wateringProgress / maxWateringProgress;

        // Show/hide the progress bar based on watering progress
        if (wateringProgress > 0f && wateringProgress < maxWateringProgress)
        {
            ShowProgressBar();
        }
        else
        {
            HideProgressBar();
        }
    }

    // Method to update watering progress
    public void UpdateWateringProgress(float amount)
    {
        wateringProgress += amount;

        // Clamp progress between 0 and maxWateringProgress
        wateringProgress = Mathf.Clamp(wateringProgress, 0f, maxWateringProgress);
    }

    // Method to show the progress bar
    private void ShowProgressBar()
    {
        progressBarCanvas.alpha = 1f;
        progressBarCanvas.interactable = true;
        progressBarCanvas.blocksRaycasts = true;
    }

    // Method to hide the progress bar
    private void HideProgressBar()
    {
        progressBarCanvas.alpha = 0f;
        progressBarCanvas.interactable = false;
        progressBarCanvas.blocksRaycasts = false;
    }
}
