using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehavior : MonoBehaviour
{
    private Rigidbody rb;
    public float moveSpeed;

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

        if(gameObject.transform.position.z < -50)
        {
            Destroy(gameObject);
        }
    }
}
