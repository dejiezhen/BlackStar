using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject player;

    public PlayerController playerScript;

    public float timePlayed;

    public int points;

    private void GameOver()
    {
    }

    public void AddPoint()
    {
        points += 1;
    }

    private void Update()
    {
        timePlayed += Time.deltaTime;
        //points += Time.deltaTime;

/*        if (playerScript.lives <= 0)
        {
            GameOver();
        }
*/    }



}