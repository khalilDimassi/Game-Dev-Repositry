using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarCombat : MonoBehaviour
{
    [SerializeField] public PhotonView PV;
    [SerializeField] public AvatarSetup avatarSetup;
    [SerializeField] public Transform rayOrigin;

    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
        avatarSetup = GetComponent<AvatarSetup>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PV.IsMine && Input.GetMouseButtonDown(0))
        {
            PV.RPC("RPC_Shooting", RpcTarget.All);
        }
    }

    [PunRPC]
    void RPC_Shooting()
    {

        RaycastHit hit;
        if (Physics.Raycast(rayOrigin.position, rayOrigin.TransformDirection(Vector3.forward), out hit, 1000) && hit.transform.tag == "Avatar")
        {
            Debug.Log("shot hit: " + hit.transform.name + " " + hit.transform.tag);
            hit.transform.gameObject.GetComponent<AvatarSetup>().playerHealth -= avatarSetup.playerDmg;
            Debug.Log("avatar damagaed");
        }
        else
        {
            Debug.Log("shot didn't hit");
        }
    }
}
