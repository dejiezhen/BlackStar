using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public Text endText;
    private GameObject gmObject;
    private GameManager gm;
    public static float score;

    // Start is called before the first frame update
    void Start()
    {
            Debug.Log("Activated");
            gmObject = GameObject.Find("SceneGameManager");
            Debug.Log(gmObject);
            if (gmObject != null)
            {
                gm = gmObject.GetComponent<GameManager>();
                Time.timeScale = 0f;
                score = Mathf.Round(gm.overallScore);
                Debug.Log(score);
                endText.text = ("Good try you scored " + score.ToString() + " points");
            }

    }


}
