using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LeaderboardController : MonoBehaviour
{
    public InputField MemberID, PlayerScore;
    
    public int ID;
    int MaxScores = 6;
    public Text[] Entries;
    public float FinalScore;
    public Text EndScore;

    // Credits to https://www.youtube.com/watch?v=pp8Vl4cKLdc
    private void Start()
    {
        LootLockerSDKManager.StartSession("Plater", (response) =>
        {
            if (response.success)
            {
                Debug.Log("Success");
                if (GameOverScript.score > 0)
                {
                    FinalScore = (GameOverScript.score);
                    EndScore.text = ("Score: " + FinalScore.ToString());
                }
            }
            else
            {
                Debug.Log("Failed");
            }
        });
    }

    public void SubmitScore()
    {
    
        LootLockerSDKManager.SubmitScore(MemberID.text, (int)FinalScore, ID, (response) =>
        {
            if (response.success)
            {
                Debug.Log("Success");
            }
            else
            {
                Debug.Log("Failed");
            }
        }

        );
    }

    public void ShowScores()
    {
        LootLockerSDKManager.GetScoreList(ID, MaxScores, (response) =>
        {
            if (response.success)
            {
                LootLockerLeaderboardMember[] scores = response.items;
                for (int i = 0; i < scores.Length; i++)
                {
                    Entries[i].text = (scores[i].member_id + ":  " + scores[i].score);
                }
                if (scores.Length < MaxScores)
                {
                    for (int i = scores.Length; i < MaxScores; i++)
                    {
                        Entries[i].text = "NONE";
                    }
                }
                
            }
            else
            {
                Debug.Log("Failed");
            }
        });
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }
}
