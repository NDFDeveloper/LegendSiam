using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class A06 : MonoBehaviour
{
    public GameObject canvas;
    public GameObject hitBox;
    public int HandHp = 5;
    public ParticleSystem fx;
    public ObjectReferences cameraRef;
    private int hp;
     public GameObject modelnaka;
  
    public Transform startPoint;
    public AnimationCurve curve;
    
    void Start()
    {
        // add event onclick
        var et = hitBox.GetComponent<EventTrigger>();
        var entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        entry.callback.AddListener(data => OnClickHitBox((PointerEventData)data));
        et.triggers.Add(entry);
    }

    void OnClickHitBox(PointerEventData data)
    {
        hp--;

        // spawn hit effect
        fx.transform.position = data.pointerCurrentRaycast.worldPosition;
        fx.transform.rotation = Quaternion.LookRotation(data.pointerCurrentRaycast.worldNormal);
        fx.Play(); // fx should be world space
    }

    [ContextMenu("test play")]
    public void ClickPlay()
    {
        Debug.Log("P");
        if (canvas)
            canvas.SetActive(false);

        if (coroutine != null)
            StopCoroutine(coroutine);
        coroutine = StartCoroutine(step1());
    }
    void Update(){
        Debug.Log(hp);
        if(hp>0){      
        modelnaka.SetActive(true);
        }
        if(hp<=0){
        modelnaka.SetActive(false); 
        }
        if(hp==1){
  GameApplicationManager.Instance.porbrun=true;
        }

     }

    Coroutine coroutine;
    IEnumerator step1()
    {
          hitBox.SetActive(true);
        yield return StartCoroutine(move_ghost_hand()); // move hit box to front of camera
      

        hp = HandHp;
        
        while (hp > 0)
            yield return null;
        
        yield return StartCoroutine(move_ghost_hand_back());
        hitBox.SetActive(false);

        //
        Debug.Log("done");

        if (canvas)
            canvas.SetActive(true);
    }

    IEnumerator move_ghost_hand()
    {
        var value = 0f;

        while (value < 1f)
        {
            value += Time.deltaTime;
            var clamped = Mathf.Clamp(value, 0f, 1f);
            var curved = curve.Evaluate(clamped);
            hitBox.transform.position = Vector3.Lerp(startPoint.position, cameraRef.ghostHandTarget.position, curved);
            yield return null;
        }
    }

    IEnumerator move_ghost_hand_back()
    {
        var value = 0f;

        while (value < 1f)
        {
            value += Time.deltaTime;
            var clamped = Mathf.Clamp(value, 0f, 1f);
            hitBox.transform.position = Vector3.Lerp(cameraRef.ghostHandTarget.position, startPoint.position, clamped);
            yield return null;
        }
    }


}
