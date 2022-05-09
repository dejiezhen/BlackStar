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
    public GameObject playerObject;

    public PointsManager pointsManager;


    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {
        score.text = "0";
    }
    // Update is called once per frame
    public void AddPoints(float points)
    {
        overallScore += points;
    }
    void Update()
    {
        overallScore += ( 1 + Mathf.Floor(pointsManager.timePlayed / 5) * .1f);
        score.GetComponent<UnityEngine.UI.Text>().text = Mathf.Round(overallScore).ToString();
    }
}
