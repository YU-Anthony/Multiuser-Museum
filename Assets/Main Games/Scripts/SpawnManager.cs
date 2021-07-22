using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    GameObject GenericVRPlayerPrefab;

    public Vector3 spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {
            // This method will instantiate the player across the network for all clients.
            Debug.Log("Spawn AAAAA");
            PhotonNetwork.Instantiate(GenericVRPlayerPrefab.name,spawnPosition,Quaternion.identity);/*Quaternion.identity is for rotation*/
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
