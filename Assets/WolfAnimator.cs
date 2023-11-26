using UnityEngine;
using TMPro;

public class WolfAnimator : MonoBehaviour
{
    public Animator wolfAnimator;
    public string screamKeyword = "scream";
    public string sitKeyword = "sit";
    public string stateKeyword = "state"; // The keyword to trigger the state and enable the GameObject
    public AudioClip screamSound;
    private AudioSource audioSource;
    private TextMeshProUGUI textMeshPro;

    [SerializeField]
    private GameObject stateGameObject; // Reference to the GameObject to enable/disable

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
            // Enable the serialized GameObject when the state is detected
            if (stateGameObject != null)
            {
                stateGameObject.SetActive(true);
            }
        }
        else
        {
            // Disable the serialized GameObject when the state is not detected
            if (stateGameObject != null)
            {
                stateGameObject.SetActive(false);
            }
        }
    }
}
