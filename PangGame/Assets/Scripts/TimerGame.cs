using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class TimerGame : MonoBehaviour
{
    [SerializeField] private UnityEvent _endTime;
    private static float timeLeft;
    private bool startTimer;
    private Slider _slider;
    // Start is called before the first frame update
    void Start()
    {
        _slider = GetComponent<Slider>();
        timeLeft = _slider.maxValue;
    }

    public static float GetTime()
    {
        return timeLeft;
    }
    // Update is called once per frame
    void Update()
    {
        if (startTimer)
        {
            timeLeft -= Time.deltaTime;
            _slider.value = timeLeft;
            if (timeLeft <= 0)
            {
                timeLeft = 0;
                startTimer = false;
                _endTime.Invoke();
            }
        }
    }

    public void SetTimerStatus(bool isActive)
    {
        startTimer = isActive;
    }
}
