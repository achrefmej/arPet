using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public void Vibrate()
    {
        try
        {
            Vibrator.Vibrate(1000);
        }
        catch (System.Exception e)
        {
            Debug.LogError("Vibration error: " + e.Message);
        }
    }
}
