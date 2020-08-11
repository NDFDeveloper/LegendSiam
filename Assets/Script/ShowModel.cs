using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowModel : MonoBehaviour
{
    public GameObject Model;
    public void OnChangeValue()
    {
        bool onoffSwitch = gameObject.GetComponent<Toggle>().isOn;
        if (onoffSwitch)
        {
            Model.SetActive(true);
        }
        else
        {
            Model.SetActive(false);
        }

    }
}
