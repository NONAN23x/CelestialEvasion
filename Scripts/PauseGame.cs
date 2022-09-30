using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PauseGame : MonoBehaviour
{

    public static bool GameisPaused = false;
    public GameObject pauseMenuUI;
    public GameObject mainUI;
    


    public void Resume(){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;
        Debug.Log("resumed");
        mainUI.SetActive(true);
    }


    public void Pause(){
        Debug.Log("paused");
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameisPaused = true;
        mainUI.SetActive(false);
    }

    /*void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Debug.Log("Pressed BAck");
            if (GameisPaused){
                Resume();
            } else{
                Pause();
            }
        }
    }*/
}
