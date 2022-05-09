using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenu;
    [SerializeField] RectTransform fader;

    private void Start()
    {
        //fader.gameObject.SetActive(true);
        //LeanTween.scale(fader, new Vector3(1, 1, 1), 0);
        //LeanTween.scale(fader, Vector3.zero, 0.5f).setEase(LeanTweenType.easeInOutExpo).setOnComplete(() =>
        //{
            //fader.gameObject.SetActive(false);
        //});
    }

    public void LoadScene(string sceneName)
    {
        //Method to start the game and load the main menu
        //audioSource.PlayOneShot(completeSound);
        //fader.gameObject.SetActive(true);
        //LeanTween.scale(fader, Vector3.zero, 0f);
        //LeanTween.scale(fader, new Vector3(1, 1, 1), 0.5f).setEase(LeanTweenType.easeInOutExpo).setOnComplete(() =>
        //{
            SceneManager.LoadScene(sceneName);
        //});
    }

    ////Starts the first level
    //public void StartGame()
    //{
    //    SceneManager.LoadScene("MasterScene");
    //}

    //public void StartTut()
    //{
    //    SceneManager.LoadScene("Tutorial");
    //}


    //Quits
    public void ExitGame()
    {
        Application.Quit();
    }
}
