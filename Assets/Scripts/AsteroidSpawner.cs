using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public float xRange;
    public float yRange;

    public float spawnTimer;
    public float timer;

    public GameObject[] spawnObjects;

    public PointsManager pointsManager;

    // Start is called before the first frame update
    void Start()
    {
        timer = spawnTimer;
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

        if (pointsManager.timePlayed > 10)
        {
            spawnTimer = 5 - (Mathf.Floor(pointsManager.timePlayed / 10) * .1f);
        }

    }

    void SpawnAsteroid()
    {

        Vector3 spawnPoint = new Vector3(gameObject.transform.position.x + Random.Range(0, xRange), gameObject.transform.position.y + Random.Range(0, yRange), gameObject.transform.position.z - 2);
        Instantiate(spawnObjects[Random.Range(0, 1)], spawnPoint, spawnObjects[Random.Range(0, 1)].transform.rotation);

    }
}
