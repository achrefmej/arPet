using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ProximitySoundTrigger : MonoBehaviour
{
    [SerializeField] private Text proximityText;
    [SerializeField] private AudioSource soundSource; // Serialized field for the AudioSource
    private bool isPlaying = false; // Flag to prevent multiple sound plays
    private AndroidJavaObject sensorManager;
    private AndroidJavaObject proximitySensor;


    void Start()
    {
        // Acc�der au gestionnaire de capteurs et au capteur de proximit�
        AndroidJavaObject context = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
        sensorManager = context.Call<AndroidJavaObject>("getSystemService", "sensor");
        proximitySensor = sensorManager.Call<AndroidJavaObject>("getDefaultSensor", 8); // Le type de capteur 8 est le capteur de proximit�

        // Enregistrez un auditeur pour les �v�nements du capteur
        AndroidJavaObject sensorEventListener = new AndroidJavaObject("com.esprit.arPet.ProximitySensorEventListener", this);
        sensorManager.Call("registerListener", sensorEventListener, proximitySensor, 3); // SENSOR_DELAY_NORMAL
    }

    // Fonction appel�e depuis Android pour mettre � jour la valeur de proximit�
    public void UpdateProximityValue(float proximityValue)
    {
        // Afficher la valeur de proximit� sur l'objet Texte de l'interface utilisateur
        if (proximityText != null)
        {
            proximityText.text = proximityValue.ToString("F2");
            PlaySound();
        }
    }


    //void Start()
    //{
    //    // Access the sensor manager and the proximity sensor
    //    AndroidJavaObject context = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
    //    sensorManager = context.Call<AndroidJavaObject>("getSystemService", "sensor");
    //    proximitySensor = sensorManager.Call<AndroidJavaObject>("getDefaultSensor", 8); // Sensor type 8 is the proximity sensor

    //    // Register a listener for sensor events
    //    AndroidJavaObject sensorEventListener = new AndroidJavaObject("com.esprit.arPet.ProximitySensorEventListener");
    //    sensorManager.Call("registerListener", sensorEventListener, proximitySensor, 3); // SENSOR_DELAY_NORMAL
    //}


    //void Update()
    //{
    //    // Access the proximity value if needed
    //    float proximityValue = GetProximityValue();
    //    proximityText.text = proximityValue.ToString("F2");
    //    Debug.Log("Proximity Value: " + proximityValue);
    //    if (proximityValue == 0)
    //    {
    //        PlaySound();
    //    }
    //}

    //float GetProximityValue()
    //{
    //    // Implement the logic to get the proximity value
    //    // This could involve querying the sensor or reading values from the sensor event listener

    //    // For now, simulate the proximity value.
    //    return SimulateProximity();
    //}

    //float SimulateProximity()
    //{
    //    // Simulating proximity for demonstration purposes.
    //    return Mathf.PingPong(Time.time, 1f); // Change KeyCode.Space to your preferred key or replace this with actual sensor access code.
    //}

    void PlaySound()
    {
        // This function plays the sound when the hand is detected near the sensor.
        // Use the AudioSource provided in the serialized field.
        soundSource.Play();
        isPlaying = true;
    }
}
