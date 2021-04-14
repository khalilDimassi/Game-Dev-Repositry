using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarSetup : MonoBehaviour
{
    private PhotonView PV;
    public int charaterValue;
    public GameObject myCharacter;

    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
        if (PV.IsMine)
        {
            PV.RPC("RPC_addCharacter", RpcTarget.AllBuffered, GamePreps.PI.selectedCharacter);
        }
    }
    
    [PunRPC]
    void RPC_AddCharacter(int whichCharacter)
    {
        myCharacter = Instantiate(GamePreps.PI.allCharacters[whichCharacter], transform.position, transform.rotation, transform);
    }
}
