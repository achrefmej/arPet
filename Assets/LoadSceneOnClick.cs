using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour
{
    public string sceneName; // Set the name of the scene to load in the Inspector

    public void LoadNewScene()
    {
        SceneManager.LoadScene(sceneName); // Load the specified scene
    }
}
