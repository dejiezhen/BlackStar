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
    public Transform missileSpawnMiddle;
    public Transform missileSpawnLeft;
    public Transform missileSpawnRight;
    public Transform rocketSpawnMiddle;
    public bool laser = true;

    private AudioSource source;
    public AudioClip bite;
    public AudioClip powerup;
    public AudioClip shootLaser;
    public AudioClip shootRocket;
    public AudioClip hurt;
    public AudioClip deathSound;


    private MeshRenderer mrPlane;
    public GameObject catModel;

    public GameObject missilePrefab;
    public GameObject rocketPrefab;

    private bool invincible = false;
    private float invincInterval = .2f;
    private float invincAnimationInterval = .1f;
    private bool planeUpgrade = false;
    private int planeUpgradeInterval = 5;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.mass = 0;
        rb.drag = 3.5f;
        rb.angularDrag = 0;
        source = GetComponent<AudioSource>();
        mrPlane = gameObject.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        float moveLeftRight = Input.GetAxis("Horizontal");
        float moveForwardBack = Input.GetAxis("Vertical");

        Vector3 xAcceleration = new Vector3(1, 0, 0) * moveLeftRight * Time.deltaTime * acceleration;
        Vector3 yAcceleration = new Vector3(0, 1, 0) * moveForwardBack * Time.deltaTime * acceleration;

        rb.velocity += xAcceleration + yAcceleration;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnSpaceshoot();
        }
    }

    public void FireMissiles()
    {
        if (laser)
        {
            Instantiate(missilePrefab, missileSpawnMiddle.position, Quaternion.identity);
            if (planeUpgrade)
            {
                Instantiate(missilePrefab, missileSpawnLeft.position, Quaternion.identity);
                Instantiate(missilePrefab, missileSpawnRight.position, Quaternion.identity);
            }
        }
        else
        {
            Instantiate(rocketPrefab, rocketSpawnMiddle.position, Quaternion.identity);
        }
    }

    public void OnSpaceshoot()
    {
        if (firingAbled)
        {
            FireMissiles();
            if (laser)
            {
                source.clip = shootLaser;
                source.Play();
                firingAbled = false;
                StartCoroutine(FiringDelay());
            }
            else
            {
                source.clip = shootRocket;
                source.Play();
                firingAbled = true;
            }
        }
    } 
    private IEnumerator PlaneUpgradeDelay()
    {
        yield return new WaitForSeconds(planeUpgradeInterval);
        laser = true;
        planeUpgrade = !planeUpgrade;
    }

    private IEnumerator InvincibilityDelay()
    {
        Debug.Log("Starting coroutine");
        invincible = true;
        float elapsedTime = 0f;
        Debug.Log(invincInterval);
        while (elapsedTime < invincInterval)
        {
            MeshRenderer[] MeshRenderArr = catModel.GetComponentsInChildren<MeshRenderer>();
            mrPlane.enabled = false;
            catModel.SetActive(false);
            elapsedTime += Time.deltaTime;
            yield return new WaitForSeconds(invincAnimationInterval);
            mrPlane.enabled = true;
            catModel.SetActive(true);
            elapsedTime += Time.deltaTime;
            yield return new WaitForSeconds(invincAnimationInterval);
            Debug.Log(elapsedTime);
        }
        Debug.Log("Stopping Coroutine");
        invincible = false;
    }

    private IEnumerator FiringDelay()
    {
        yield return new WaitForSeconds(firingInterval);
        firingAbled = !firingAbled;
    }

    private void OnTriggerEnter(Collider col)
    {
        if ((col.gameObject.CompareTag("Asteroid")
               || col.gameObject.CompareTag("Missile")
               || col.gameObject.CompareTag("UFO"))
               && !invincible)
        {
            source.clip = hurt;
            source.Play();
            UIManager.lives--;
            UIManager.UpdateLives(UIManager.lives);
            StartCoroutine(InvincibilityDelay());
        }

        if (col.gameObject.CompareTag("Food"))
        {
            if (UIManager.lives < 3)
            {
                UIManager.lives++;
                UIManager.UpdateLives(UIManager.lives);
            }
            source.clip = bite;
            source.Play();
            
        }

        if (col.gameObject.CompareTag("Upgrade"))
        {
            source.clip = powerup;
            source.Play();
            float randomUpgrade = Random.Range(0, 2);
            laser = randomUpgrade == 0;
            planeUpgrade = true;
            StartCoroutine(PlaneUpgradeDelay());
        }
        Destroy(col.gameObject);
    }
    
}
