using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBehavior : MonoBehaviour
{

    private Rigidbody rb;
    public float moveSpeed;
    public float shootSpeed = 3;
    public GameObject alienShot;


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();

        Vector3 temp = rb.velocity;
        temp.z = moveSpeed;
        rb.velocity = temp;

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.z < -200)
        {
            Destroy(gameObject);
        }

        if (shootSpeed <= 0)
        {
            FireMissiles();
        }
        else
        {
            shootSpeed = shootSpeed - Time.deltaTime;
        }

    }

    public void FireMissiles()
    {
        Instantiate(alienShot, rb.position, Quaternion.identity);
        shootSpeed = 3;
    }
}
