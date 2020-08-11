using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// touch screen to release
/// touch down
/// touch update
/// touch up
/// </summary>
public class A05Script : MonoBehaviour
{
    public GameObject balloonPrefab;
    public EventTrigger touchArea;
    private GameObject instanced;
    // plane 3d space

    void Start()
    {
        EventTrigger.Entry down = new EventTrigger.Entry();
        down.eventID = EventTriggerType.PointerDown;
        down.callback.AddListener(data => OnPointerDown((PointerEventData)data));
        touchArea.triggers.Add(down);

        EventTrigger.Entry up = new EventTrigger.Entry();
        up.eventID = EventTriggerType.PointerUp;
        up.callback.AddListener(data => OnPointerUp((PointerEventData)data));
        touchArea.triggers.Add(up);

        EventTrigger.Entry move = new EventTrigger.Entry();
        move.eventID = EventTriggerType.Drag;
        move.callback.AddListener(data => OnDrag((PointerEventData)data));
        touchArea.triggers.Add(move);
    }

    void OnPointerDown(PointerEventData data)
    {
        if (instanced == null)
        {
            instanced = GameObject.Instantiate<GameObject>(balloonPrefab);
        }

        if (instanced)
            instanced.transform.position = data.pointerCurrentRaycast.worldPosition;
    }
    void OnPointerUp(PointerEventData data)
    {
        if (instanced)
        {
            instanced.transform.position = data.pointerCurrentRaycast.worldPosition;

            var script = instanced.GetComponent<BalloonScript>();
            script.enabled = true;

            instanced = null;
        }
            
    }
    void OnDrag(PointerEventData data)
    {
        if (instanced)
            instanced.transform.position = data.pointerCurrentRaycast.worldPosition;
    }


    private void OnDisable()
    {
        if (instanced)
            GameObject.Destroy(instanced);
    }

}
