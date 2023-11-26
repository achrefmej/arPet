using UnityEngine;
using UnityEngine.Audio;

public class ProximitySoundTrigger : MonoBehaviour
{
    [SerializeField] private AudioSource soundSource; // Serialized field for the AudioSource
    private bool isPlaying = false; // Flag to prevent multiple sound plays
    void Update()
    {
        // Check proximity sensor status
        bool isHandNear = CheckProximity();

        if (isHandNear && !isPlaying)
        {
            // Call a method to play the sound
            PlaySound();


        }
    }

    bool CheckProximity()
    {
        // Access the proximity sensor data (Android example)
        AndroidJavaObject context = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaObject sensorManager = context.Call<AndroidJavaObject>("getSystemService", "sensor");

        if (sensorManager != null)
        {
            AndroidJavaObject proximitySensor = sensorManager.Call<AndroidJavaObject>("getDefaultSensor", 8); // Sensor type 8 is the proximity sensor

            if (proximitySensor != null)
            {
                // Implement your logic to check the proximity value
                // For example, use a listener to receive sensor events

                // For the sake of this example, simulate the hand proximity.
                return SimulateProximity();
            }
        }

        // Default to false if unable to access the sensor
        return false;
    }

    bool SimulateProximity()
    {
        // Simulating proximity for demonstration purposes.
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
