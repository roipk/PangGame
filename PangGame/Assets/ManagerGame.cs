using System;
using System.Collections;
using Unity.Netcode;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ManagerGame :  MonoBehaviour
{
    public static ManagerGame instance;
    [SerializeField] private NetworkManager _networkManager;
    [SerializeField] private float timer = 10;
    [SerializeField] private int balls = 0;
    [SerializeField] private List<GameObject> Players;
    private bool timerIsRunning = false;
    
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        
    }

    private void OnEnable()
    {
        _networkManager.OnClientConnectedCallback += addPlayer;
        _networkManager.OnClientDisconnectCallback += removePlayer;
    }
    private void addPlayer(ulong uid)
    { 
        GameObject player = NetworkManager.Singleton.SpawnManager.GetPlayerNetworkObject(uid).gameObject;
        Players.Add(player);
        player.SetActive(false);
    }
    private void removePlayer(ulong uid)
    {
        Debug.Log("remove");
        Players.Remove(NetworkManager.Singleton.SpawnManager.GetPlayerNetworkObject(uid).gameObject);
    }

    private void OnDisable()
    {
        _networkManager.OnClientConnectedCallback -= addPlayer;
        _networkManager.OnClientDisconnectCallback -= removePlayer;
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


    public void LoadSceneByName(String sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName,LoadSceneMode.Additive);
    }

    public void RemoveSceneByName(string sceneName)
    {
        SceneManager.UnloadSceneAsync(sceneName);
        
    }


}
