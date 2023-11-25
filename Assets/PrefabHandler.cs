using UnityEngine;
using UnityEngine.UI;

public class PrefabHandler : MonoBehaviour
{
    public Image[] uiImages; // Array of UI Images to be disabled
    public float checkInterval = 2.0f; // Time interval to check for the presence of wolves

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= checkInterval)
        {
            timer = 0f; // Reset the timer

            GameObject[] wolves = GameObject.FindGameObjectsWithTag("Wolf");

            if (wolves.Length > 0 && uiImages != null && uiImages.Length > 0)
            {
                foreach (var wolf in wolves)
                {
                    foreach (var uiImage in uiImages)
                    {
                        if (uiImage != null)
                        {
                            uiImage.enabled = false;
                        }
                    }
                }
            }
        }
    }
}
