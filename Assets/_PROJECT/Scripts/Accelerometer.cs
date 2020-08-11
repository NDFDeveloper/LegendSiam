using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Accelerometer : MonoBehaviour
{
    public ShakeEvent[] events;
    
    
    private float updateInterval = 1f / 60f;
    private float lowPassInSeconds = 1f;
    private float lowPassFilter;
    private Vector3 lowPassValue;

    private float pow2_shakeThreshold;
    private float pow2_bigShakeThreshold;

    [System.Serializable]
    public class ShakeEvent
    {
        [SerializeField]
        private string label;
        [SerializeField]
        private float threshold = 2f;
        private float pow2_threshold;
        public UnityEvent onEvent;

        public void Start()
        {
            pow2_threshold = threshold * threshold;
        }

        public bool Update(float delta)
        {
            if (delta >= threshold)
            {
                onEvent.Invoke();

                return true;
            }

            return false;
        }
    }

    private void Start()
    {
        lowPassFilter = updateInterval / lowPassInSeconds;
        foreach (var item in events)
            item.Start();

        lowPassValue = Input.acceleration;
    }

    private void Update()
    {
        var acceleration = Input.acceleration;
        lowPassValue = Vector3.Lerp(lowPassValue, acceleration, lowPassFilter);
        var delta = (acceleration - lowPassValue).sqrMagnitude;
        

        for (int i = 0; i < events.Length; i++)
        {
            if (events[i].Update(delta))
                break;
        }
        
    }
}
