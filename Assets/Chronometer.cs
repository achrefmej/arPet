using UnityEngine;
using TMPro;

public class Chronometer : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;
    private float timer = 0f;
    private bool isRunning = false;

    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        if (textMeshPro == null)
        {
            Debug.LogError("TextMeshProUGUI component not found on the GameObject.");
        }
    }

    void Update()
    {
        if (isRunning)
        {
            timer += Time.deltaTime;
            UpdateTimerDisplay();
        }
    }

    public void StartChronometer()
    {
        isRunning = true;
    }

    public void StopChronometer()
    {
        isRunning = false;
    }

    public void ResetChronometer()
    {
        timer = 0f;
        UpdateTimerDisplay();
    }

    private void UpdateTimerDisplay()
    {
        // Format the timer as hours:minutes:seconds
        string formattedTime = string.Format("{0:00}:{1:00}:{2:00}", Mathf.Floor(timer / 3600), Mathf.Floor((timer % 3600) / 60), Mathf.Floor(timer % 60));

        // Update the TextMeshProUGUI text
        if (textMeshPro != null)
        {
            textMeshPro.text = formattedTime;
        }
    }
}
