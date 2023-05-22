using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ManagerLevel : MonoBehaviour
{
    [SerializeField] private TextUi _timer;
    [SerializeField] private GameObject _ball;
    
    [SerializeField] private float _startGameDelay;
    [SerializeField] private float _endGame;
    [SerializeField] private GameObject waitForPlayerTxt;

    [Space] [SerializeField] private UnityEvent _onStartGame;
    // Start is called before the first frame update
    private void OnEnable()
    {
        waitForPlayerTxt.SetActive(true);
    }

    
    void Start()
    {
        Debug.Log(NetworkManager.Singleton.IsClient +" "+ NetworkManager.Singleton.IsServer +" "+ NetworkManager.Singleton.IsHost);
        if (ManagerGame.instance.singlePlayer)
        {
            waitForPlayerTxt.SetActive(false);
            _timer.gameObject.SetActive(true);
        }
        else
        {
            waitForPlayerTxt.SetActive(true); 
        }
    }
    
    
    public void StartLevel()
    {
        Debug.Log("start");
        _onStartGame.Invoke();
        
    }
    // Update is called once per frame
    void Update()
    {
        if (_startGameDelay > 0)
        {
            _startGameDelay -= Time.deltaTime;
            if (_startGameDelay < 0)
            {
                _startGameDelay = 0;
                StartLevel();
            }
            
            _timer.SetTimeFloat(_startGameDelay);
        } 
    }
    
   
}
