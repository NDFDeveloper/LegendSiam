using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnPoint : MonoBehaviour
{
    public float radius = 1f;
    public Vector3 GetPosition
    {
        get
        {
            return transform.position + Random.insideUnitSphere * radius;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
