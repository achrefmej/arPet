using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WolfAnimator : MonoBehaviour
{
    public Animator wolfAnimator;
    public string screamKeyword = "scream";
    public string sitKeyword = "sit";
    public string stateKeyword = "state"; // The keyword to trigger the state and enable UI image
    public AudioClip screamSound;
    private AudioSource audioSource;
    private TextMeshProUGUI textMeshPro;
    public Image uiImage; // Reference to the UI image you want to enable

    void Start()
    {
        GameObject textParent = GameObject.FindGameObjectWithTag("Analyse");
        if (textParent != null)
        {
            textMeshPro = textParent.GetComponentInChildren<TextMeshProUGUI>();

            if (textMeshPro == null)
            {
                Debug.LogError("TextMeshPro component not found under the object with the 'TextParent' tag.");
            }
        }
        else
        {
            Debug.LogError("Object with 'TextParent' tag not found.");
        }

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        DetectScream();
        DetectSit();
        DetectState();
    }

    void DetectScream()
    {
        if (textMeshPro != null && textMeshPro.text.Contains(screamKeyword))
        {
            wolfAnimator.SetBool("IsScreaming", true);

            if (screamSound != null && !audioSource.isPlaying)
            {
                audioSource.clip = screamSound;
                audioSource.Play();
            }
        }
        else
        {
            wolfAnimator.SetBool("IsScreaming", false);
        }
    }

    void DetectSit()
    {
        if (textMeshPro != null && textMeshPro.text.Contains(sitKeyword))
        {
            wolfAnimator.SetBool("IsSitting", true);
        }
        else
        {
            wolfAnimator.SetBool("IsSitting", false);
        }
    }

    void DetectState()
    {
        if (textMeshPro != null && textMeshPro.text.Contains(stateKeyword))
        {
            // Enable the UI image when the state is detected
            if (uiImage != null)
            {
                uiImage.enabled = true;
            }
        }
        else
        {
            // Disable the UI image when the state is not detected
            if (uiImage != null)
            {
                uiImage.enabled = false;
            }
        }
    }
}

