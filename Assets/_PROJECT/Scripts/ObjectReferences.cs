using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectReferences : MonoBehaviour
{

    public new Transform camera;
    public Transform ghostHandTarget;

    private void Start()
    {
        if (camera == null)
            camera = Camera.main.transform;
    }
    private void Update()
    {
        // follow camera
        transform.position = camera.position;
        transform.rotation = camera.rotation;
    }
}
