using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextSpeech;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;

public class VoiceController : MonoBehaviour
{

    const string LANG_CODE = "en-US";

    [SerializeField] // Corrected attribute name
    Text uiText;

    private void Start()
    {
        Setup(LANG_CODE);

#if UNITY_ANDROID
        SpeechToText.instance.onPartialResultsCallback = OnPartialSpeechResult;
#endif

        SpeechToText.instance.onResultCallback = OnFinalSpeechResult;
        CheckPermission(); // Corrected method name
    }

    void CheckPermission() // Corrected method name
    {
#if UNITY_ANDROID

        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone)) // Corrected method and attribute names
        {
            Permission.RequestUserPermission(Permission.Microphone);
        }
#endif
    }

    #region Speech To Text

    public void StartListening()
    {
        SpeechToText.instance.StartRecording();
    }

    public void StopListening()
    {
        SpeechToText.instance.StopRecording();
    }

    void OnFinalSpeechResult(string result)
    {
        uiText.text = result;
    }

    void OnPartialSpeechResult(string result)
    {
        uiText.text = result;
    }

    #endregion

    void Setup(string code)
    {
        SpeechToText.instance.Setting(code);
    }
}
