using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float acceleration = 80;
    public float damage = 100f;
    public float particleRange = 100f;
    private Rigidbody rb;
    public Camera crosshair;
    public bool firingAbled = true;
    public float firingInterval = 2f;
    public Transform missileSpawnPoint;
    public GameObject missilePrefab;

    private bool invincible = false;
    public float invincibleTimer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.mass = 0;
        rb.drag = 3.5f;
        rb.angularDrag = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (invincible && invincibleTimer <= 0)
        {
            invincible = false;
        }
        else
        {
            invincibleTimer= invincibleTimer-Time.deltaTime;
        }
        
        float moveLeftRight = Input.GetAxis("Horizontal");
        float moveForwardBack = Input.GetAxis("Vertical");

        Vector3 xAcceleration = new Vector3(1, 0, 0) * moveLeftRight * Time.deltaTime * acceleration;
        Vector3 yAcceleration = new Vector3(0, 1, 0) * moveForwardBack * Time.deltaTime * acceleration;

        rb.velocity += xAcceleration + yAcceleration;
        //rb.velocity += xAcceleration;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnSpaceshoot();
        }
    }

    public void FireMissiles()
    {
        Instantiate(missilePrefab, missileSpawnPoint.position, Quaternion.identity);
    }

    public void OnSpaceshoot()
    {
        if (firingAbled)
        {
            FireMissiles();
            firingAbled = false;
            StartCoroutine(FiringDelay());
        }
    } 

    private IEnumerator FiringDelay()
    {
        yield return new WaitForSeconds(firingInterval);
        firingAbled = !firingAbled;
    }
    private void Shoot ()
    {
        RaycastHit hit;
        if (Physics.Raycast(crosshair.transform.position, Vector3.forward, out hit, particleRange))
        {
            Debug.Log("object hit");
        }
       
    }


    private void OnTriggerEnter(Collider col)
    {
        if ((col.gameObject.CompareTag("Asteroid") || col.gameObject.CompareTag("Missile") || col.gameObject.CompareTag("UFO")) && !invincible)
        {

            UIManager.lives--;
            UIManager.UpdateLives(UIManager.lives);
            Destroy(col.gameObject);

        }

        if (col.gameObject.CompareTag("Food"))
        {
            if (UIManager.lives < 3)
            {
                UIManager.lives++;
                UIManager.UpdateLives(UIManager.lives);
            }
        }

        if (col.gameObject.CompareTag("Upgrade"))
        {
            invincible = true;
            invincibleTimer = 7;
        }
    }
    
}
