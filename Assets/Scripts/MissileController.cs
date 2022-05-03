using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour
{
    public float moveSpeed = 400f;
    public float lifeTime = 8;
    private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(0f, 0f, moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider col)
    {
        if ((col.gameObject.tag == "Asteroid")|| (col.gameObject.tag == "UFO"))
        {
            Destroy(col.gameObject);
        }
    }


}
