using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ManagerGame : MonoBehaviour
{
    public static ManagerGame instance;
    [SerializeField] private float timer = 10;
    [SerializeField] private int balls = 0;

    private bool timerIsRunning = true;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    private void Update()
    {
        if (timerIsRunning)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                Debug.Log("game over");
                timer = 0;
                timerIsRunning = false;
            }
        }
    }


    public void AddBall()
    {
        balls++;
    }
    public void RemoveBall()
    {
        balls--;
        if (balls <= 0)
        {
            Debug.Log("end game");
        }
    }
    
    
    
    
    
}
