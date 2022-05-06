//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using LootLocker.Requests;
//using UnityEngine.UI;

//public class LeaderboardController : MonoBehaviour
//{
//    public InputField MemberID, PlayerScore;
//    public int ID;
//    int MaxScores = 7;
//    public Text[] Entries;

//    private void Start()
//    {
//        LootLockerSDKManager.StartSession("Plater", (response) =>
//        {
//            if (response.success)
//            {
//                Debug.Log("Success");
//            }
//            else
//            {
//                Debug.Log("Failed");
//            }
//        });
//    }

//    public void SubmitScore()
//    {
//        LootLockerSDKManager.SubmitScore(MemberID.text, int.Parse(PlayerScore.text), ID, (response) =>
//        {
//            if (response.success)
//            {
//                Debug.Log("Success");
//            }
//            else
//            {
//                Debug.Log("Failed");
//            }
//        }

//        );
//    }

//    public void ShowScores()
//    {
//        LootLockerSDKManager.GetScoreList(ID, MaxScores, (response) =>
//        {
//            if (response.success)
//            {
//                LootLockerLeaderboardMember[] scores = response.items;
//                for (int i = 0; i < scores.Length; i++)
//                {
//                    Entries[i].text = (scores[i].rank + ")   " + scores[i].score);
//                }
//                if (scores.Length < MaxScores)
//                {
//                    for (int i = scores.Length; i < MaxScores; i++)
//                    {
//                        Entries[i].text = (i + 1).ToString() + ") 0";
//                    }
//                }
                
//            }
//            else
//            {
//                Debug.Log("Failed");
//            }
//        });
//    }
//}
