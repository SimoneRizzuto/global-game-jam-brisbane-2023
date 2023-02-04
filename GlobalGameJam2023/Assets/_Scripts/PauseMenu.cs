using UnityEngine;

/// <summary>
/// Pause Menu
/// 
/// Adrian Barrett
/// 
/// It's a script for a pause menu.
/// Activated by pressing escape.
/// 
/// Make sure the menu in question is disabled, and this script in on an enabled object.
/// </summary>

public class PauseMenu : MonoBehaviour
{
    //keep track of whether the game is currently paused
    //static because we don't want to reference this specific script
    public static bool gameIsPaused = false;

    public GameObject gameUI;
    public GameObject pauseMenuUI;

    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        };
    }
    //Resume the game
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        gameUI.SetActive(true);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
    //Pause the game
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        gameUI.SetActive(false);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
}

//Reference - https://www.youtube.com/watch?v=JivuXdrIHK0