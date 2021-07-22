using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class PlayerNetworkSetup : MonoBehaviourPunCallbacks
{

    public GameObject LocalXRRigGameobject;
    public GameObject AvatarHeadGameObject;
    public GameObject AvatarBodyGameObject;

    public GameObject MainAvatarGameobject;

    public TextMeshProUGUI PlayerName_Text;

    // Start is called before the first frame update
    void Start()
    {
        // Setup the player
        if (photonView.IsMine)
        {
            // the player is local
            LocalXRRigGameobject.SetActive(true);
            //gameObject.GetComponent<MovementController>().enabled = true;
            gameObject.GetComponent<AvatarInputConverter>().enabled = true;

            SetLayerRecursively(AvatarHeadGameObject,11); // the number here is depends on what you set in the unity editor
            SetLayerRecursively(AvatarBodyGameObject,12);


            // Assign the teleportation provider via script
            TeleportationArea[] teleportationAreas = GameObject.FindObjectsOfType<TeleportationArea>();

            if (teleportationAreas.Length > 0)
            {
                Debug.Log("Found " + teleportationAreas.Length + " teleportation area.");
                foreach (var item in teleportationAreas)
                {
                    item.teleportationProvider = LocalXRRigGameobject.GetComponent<TeleportationProvider>();
                }
            }

            MainAvatarGameobject.AddComponent<AudioListener>();
        }
        else
        {
            // the player is remote
            LocalXRRigGameobject.SetActive(false);
            //gameObject.GetComponent<MovementController>().enabled = false;
            gameObject.GetComponent<AvatarInputConverter>().enabled = false;


            //Remote player can be seen by the local player
            //So, we set the avatar head and body to Default layer
            SetLayerRecursively(AvatarHeadGameObject, 0); // the number here is depends on what you set in the unity editor
            SetLayerRecursively(AvatarBodyGameObject, 0);
        }

        if (PlayerName_Text != null)
        {
            PlayerName_Text.text = photonView.Owner.NickName;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // This function is used to set layers
    void SetLayerRecursively(GameObject go, int layerNumber)
    {
        if (go == null) return;
        foreach (Transform trans in go.GetComponentInChildren<Transform>(true))
        {
            trans.gameObject.layer = layerNumber;
        }
    }
}
