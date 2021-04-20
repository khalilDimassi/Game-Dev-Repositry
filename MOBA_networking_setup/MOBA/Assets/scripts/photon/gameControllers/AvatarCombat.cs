using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvatarCombat : MonoBehaviour
{
#pragma warning disable 649
    [SerializeField] public PhotonView PV;
    [SerializeField] public AvatarSetup avatarSetup;
    [SerializeField] public Transform rayOrigin;
    [SerializeField] public Text healthDisplay;

    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
        avatarSetup = GetComponent<AvatarSetup>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (PV.IsMine && Input.GetMouseButtonDown(0))
        //{
        //    PV.RPC("RPC_Shooting", RpcTarget.All);
        //}

        if (PV.IsMine)
        {
            healthDisplay.text = avatarSetup.playerHealth.ToString();
        }
    }

    [PunRPC]
    void RPC_Shooting()
    {
        RaycastHit hit;
        if (Physics.Raycast(rayOrigin.position, rayOrigin.TransformDirection(Vector3.forward), out hit, 1000) && hit.transform.tag == "Avatar")
        {
            hit.transform.gameObject.GetComponent<AvatarSetup>().playerHealth -= avatarSetup.playerDmg;
        }
    }
}
