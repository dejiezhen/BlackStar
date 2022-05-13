using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text score;
    // Start is called before the first frame update
    public float overallScore;
    public float playerAcceleration;

    public PointsManager pointsManager;


    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        score.text = "0";
    }

    public void AddPoints(float points)
    {
        overallScore += points;
    }
    void Update()
    {
        overallScore += ( 1 + Mathf.Floor(pointsManager.timePlayed / 5) * .1f);
        if (score)
        {
            score.GetComponent<UnityEngine.UI.Text>().text = Mathf.Round(overallScore).ToString();
        }
    }
}
