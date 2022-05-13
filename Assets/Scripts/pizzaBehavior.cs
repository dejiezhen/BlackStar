using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaBehavior : MonoBehaviour
{

    private Rigidbody rb;
    public float moveSpeed;
    public float rotateSpeed;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();

        Vector3 temp = rb.velocity;
        temp.z = moveSpeed;
        
        rb.velocity = temp;

    }

    void Update()
    {
        if (gameObject.transform.position.z < -50)
        {
            Destroy(gameObject);
        }

        transform.Rotate(Vector3.right * Time.deltaTime * rotateSpeed);
    }
}
