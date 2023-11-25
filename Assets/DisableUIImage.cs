using UnityEngine;
using UnityEngine.UI;

public class DisableUIImage : MonoBehaviour
{
    public Image[] uiImages; // Reference to an array of UI Images you want to disable

    // This method is called when the button is pressed
    public void OnButtonPress()
    {
        if (uiImages != null && uiImages.Length > 0)
        {
            // Disable each UI Image in the array
            foreach (Image image in uiImages)
            {
                if (image != null)
                {
                    image.enabled = false;
                }
                else
                {
                    Debug.LogError("One or more UI Image references in the array are not set. Please assign all UI Images in the Unity Editor.");
                }
            }
        }
        else
        {
            Debug.LogError("UI Image array reference not set or empty. Please assign the UI Images array in the Unity Editor.");
        }
    }
}
