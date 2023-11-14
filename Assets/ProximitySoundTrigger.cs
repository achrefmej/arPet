using UnityEngine;

public class ProximitySoundTrigger : MonoBehaviour
{
    [SerializeField] private AudioSource soundSource; // Serialized field for the AudioSource
    private bool isHandNear = false; // Flag to indicate if hand is near the sensor
    private bool isPlaying = false; // Flag to prevent multiple sound plays

    void Update()
    {
        // Check proximity sensor status
        isHandNear = CheckProximity();

        if (isHandNear && !isPlaying)
        {
            // Call a method to play the sound
            PlaySound();
        }
    }

    bool CheckProximity()
    {
        // You need to implement platform-specific code to access the proximity sensor.
        // For Android, you could use Input.GetButtonDown("proximitySensor").
        // For iOS, you might need to use the ARKit or other platform-specific APIs.
        // Example: for Android
        // return Input.GetButtonDown("proximitySensor");

        // For the sake of this example, simulate the hand proximity.
        // Replace this with actual sensor access code for your target platform.
        return SimulateProximity();
    }

    bool SimulateProximity()
    {
        // Simulating proximity by pressing a key for demonstration purposes.
        return Input.GetKeyDown(KeyCode.Space); // Change KeyCode.Space to your preferred key or replace this with actual sensor access code.
    }

    void PlaySound()
    {
        // This function plays the sound when the hand is detected near the sensor.
        // Use the AudioSource provided in the serialized field.
        soundSource.Play();

        isPlaying = true;
    }
}
