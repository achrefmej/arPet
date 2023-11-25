using UnityEngine;
using TMPro;

public class WolfVibrator : MonoBehaviour
{
    public Animator wolfAnimator; // The Animator component of the wolf
    private bool isEating = false; // Flag to track if the wolf is eating

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Vibrator") && !isEating) // Checking for the object with the "Vibrator" tag and not currently eating
        {
            isEating = true;
            wolfAnimator.SetBool("IsEating", true); // Trigger the eating animation

            Handheld.Vibrate(); // Trigger vibration

            // Destroy the object after 2 seconds
            Destroy(other.gameObject, 2f);
            Invoke("ResetEatingFlag", 2f);
        }
    }

    void ResetEatingFlag()
    {
        isEating = false;
        wolfAnimator.SetBool("IsEating", false); // Set the IsEating bool to false
    }
}

