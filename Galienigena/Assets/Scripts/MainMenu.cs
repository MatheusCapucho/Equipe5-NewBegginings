using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int sceneSelection = 1;

   public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + sceneSelection);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
