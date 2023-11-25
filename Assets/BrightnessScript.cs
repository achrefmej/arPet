using UnityEngine;
using UnityEngine.UI;

public class BrightnessScript : MonoBehaviour
{
    public Image brightnessImage;
    public Text brightnessText;

    private float currentBrightness;

    void Start()
    {
        currentBrightness = Screen.brightness;
        UpdateBrightnessUI();
    }

    void Update()
    {
        // Get the current brightness level.
        float newBrightness = Screen.brightness;

        // Check if the brightness has changed.
        if (Mathf.Abs(newBrightness - currentBrightness) > 0.01f) // Add a small epsilon to handle floating-point precision issues.
        {
            // Update the current brightness level.
            currentBrightness = newBrightness;

            // Update the brightness text.
            brightnessText.text = "Brightness: " + currentBrightness.ToString("F2");

            // Enable or disable the UI image based on the brightness value.
            if (currentBrightness < 0.5f)
            {
                brightnessImage.enabled = true;
            }
            else
            {
                brightnessImage.enabled = false;
            }
        }
    }

    void UpdateBrightnessUI()
    {
        // Update the brightness text.
        brightnessText.text = "Brightness: " + currentBrightness.ToString("F2");

        // Enable or disable the UI image based on the initial brightness value.
        if (currentBrightness < 0.5f)
        {
            brightnessImage.enabled = true;
        }
        else
        {
            brightnessImage.enabled = false;
        }
    }
}
