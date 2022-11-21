using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public GameObject PauseScreen;
    public bool IsPaused;


    public void Update()
    {
        PauseMenu();

    }


    public void PauseMenu()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (!IsPaused)
            {
                Time.timeScale = 0f;
                IsPaused = true;
                PauseScreen.SetActive(true);
            }
            else
            {
                Time.timeScale = 1f;
                IsPaused = false;
                PauseScreen.SetActive(false);
            }
        }
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void UnPause()
    {
        IsPaused = false;
        PauseScreen.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

