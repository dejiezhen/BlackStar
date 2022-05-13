using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpeedIncrease : MonoBehaviour
{

    private ParticleSystem ps;

    public PointsManager pointsManager;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        var main = ps.main;
        main.simulationSpeed = 1 + (Mathf.Floor(pointsManager.timePlayed / 5) * .1f);
    }
}
