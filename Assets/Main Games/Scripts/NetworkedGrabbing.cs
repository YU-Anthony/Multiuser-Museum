using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkedGrabbing : MonoBehaviourPunCallbacks, IPunOwnershipCallbacks
{
    //IPunOwnershipCallbacks interface contaons the callback methods for the ownership transfer
    PhotonView m_photonView;
    Rigidbody rb;
    public bool isBeingHeld = false; // we can keep track if an object is being held or not

    private void Awake()
    {
        m_photonView = GetComponent<PhotonView>();
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isBeingHeld)
        {
            rb.isKinematic = true;
            gameObject.layer = 13; // The 13rd layer is "InHand" layer, this make sure the other players cannot grab the object when I is grabbing
        }
        else
        {
            rb.isKinematic = false;
            gameObject.layer = 8; // Change the layer back to Interactable
        }
        
    }

    void TransferOwnership ()
    {
        m_photonView.RequestOwnership();
    }

    public void OnSelectEnter()
    {
        Debug.Log("Grabbed");
        m_photonView.RPC("StartNetworkedGrabbing",RpcTarget.AllBuffered); // This will send this RPC to everyone else in the room and the players who join later.

        if (m_photonView.Owner == PhotonNetwork.LocalPlayer)
        {
            Debug.Log("We do not request the ownership. Already mine");
        }
        else
        {
            TransferOwnership();
        }

        
    }

    public void OnSelectExit()
    {

        Debug.Log("Released");
        m_photonView.RPC("StopNetworkedGrabbing", RpcTarget.AllBuffered);
    }

    public void OnOwnershipRequest(PhotonView targetView, Player requestingPlayer)
    {
        // If these views are not the same, this method should not be called for this object
        // Because this method should be caled only for the grabbed object
        if (targetView != m_photonView)
        {
            return;
        }

        Debug.Log("OnOwnerShip Requested for: " + targetView.name + " from " + requestingPlayer.NickName);
        m_photonView.TransferOwnership(requestingPlayer);
    }

    // Called when the ownership transfer is completed
    public void OnOwnershipTransfered(PhotonView targetView, Player previousOwner)
    {
        Debug.Log("Transfer is complete. New owner: " + targetView.Owner.NickName);

        if (photonView.IsMine)
        {
            m_photonView.RPC("StartNetworkGrabbing", RpcTarget.AllBuffered);
        }

    }

    // These RPC methods will start and stop the networked grabbing across the network
    // They will help us disable gravity in all players when the object is grabbed or dropped
    [PunRPC]
    public void StartNetworkedGrabbing()
    {
        isBeingHeld = true; // This will make sure that isKinenmatic will stay true while I hold the object
    }

    [PunRPC]
    public void StopNetworkedGrabbing()
    {
        isBeingHeld = false;
    }

    public void OnOwnershipTransferFailed(PhotonView targetView, Player senderOfFailedRequest)
    {
        throw new System.NotImplementedException();
    }
}
