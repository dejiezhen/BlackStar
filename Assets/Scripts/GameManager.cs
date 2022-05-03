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

    private void Start()
    {
        score.text = "0";
        player = playerObject.GetComponent<PlayerController>();
    }
    // Update is called once per frame
    void Update()
    {
        playerAcceleration = player.acceleration;
        overallScore += Time.deltaTime * (playerAcceleration % 1000);
        score.GetComponent<UnityEngine.UI.Text>().text = overallScore.ToString();
    }
}
