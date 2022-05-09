using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text score;
    // Start is called before the first frame update
    public float overallScore;
    public float playerAcceleration;
    public GameObject playerObject;
    private PlayerController player;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {
        score.text = "0";
        player = playerObject.GetComponent<PlayerController>();
    }
    // Update is called once per frame
    public void AddPoints(float points)
    {
        overallScore += points;
    }
    void Update()
    {
        playerAcceleration = player.acceleration;
        overallScore += (Time.deltaTime/2) * (playerAcceleration % 1000);
        score.GetComponent<UnityEngine.UI.Text>().text = Mathf.Round(overallScore).ToString();
    }
}
