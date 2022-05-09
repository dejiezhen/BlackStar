using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialText : MonoBehaviour
{
    private Text tutorialText;
    // Start is called before the first frame update
    void Start()
    {
        tutorialText = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.timeSinceLevelLoad > 5)
        {
            tutorialText.text = "Press spacebar to shoot, and use WASD to move around.";

        }
        if (Time.timeSinceLevelLoad > 15)
        {
            tutorialText.text = "Avoid the asteroids and UFOs. And look out, the UFOs shoot at you because they are jealous.";

        }

        if (Time.timeSinceLevelLoad > 25)
        {
            tutorialText.text = "Eat ALL the pizza and gelato. Pizza heals you, and gelato gives you an epic powerup.";

        }
        if (Time.timeSinceLevelLoad > 35)
        {
            tutorialText.text = "Your score increases with time and kills. Submit your high scores to the leaderboard for Tubbs' approval.";

        }
        if (Time.timeSinceLevelLoad > 45)
        {
            tutorialText.text = "Now press escape and get your cat butt to the Main Menu to start the real game!";

        }


    }
}
