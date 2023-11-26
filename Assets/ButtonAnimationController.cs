using UnityEngine;

public class ButtonAnimationController : MonoBehaviour
{
    public GameObject animatedObject; // Assign your animated object (with animations) in the inspector
    private Animation animationComponent;

    private bool isSitting = false;

    void Start()
    {
        animationComponent = animatedObject.GetComponent<Animation>(); // Get the animation component from the object
    }

    public void ToggleSitAndRun()
    {
        if (animationComponent != null)
        {
            if (!isSitting)
            {
                // If not sitting, play the 'sit' animation
                animationComponent.Play("sit");
                isSitting = true;
            }
            else
            {
                // If sitting, play the 'run' animation
                animationComponent.Play("run");
                isSitting = false;
            }
        }
        else
        {
            Debug.LogError("Animation component not found!");
        }
    }
}
