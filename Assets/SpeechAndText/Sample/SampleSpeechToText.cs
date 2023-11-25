using UnityEngine;
using UnityEngine.UI;
using TextSpeech;
using UnityEngine.Android;

public class SampleSpeechToText : MonoBehaviour
{
    public bool isShowPopupAndroid = true;
    public GameObject loading;
    public Toggle toggleShowPopupAndroid;
    public InputField inputLocale;
    public InputField inputText;
    public float pitch;
    public float rate;

    public Text txtLocale;
    public Text txtPitch;
    public Text txtRate;

    void Start()
    {
        Setting("en-US");
        loading.SetActive(false);
        SpeechToText.instance.onResultCallback = OnResultSpeech;

#if UNITY_ANDROID
        SpeechToText.instance.isShowPopupAndroid = isShowPopupAndroid;
        toggleShowPopupAndroid.isOn = isShowPopupAndroid;
        toggleShowPopupAndroid.gameObject.SetActive(true);
        Permission.RequestUserPermission(Permission.Microphone);
#else
        toggleShowPopupAndroid.gameObject.SetActive(false);
#endif
    }

    public void StartRecording()
    {
#if UNITY_EDITOR
        // Handle editor-specific logic if needed
#else
        SpeechToText.instance.StartRecording("Speak any");
#endif
    }

    public void StopRecording()
    {
#if UNITY_EDITOR
        OnResultSpeech("Not supported in editor.");
#else
        SpeechToText.instance.StopRecording();
#endif

#if UNITY_IOS
        loading.SetActive(true);
#endif
    }

    void OnResultSpeech(string _data)
    {
        inputText.text = _data;
#if UNITY_IOS
        loading.SetActive(false);
#endif
    }

    public void OnClickSpeak()
    {
        TextToSpeech.Instance.StartSpeak(inputText.text);
    }

    public void OnClickStopSpeak()
    {
        TextToSpeech.Instance.StopSpeak();
    }

    public void Setting(string code)
    {
        txtLocale.text = "Locale: " + code;
        txtPitch.text = "Pitch: " + pitch;
        txtRate.text = "Rate: " + rate;
        SpeechToText.instance.Setting(code);
        TextToSpeech.Instance.Setting(code, pitch, rate);
    }

    public void OnClickApply()
    {
        Setting(inputLocale.text);
    }

    public void OnToggleShowAndroidPopupChanged(bool value)
    {
        isShowPopupAndroid = value;
        SpeechToText.instance.isShowPopupAndroid = isShowPopupAndroid;
    }
}
