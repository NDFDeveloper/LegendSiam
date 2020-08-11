using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameApplicationManager : MonoBehaviour
{
    public bool porbrun ;
    // Start is called before the first frame update
   void Start()
    {
       

    }
    static public GameApplicationManager Instance

    {
        get
        {
            if (_singletonInstance == null)
            {
                _singletonInstance = GameObject.FindObjectOfType<GameApplicationManager>();
                GameObject container = new GameObject("GameApplicationManager");
                _singletonInstance = container.AddComponent<GameApplicationManager>();
            }
            return _singletonInstance;
        }
    }


    static protected GameApplicationManager _singletonInstance = null;
      void Awake()
    {
        if (_singletonInstance == null)
        {
            _singletonInstance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            if (this != _singletonInstance)
            {
                Destroy(this.gameObject);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
