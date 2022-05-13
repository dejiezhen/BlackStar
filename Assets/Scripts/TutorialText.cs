using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialText : MonoBehaviour
{
    private Text tutorialText;

    void Start()
    {
        tutorialText = gameObject.GetComponent<Text>();
    }

    void Update()
    {

        if (Time.timeSinceLevelLoad > 5)
        {
            tutorialText.text = "Press spacebar to shoot, and use WASD to move around.";

        }
        if (Time.timeSinceLevelLoad > 15)
        {
            tutorialText.text = "Avoid the asteroids and UFOs. And look out, the UFOs shoot at you because they are jealous of your Italian Food.";

        }

        if (Time.timeSinceLevelLoad > 25)
        {
            tutorialText.text = "Eat ALL the pizza and gelato. Pizza heals you, and gelato gives you an epic powerup.";

        }

        if (Time.timeSinceLevelLoad > 35)
        {
            tutorialText.text = "Powerup includes triple lasers OR unlimited rockets (spam space bar)";
        }

        if (Time.timeSinceLevelLoad > 45)
        {
            tutorialText.text = "Your score increases with time and kills. Submit your high scores to the leaderboard for Tubbs' approval.";

        }
        if (Time.timeSinceLevelLoad > 50)
        {
            tutorialText.text = "Now go destroy some aliens and asteroids, and eat good Italian food!";

        }

        if (Time.timeSinceLevelLoad > 60)
        {
            tutorialText.text = "Goodluck! Summoning you back to the main menu";
        }

        if (Time.timeSinceLevelLoad > 65)
        {
            SceneManager.LoadScene("MainMenu");
        }


    }
}
