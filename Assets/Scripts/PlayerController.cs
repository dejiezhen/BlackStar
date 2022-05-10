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

    private AudioSource source;
    public AudioClip bite;
    public AudioClip powerup;
    public AudioClip shoot;
    public AudioClip hurt;


    private MeshRenderer mrPlane;
    public GameObject catModel;

    public GameObject missilePrefab;

    private bool invincible = false;
    private float invincInterval = .2f;
    private float invincAnimationInterval = .1f;
    private bool planeUpgrade = false;
    private float planeUpgradeInterval = 5f;
    private int animationFlip = 0;


    // Start is called before the first frame update
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
        //rb.velocity += xAcceleration;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnSpaceshoot();
        }
    }

    public void FireMissiles()
    {
        Instantiate(missilePrefab, missileSpawnMiddle.position, Quaternion.identity);
        if (planeUpgrade)
        {
            Instantiate(missilePrefab, missileSpawnLeft.position, Quaternion.identity);
            Instantiate(missilePrefab, missileSpawnRight.position, Quaternion.identity);
        }
    }

    public void OnSpaceshoot()
    {
        if (firingAbled)
        {
            FireMissiles();
            source.clip = shoot;
            source.Play();
            firingAbled = false;
            StartCoroutine(FiringDelay());
        }
    } 
    private IEnumerator PlaneUpgradeDelay()
    {
        yield return new WaitForSeconds(planeUpgradeInterval);
        planeUpgrade = !planeUpgrade;
    }

    private IEnumerator AnimationDelay()
    {
        yield return new WaitForSeconds(invincAnimationInterval);
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
            planeUpgrade = true;
            StartCoroutine(PlaneUpgradeDelay());
        }
        Destroy(col.gameObject);
    }
    
}
