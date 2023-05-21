using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class ManagerLevel : MonoBehaviour
{
    private bool single = false;
    

    [SerializeField] private GameObject waitForPlayerTxt;
    // Start is called before the first frame update
    private void OnEnable()
    {
        waitForPlayerTxt.SetActive(true);
    }

    void Start()
    {
        if (!NetworkManager.Singleton.IsClient && !NetworkManager.Singleton.IsServer)
        {
            single = true;
            Init();
        }       
    }

    void Init()
    {
        waitForPlayerTxt.SetActive(false);
    }
    
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
