using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenu;

    private void Start()
    {
        
    }


    //Starts the first level
    public void StartGame()
    {
        SceneManager.LoadScene("MasterScene");
    }

    //Quits
    public void ExitGame()
    {
        Application.Quit();
    }
}
