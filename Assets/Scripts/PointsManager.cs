using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsManager : MonoBehaviour
{
    public GameObject player;

    public PlayerController playerScript;

    public float timePlayed;
    public float pointTimer;
    public float timer;


    public int points;

    private void Start()
    {
        timer = pointTimer;
    }

    private void Update()
    {
        timePlayed += Time.deltaTime;

        timer -= Time.deltaTime;
        if (timer < 0)
        {
            points += 10;
            timer = pointTimer;
        }
    }
}