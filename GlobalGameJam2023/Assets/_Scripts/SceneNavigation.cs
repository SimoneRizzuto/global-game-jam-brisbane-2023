using UnityEngine;

using UnityEngine.SceneManagement;

/// <summary>
/// Scene Navigation
/// 
/// Adrian Barrett
/// 
/// This script manages Unity scenes.
/// </summary>

public class SceneNavigation : MonoBehaviour
{
    /// <summary>
    /// All of this stuff is to unpause the game if it is paused
    /// 
    /// Apparently this could all be done with a single function in older versions of unity
    /// </summary>
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (PauseMenu.gameIsPaused)
        {
            Time.timeScale = 1f;
            PauseMenu.gameIsPaused = false;
        }
    }

    /// <summary>
    /// Calling this method with a string of a scene will switch the engine to that scene.
    /// </summary>
    /// <param name="sceneToGoTo"></param>
    public void ChangeScene(string sceneToGoTo)
    {
        SceneManager.LoadSceneAsync(sceneToGoTo, LoadSceneMode.Single);
    }
    /// <summary>
    /// Calling this method will quit the game. Only should be used in UI.
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
}
