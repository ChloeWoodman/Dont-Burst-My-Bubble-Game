using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Function to quit the application
    public void QuitApplication()
    {
#if UNITY_EDITOR
        // If running in the Unity Editor, stop playing the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // If running as a built application, quit the app
        Application.Quit();
#endif
    }

    // Function to load the next scene in the build order
    public void LoadNextScene()
    {
        // Get the current active scene's build index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Calculate the next scene's index
        int nextSceneIndex = currentSceneIndex + 1;

        // Check if the next scene index is within the build settings range
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("No more scenes in the build order!");
        }
    }


    public void LoadNameScene(string sceneName)
    {
        // Check if the scene name is valid
        if (!string.IsNullOrEmpty(sceneName) && Application.CanStreamedLevelBeLoaded(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("Scene " + sceneName + " cannot be loaded. Make sure it is added to the Build Settings.");
        }
    }
}
