using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenu;
    [SerializeField] RectTransform fader;
    public Text endText;
    public GameObject gmObject;
    public GameManager gm;

    private void Start()
    {
        gm = gmObject.GetComponent<GameManager>();

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
        if (sceneName.Equals("GameOver"))
        {
            Time.timeScale = 0f;
            endText.text = ("Good try you scored " + gm.score + " points");
        }
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
