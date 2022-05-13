using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePaused = false;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] GameManager gm;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                Resume();
            } else
            {
                Pause();
            }
            
        }
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        GamePaused = true;
        Time.timeScale = 0f;
        gm.playing = false;
    }

    //Unpause the game
    public void Resume()
    {
        GamePaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gm.playing = true;
    }

    //Opens the Main Menu
    public void Menu()
    {
        GamePaused = false;
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }

    //Quits the game
    public void Quit()
    {
        Application.Quit();
    }

}
