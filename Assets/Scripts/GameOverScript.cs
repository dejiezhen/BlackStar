using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public Text endText;
    public GameObject gmObject;
    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        //gm = gmObject.GetComponent<GameManager>();
        gmObject = GameObject.Find("SceneGameManager");
        gm = gmObject.GetComponent<GameManager>();
        Time.timeScale = 0f;
        endText.text = ("Good try you scored " + Mathf.Round(gm.overallScore).ToString() + " points");
        Debug.Log(gm.overallScore);
        
    }


}
