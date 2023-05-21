using System;
using Unity.Netcode;
using UnityEngine;
using Random = UnityEngine.Random;

public class HelloWorldPlayer : NetworkBehaviour
{
    public NetworkVariable<Vector3> Position = new NetworkVariable<Vector3>();


    private void Start()
    {
        if (IsOwner)
        {
            transform.name = "me";
        }
    }

    public override void OnNetworkSpawn()
    {
        if (IsOwner)
        {
            Move();
        }
    }

    public void Move()
    {
        if (NetworkManager.Singleton.IsServer)
        {
            // var randomPosition = GetRandomPositionOnPlane();
            // transform.position = randomPosition;
            Position.Value = transform.position; //randomPosition;
        }
        else
        {
            SubmitPositionRequestServerRpc();
        }
    }

    [ServerRpc]
    void SubmitPositionRequestServerRpc(ServerRpcParams rpcParams = default)
    {
        Position.Value = transform.position; //GetRandomPositionOnPlane();
    }

    // static Vector3 GetRandomPositionOnPlane()
    // {
    //     return ;//new Vector3(Random.Range(-3f, 3f), -3.5f, Random.Range(-3f, 3f));
    // }

    void Update()
    {
        
            // Debug.Log(NetworkManager.Singleton.IsClient);
            // Debug.Log(NetworkManager.Singleton.IsHost);
            // Debug.Log(NetworkManager.Singleton.IsServer);
            transform.position = Position.Value;
    }
}