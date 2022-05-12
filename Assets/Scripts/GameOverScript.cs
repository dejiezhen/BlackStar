using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public Text endText;
    public GameObject gmObject;
    public GameManager gm;
    public static float score;

    // Start is called before the first frame update
    void Start()
    {
        gmObject = GameObject.Find("SceneGameManager");
        gm = gmObject.GetComponent<GameManager>();
        Time.timeScale = 0f;
        score = Mathf.Round(gm.overallScore);
        endText.text = ("Good try you scored " + score.ToString() + " points");
        
    }


}
