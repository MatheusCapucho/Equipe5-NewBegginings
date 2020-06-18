using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int sceneSelection = 1;
    public GameObject Player;

    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + sceneSelection);
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void NightSelection()
    {
        sceneSelection = 2;
    }
    public void DawnSelection()
    {
        sceneSelection = 1;
    }

    public void SkinPeace()
    {
        Player.GetComponent<PlayerController>().playerState = 1;
    }
    public void SkinIcy()
    {
        Player.GetComponent<PlayerController>().playerState = 2;
    }
    public void SkinFire()
    {
        Player.GetComponent<PlayerController>().playerState = 3;
    }
    public void SkinOstenta()
    {
        Player.GetComponent<PlayerController>().playerState = 4;
    }
}
