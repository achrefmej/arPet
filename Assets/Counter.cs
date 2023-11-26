using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    public TextMeshPro counterText; // Reference to the TextMeshPro object

    private int count = 0; // Counter variable

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Vibrator")) // Check if the collided object has the tag "Vibrator"
        {
            Destroy(other.gameObject); // Destroy the object with the "Vibrator" tag
            count++; // Increment the counter
            UpdateCounterText(); // Update the TextMeshPro text
        }
    }

    void UpdateCounterText()
    {
        // Update the TextMeshPro text to display the current count
        counterText.text = "Count: " + count.ToString();
    }
}
