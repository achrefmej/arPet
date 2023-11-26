using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeController : MonoBehaviour
{
    public float shakeThreshold = 2.0f; // Adjust this value as needed for sensitivity
    public float minShakeInterval = 1.0f; // Minimum time between shake events

    public Animator prefabAnimator; // Serialized field for the prefab's Animator component

    private float lastShakeTime;

    void Update()
    {
        // Get the accelerometer values
        Vector3 acceleration = Input.acceleration;

        // Normalize the accelerometer values to ensure consistency across devices
        float normalizedAcceleration = acceleration.magnitude;

        if (normalizedAcceleration > shakeThreshold)
        {
            // Check if enough time has passed since the last shake event
            if (Time.time - lastShakeTime >= minShakeInterval)
            {
                // Shake detected, perform your action here
                HandleShake();
                lastShakeTime = Time.time; // Record the time of the shake event
            }
        }
    }

    void HandleShake()
    {
        // This method is called when a shake event is detected
        // Add your custom behavior or actions to perform on shake here
        Debug.Log("Shake Detected!");

        if (prefabAnimator != null)
        {
            // Trigger the animation by setting the "IsDead" parameter
            prefabAnimator.SetBool("IsDead", true);
        }
        else
        {
            Debug.LogWarning("Prefab Animator is not assigned. Make sure to assign it in the Inspector.");
        }
    }
}
