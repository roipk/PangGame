using System;
using Unity.Mathematics;
using Unity.Netcode;
using UnityEngine;
using Random = UnityEngine.Random;

public class NetworkTransformTest : NetworkBehaviour
{
    [SerializeField] private Transform me;
    [SerializeField] private float _speed;

    private void Start()
    {
        me = GetComponent<Transform>();
        me.name = IsOwner ? "Owner" : NetworkObjectId.ToString();
        Debug.Log(me.name);
        transform.GetComponent<Material>().color =  new Color(
            (float)Random.Range(0, 255), 
            (float)Random.Range(0, 255), 
            (float)Random.Range(0, 255)
        );
       
    }

  

    [ServerRpc(RequireOwnership = false)]
    void UpdatePositionServerRpc(Vector3 someValue, ulong sourceNetworkObjectId)
    {
        if (!IsOwner)
        {
            foreach (ulong uid in NetworkManager.Singleton.ConnectedClientsIds)
            {
                Transform other = NetworkManager.Singleton.SpawnManager.GetPlayerNetworkObject(uid)
                    .GetComponent<Transform>();
                Debug.Log(other.name);
                if (transform.name == other.name)
                {
                    // transform.position = other.position;
                    var client = NetworkManager.ConnectedClients[uid];
                    client.PlayerObject.transform.position = someValue;
                }
            }
        }
    }

    void Update()
    {
        
    }
}