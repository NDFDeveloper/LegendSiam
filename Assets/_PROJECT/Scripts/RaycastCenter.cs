using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RaycastCenter : MonoBehaviour
{
    new Camera camera;

    public float Distance = 100f;
    public LayerMask layer;
    public QueryTriggerInteraction trigger = QueryTriggerInteraction.Collide;

    [System.Serializable]
    public class MyEvent : UnityEvent<RaycastHit[]> { }
    public MyEvent OnRay;

    private void OnEnable()
    {
        camera = Camera.main;
    }
    
    public void DoRay()
    {
        var ray = camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        var hits = Physics.RaycastAll(ray, Distance, layer, trigger);

        OnRay.Invoke(hits);
    }
}
