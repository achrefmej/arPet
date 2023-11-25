using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextCopier : MonoBehaviour
{
    public Text sourceText; // The source Text component from which to copy the text
    public TextMeshProUGUI textMesh; // The TextMeshPro component where the text will be updated

    void Start()
    {
        // Check if the TextMeshPro component is assigned
        if (textMesh == null)
        {
            Debug.LogError("TextMeshPro component not assigned for copying text.");
        }

        // Check if the source Text component is assigned
        if (sourceText == null)
        {
            Debug.LogError("Source Text not assigned for copying text.");
        }
    }

    void Update()
    {
        if (textMesh != null && sourceText != null)
        {
            // Copy the text from the source Text component to the TextMeshPro component
            textMesh.text = sourceText.text;
        }
    }
}
