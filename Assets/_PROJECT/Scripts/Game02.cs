using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Game02 : MonoBehaviour
{
    public float LifePoint = 10;
    public float BreakPoint = 6;
    public float RegenSpeed = 0.2f;

    public UnityEvent OnDone;
    public UnityEvent OnBreak;

    private float life_point;
    private float break_point;

    private float end_life_point;
    private float end_break_point;

    void init()
    {
        life_point = 0;
        break_point = 0;

        end_life_point = LifePoint * Random.Range(0.7f, 1.3f);
        end_break_point = BreakPoint * Random.Range(0.7f, 1.3f);
    }

    #region Events
    public void smallShake()
    {
        life_point += 1f * Random.Range(0.5f, 1.5f);
        break_point += 0.5f * Random.Range(0.5f, 1.5f);

        detectEvent();
    }
    public void bigShake()
    {
        life_point += 1f * Random.Range(0.5f, 1.5f);
        break_point += 1f * Random.Range(0.75f, 1.5f);

        detectEvent();
    }

    void detectEvent()
    {
        if (life_point >= end_life_point)
        {
            OnDone.Invoke();
            init();
        }
        else if (break_point >= end_break_point)
        {
            OnBreak.Invoke();
            init();
        }
    }
    #endregion

    void Start()
    {
        init();
    }

    void Update()
    {
        if (life_point > 0)
            life_point -= Time.deltaTime * RegenSpeed;
        if (break_point > 0)
            break_point -= Time.deltaTime * RegenSpeed;

        //Test();
    }

    //void Test()
    //{
    //    if (Input.GetKeyDown(KeyCode.Alpha1))
    //    {
    //        smallShake();
    //    }
    //    else if (Input.GetKeyDown(KeyCode.Alpha2))
    //    {
    //        bigShake();
    //    }
    //}
}
