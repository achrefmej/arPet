using UnityEngine;
using TMPro;

public class StatusDetector : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public GameObject statusObject; // Reference to the GameObject to enable/disable
    private string previousText;

    void Start()
    {
        if (textMeshPro == null)
        {
            Debug.LogError("TextMeshPro component not set. Please assign the TextMeshPro component in the Unity Editor.");
        }

        if (statusObject == null)
        {
            Debug.LogError("Status GameObject not set. Please assign the GameObject in the Unity Editor.");
        }

        previousText = textMeshPro.text;
        CheckStatus();
    }

    void Update()
    {
        if (textMeshPro != null && textMeshPro.text != previousText)
        {
            // Check if the word "status" is in the new text
            CheckStatus();

            // Update the previous text for the next comparison
            previousText = textMeshPro.text;
        }
    }

    void CheckStatus()
    {
        if (textMeshPro != null && textMeshPro.text.ToLower().Contains("status"))
        {
            // Enable the GameObject when the word "status" is detected
            if (statusObject != null)
            {
                statusObject.SetActive(true);
            }
        }
        else
        {
            // Disable the GameObject when the word changes
            if (statusObject != null)
            {
                statusObject.SetActive(false);
            }
        }
    }
}
