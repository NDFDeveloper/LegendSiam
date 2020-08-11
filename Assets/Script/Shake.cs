using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    
  
    //    Debug.Log("Shaking");
    }

    // Update is called once per frame
    void Update()
    {
      
            Handheld.Vibrate();
      Vibration.Vibrate(1000); 
  
          
    }
    public void ButtonShaking(){
        
    }
}
