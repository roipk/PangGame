using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUi : MonoBehaviour
{
    private Text ui;
    

    private void OnEnable()
    {
        ui = GetComponent<Text>();
    }

    public void SetTimeFloat(float time)
    {
        ui.text = $"{Mathf.Floor(time / 60).ToString("00")}:{Mathf.Floor(time % 60).ToString("00")}";
    }
   
}
