using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public void StartHost() { NetworkManager. Singleton. StartHost(); }
    public void StartClient() { NetworkManager.Singleton.StartClient(); }

    public void Disconnect()
    {
        NetworkManager.Singleton.Shutdown();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
        // NetworkManager.Singleton.DisconnectClient(NetworkManager.ServerClientId);
        // Debug.Log(NetworkManager.Singleton.isActiveAndEnabled);
        // if (NetworkManager.Singleton.isActiveAndEnabled)
        // {
        //    
        // }       // NetworkManager.Singleton.DisconnectClient(NetworkManager.ServerClientId);
    }
    
    
    // public void Disconnect()
    // {
    //     NetworkManager.Singleton.Shutdown();
    //     UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    // }

}
