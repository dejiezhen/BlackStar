using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpeedIncrease : MonoBehaviour
{

    private ParticleSystem ps;

    public PointsManager pointsManager;

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        var main = ps.main;
        main.simulationSpeed = 1 + (Mathf.Floor(pointsManager.timePlayed / 5) * .1f);
        //var curColor = main.startColor;
        //main.startColor = 
    }
}
