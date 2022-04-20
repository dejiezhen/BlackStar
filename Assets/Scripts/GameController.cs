using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControler : MonoBehaviour
{
    public static GameControler Instance { get; private set; }

    public GameObject player;

    public PlayerController playerScript;

    public float timePlayed;

    public int points;

    private void GameOver()
    {
    }


    private void Start()
    {

        player = GameObject.FindWithTag("Player");
        playerScript = player.GetComponent<PlayerController>();
    }

    public void AddPoint()
    {
        points += 1;
    }

    private void Update()
    {
        //points += Time.deltaTime;

/*        if (playerScript.lives <= 0)
        {
            GameOver();
        }
*/    }



}