using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;

public class LoginManager : MonoBehaviourPunCallbacks
{

    public TMP_InputField PlayerName_InputField;

    void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    #region UI Callback Methods
    public void ConnectedToPhotonServer()
    {
        if (PlayerName_InputField != null)
        {
            PhotonNetwork.NickName = PlayerName_InputField.text;
            PhotonNetwork.ConnectUsingSettings();
        }
       
    }
    #endregion


    #region Photon Callback Methods

    public override void OnConnected()
    {
        //base.OnConnected();
        Debug.Log("onConnected is called. The server is avaiable.");
    }

    // This method is called when the user successfully connected to the Photon server
    public override void OnConnectedToMaster()
    {
        //base.OnConnectedToMaster();
        //Debug.Log("Connected to the Master Server with player name: "+PhotonNetwork.NickName);
        Debug.Log("Connected to the Master Server ");
    }
    #endregion

    
}
