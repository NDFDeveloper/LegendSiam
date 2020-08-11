using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonScript : MonoBehaviour
{
    public float speed = 10;
    public float lifeTime = 10f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;

        Destroy(gameObject, lifeTime);
    }

    void FixedUpdate()
    {
        //transform.position += Vector3.up * speed * Time.deltaTime;
        // add

        rb.AddForce(Vector3.up * speed * Time.deltaTime);
    }
}
