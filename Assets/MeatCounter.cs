using UnityEngine;
using UnityEngine.UI;

public class MeatCounter : MonoBehaviour
{
    public GameObject[] meatArray; // Array of meat objects
    public Text textCounter; // Text component to display the counter

    private int startingMeatCount; // The initial number of meat objects

    void Start()
    {
        startingMeatCount = meatArray.Length; // Store the initial count of meat objects
    }

    void Update()
    {
        int currentMeatCount = 0;

        // Loop through the meat array and check the active meat objects
        foreach (var meat in meatArray)
        {
            if (meat != null)
            {
                currentMeatCount++;
            }
        }

        // Calculate the difference and update the counter
        int eatenMeat = startingMeatCount - currentMeatCount;
        UpdateCounterText(eatenMeat);
    }

    void UpdateCounterText(int eatenMeatCount)
    {
        if (textCounter != null)
        {
            textCounter.text = "Meat eaten: " + eatenMeatCount.ToString();
        }
    }
}
