using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class porbrun : MonoBehaviour
{
      public Animator m_Animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(GameApplicationManager.Instance.porbrun==true){
           m_Animator.SetBool("Run", true);
       }
    }
}
    