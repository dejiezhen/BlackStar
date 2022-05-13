using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public Text endText;
    public static float score;
    [SerializeField]
    private FloatSO scoreSO;

    void Start()
    {
            Time.timeScale = 0f;
            score = Mathf.Round(scoreSO.Value);
            endText.text = ("Good try you scored " + score.ToString() + " points");
    }
}
