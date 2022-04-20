using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{


    public float spawnTimer;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            SpawnAsteroid();

            timer = spawnTimer;
        }

        if (GameControler.Instance.timePlayed > 10)
        {
            spawnTimer = 4 - (Mathf.Floor(GameControler.Instance.timePlayed / 10) * .1f);
        }

    }

    void SpawnAsteroid()
    {

    }
}
