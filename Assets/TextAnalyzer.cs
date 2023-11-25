using UnityEngine;
using TMPro;

public class TextAnalyzer : MonoBehaviour
{
    public Animator prefabAnimator; // The Animator component of the prefab
    public string keyword = "scream"; // The keyword to look for in the text

    void Start()
    {
        TextMeshProUGUI[] textMeshPros = GameObject.FindGameObjectsWithTag("Analyse")[0].GetComponentsInChildren<TextMeshProUGUI>();

        if (textMeshPros.Length == 0)
        {
            Debug.LogError("TextMeshPro components with Analyse tag not found in any GameObject.");
        }

        foreach (TextMeshProUGUI textLegacy in textMeshPros)
        {
            if (textLegacy.text.Contains(keyword))
            {
                // If the keyword is found in the text, trigger the animation
                prefabAnimator.SetBool("IsScreaming", true);
                return; // Found the keyword, so no need to continue looping
            }
        }

        // If the keyword is not found in any TextMeshPro, set the bool parameter to false
        prefabAnimator.SetBool("IsScreaming", false);
    }
}
