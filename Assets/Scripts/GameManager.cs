using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text score;
    public float overallScore;
    public float playerAcceleration;
    public bool playing;

    public PointsManager pointsManager;
    [SerializeField]
    private FloatSO scoreSO;

    private void Start()
    {
        playing = true;
    }
    public void AddPoints(float points)
    {
        scoreSO.Value += points;
    }
    void Update()
    {
        if (playing)
        {
            scoreSO.Value += (1 + Mathf.Floor(pointsManager.timePlayed / 5) * .1f);
            score.GetComponent<UnityEngine.UI.Text>().text = Mathf.Round(scoreSO.Value).ToString();
        }
    }
}
