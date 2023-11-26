using UnityEngine;
using UnityEngine.UI;

public class VibratorController : MonoBehaviour
{
    public float vibrationDuration = 0.2f; // Duration of the vibration in seconds

    // Start is called before the first frame update
    void Start()
    {
        // Find the UI button in the scene by tag or any other means
        Button yourButton = GameObject.FindWithTag("Vibrator").GetComponent<Button>();

        // Add a listener to call your function when the button is clicked
        yourButton.onClick.AddListener(() => TriggerVibration());
    }

    void TriggerVibration()
    {
        // Trigger vibration
        Handheld.Vibrate();
        // You can also specify a custom duration for the vibration (in milliseconds) using Handheld.Vibrate() as follows:
        // Handheld.Vibrate();
        // StartCoroutine(StopVibration(vibrationDuration));
    }

    // IEnumerator StopVibration(float duration)
    // {
    //     yield return new WaitForSeconds(duration);
    //     Handheld.Vibrate();
    // }
}
