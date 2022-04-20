using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform target;

    public LayerMask obstacleLayerMask;

    public float distance = 10;
    public float minPitch = -80;
    public float maxPitch = 80;

    public float rotationSpeed = 300;

    private float pitch;
    private float yaw;

    // Start is called before the first frame update
    void Start()
    {
        pitch = 45;
        yaw = 0;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 offset = new Vector3(0, 1, -1);
        transform.position = target.position + offset * distance;
        transform.rotation = Quaternion.LookRotation(-offset, Vector3.up);
    }
}
