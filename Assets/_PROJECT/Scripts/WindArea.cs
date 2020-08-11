using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// wind that affect rigidbody
/// </summary>
public class WindArea : MonoBehaviour
{
    [Header("Force")]
    public float force = 100;
    public float randomForce = 0.3f;

    [Header("Direction")]
    public Transform direction;
   
    public bool randomDirection = true;
    public float randomDirectionTime = 3f;
    private float _nextRandomDir;

    private Vector3 _force;
    private List<Rigidbody> list;

    void Start()
    {
        list = new List<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (randomDirection)
            if (Time.time > _nextRandomDir)
            {
                _nextRandomDir = Time.time + randomDirectionTime * Random.Range(0.7f, 1.3f);
                direction.localPosition = Random.onUnitSphere;
            }


        _force = (direction.position - transform.position).normalized * force * Random.Range(1f - randomForce, 1f + randomForce) * Time.fixedDeltaTime;
        foreach (var item in list)
        {
            if (item)
                item.AddForce(_force * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var rb = other.GetComponent<Rigidbody>();
        if (rb)
        {
            if (list.Contains(rb) == false)
                list.Add(rb);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var rb = other.GetComponent<Rigidbody>();
        if (rb)
        {
            if (list.Contains(rb))
                list.Remove(rb);
        }
    }

    //private BoxCollider box;
    //private void OnDrawGizmos()
    //{
    //    if (!box)
    //        box = GetComponent<BoxCollider>();

    //    if (box)
    //    {
    //        Gizmos.color = Color.green;
    //        Gizmos.DrawWireCube(transform.position + box.center, box.size);
    //        Gizmos.DrawCube(transform.position, Vector3.one * 0.1f);
    //    }
            
    //}
}
