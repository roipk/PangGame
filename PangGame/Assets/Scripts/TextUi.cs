using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUi : MonoBehaviour
{
    private Text ui;

    private void Start()
    {
        ui = GetComponent<Text>();
    }
    

    public void SetTimeFloat(float time)
    {
        if(ui)
            ui.text = $"{Mathf.Floor(time / 60).ToString("00")}:{Mathf.Floor(time % 60).ToString("00")}";
    }
   
}
