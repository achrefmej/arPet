using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Vibratorr
{
#if UNITY_ANDROID && !UNITY_EDITOR

    public static AndroidJavaClass unityplayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
    public static AndroidJavaObject currentactivity = unityplayer.GetStatic<AndroidJavaObject>("currentActivity");
    public static AndroidJavaObject vibrator = currentactivity.Call<AndroidJavaObject>("getSystemService", "vibrator");
#else
    public static AndroidJavaClass unityplayer;
    public static AndroidJavaObject currentactivity;
    public static AndroidJavaObject vibrator;
#endif
    public static void Vibrate(long millisecond = 250)
    {
        if (IsAndroid())
        {
            vibrator.Call("vibrate", millisecond);
        }
        else
        {
            Handheld.Vibrate();
        }
    }


    public static void Cancel()
    {
        if (IsAndroid())
        {
            vibrator.Call("cancel");
        }
        else
        {
            Handheld.Vibrate();
        }
    }

    public static bool IsAndroid()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        return true;
#else
        return false;
 #endif

    }



}
