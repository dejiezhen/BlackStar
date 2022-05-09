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



    public GameObject missilePrefab;

    private bool invincible = false;
    public float invincInterval = 1.5f;
    public float invincAnimationInterval = .5f;
    private bool planeUpgrade = false;
    private float planeUpgradeInterval = 5f;
    private int animationFlip = 0;
    [SerializeField]
    private GameObject gameModel;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.mass = 0;
        rb.drag = 3.5f;
        rb.angularDrag = 0;
        source = GetComponent<AudioSource>();
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

    //private void ScaleModel(Vector3 newScale)
    //{
    //    gameModel.transform.localScale = newScale;
    //}

    private IEnumerator AnimationDelay()
    {
        yield return new WaitForSeconds(invincAnimationInterval);
    }

    private IEnumerator InvincibilityDelay()
    {
        invincible = true;
        MeshRenderer mr = gameObject.GetComponent<MeshRenderer>();
        for (float i = 0; i < animationFlip; i++)
        {
            mr.enabled = false;
            Debug.Log("Starting coroutine!!");
            StartCoroutine(AnimationDelay());
            mr.enabled = true;
        }
        yield return new WaitForSeconds(invincInterval);
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
