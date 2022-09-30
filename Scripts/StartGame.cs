using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartGame : MonoBehaviour
{
    public GameObject mainUI;
    public GameObject menuUI;
    
    public void Play()
    {
        Debug.Log("Pressed Play");
        SceneManager.LoadScene(1);
    }
    
    public void ExitGame()
    {
        Debug.Log("Pressed Exit");
        Application.Quit();
    }
    
    
    public void MainMenu()
    {
        SceneManager.LoadScene(13);
        Time.timeScale = 1f;
        Debug.Log("Main Menu");
    }

    public void CheatMenu()
    {
        Debug.Log("Cheats");
        SceneManager.LoadScene(12);
        Time.timeScale = 1f;
    }
}
