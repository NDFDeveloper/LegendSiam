using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Game03Bucket : MonoBehaviour
{
    public Plane plane;

    [System.Serializable]
    public class MyEvent : UnityEvent<Game03Target> { }
    public MyEvent onGet;

    void Start()
    {
        plane = new Plane(transform.forward, transform.position.magnitude);
    }

    void FixedUpdate()
    {
        plane.normal = transform.forward;
        plane.distance = transform.position.magnitude;
    }

    public Vector3 projection (Vector3 point)
    {
        return plane.ClosestPointOnPlane(point);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit: " + other.name);
        var target = other.transform.parent.GetComponent<Game03Target>();
        if (target)
            onGet.Invoke(target);
    }
}
