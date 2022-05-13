using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienShotController : MonoBehaviour
{
    public float moveSpeed = 1000000;
    private float lifeTime = 10;
    private Rigidbody rb;


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        Destroy(gameObject, lifeTime);

        Vector3 temp = rb.velocity;
        temp.z = moveSpeed;
        rb.velocity = -temp;
    }

}
