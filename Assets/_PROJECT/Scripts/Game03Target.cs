using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game03Target : MonoBehaviour
{
    public int score;
    public float randomForward = 1f;
    public float force = 1000;
    public new Transform collider;
    public Rigidbody rigid;

    void Start()
    {
        transform.LookAt(transform.position + transform.forward * randomForward + Random.insideUnitSphere);
        // random add force
        rigid.AddForce(transform.forward * force * Random.Range(0.8f, 1.2f));

        GameObject.Destroy(gameObject, 10f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(collider.position, Vector3.one * 0.2f);
    }

}
