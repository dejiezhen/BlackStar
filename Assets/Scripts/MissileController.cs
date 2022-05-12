using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour
{
    public float moveSpeed = 400f;
    private float lifeTime = 3;
    private Rigidbody rb;
    public float addObstaclePoint;
    public GameObject gameManagerObject;
    private GameManager gameManager;
    private AudioSource source;
    private float destroyDelay = .02f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, lifeTime);
        gameManagerObject = GameObject.Find("SceneGameManager");
        gameManager = gameManagerObject.GetComponent<GameManager>();
        source = GetComponent<AudioSource>();

    }

    void Update()
    {
        rb.velocity = new Vector3(0f, 0f, moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider col)
    {
        

        if ((col.gameObject.tag == "Asteroid")||(col.gameObject.tag == "UFO"))
        {
            
            source.Play();
            addObstaclePoint = col.gameObject.tag == "Asteroid"
                ? 100
                : 200;
            Destroy(col.gameObject);
            StartCoroutine(DestroyDelay());
            gameManager.AddPoints(addObstaclePoint);
        }

    }

    private IEnumerator DestroyDelay()
    {
        yield return new WaitForSeconds(destroyDelay);
        Destroy(gameObject);
    }

}
