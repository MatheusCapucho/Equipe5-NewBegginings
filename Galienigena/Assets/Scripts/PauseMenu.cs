using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    static bool gameIsPaused = false;

    public GameObject PauseController;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (gameIsPaused)
            {
                Resume();
                
            } else
            {
                PauseGame();
            }
        }
    }
    public void Resume()
    {
        PauseController.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;

    }
    public void PauseGame()
    {
        PauseController.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
