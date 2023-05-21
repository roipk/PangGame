using System;
using Unity.Netcode;
using UnityEngine;

public class NetworkTransformTest : NetworkBehaviour
{
    [SerializeField] private Transform me;
    private void Start()
    {
        me = GetComponent<Transform>();
        me.name = IsOwner? "Owner": NetworkObjectId.ToString();
        Debug.Log(me.name);
    }

    [ServerRpc(RequireOwnership = false)]
    void PongServerRpc(Vector3 someValue, ulong sourceNetworkObjectId)
    {
        if(!IsOwner)
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
        if(IsOwner)
            {
                if(Input.GetKeyUp(KeyCode.W))
                {
                    transform.position += Vector3.up;
                    PongServerRpc(transform.position,NetworkObjectId); // Server -> Client
                }
                if(Input.GetKeyUp(KeyCode.S))
                {
                    transform.position += Vector3.down;
                    PongServerRpc(transform.position,NetworkObjectId); // Server -> Client
                }
                if(Input.GetKeyUp(KeyCode.A))
                {
                    transform.position += Vector3.left;
                    PongServerRpc(transform.position,NetworkObjectId); // Server -> Client
                }
                if(Input.GetKeyUp(KeyCode.D))
                {
                    transform.position += Vector3.right;
                    PongServerRpc(transform.position,NetworkObjectId); // Server -> Client
                }
                
            }
         

    }
}