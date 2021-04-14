using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PhotonPlayer : MonoBehaviour
{
    public PhotonView PV;
    public GameObject myAvatar;
    public int myTeam;


    void Start()
    {
        PV = GetComponent<PhotonView>();
        Debug.Log("pv assigned: " + PV.IsMine);
        if (PV.IsMine)
        {
            PV.RPC("RPC_GetTeam", RpcTarget.MasterClient);
        }
    }

    void Update()
    {
        if (myAvatar == null && myTeam != 0)
        {
            if (myTeam == 1)
            {
                int spawnPicker = PV.OwnerActorNr - 1;
                if (PV.IsMine)
                {
                    myAvatar = PhotonNetwork.Instantiate(Path.Combine("playerFiles", GamePreps.PI.allCharacters[GamePreps.PI.selectedCharacter].name),
                                                         GameSetup.GS.spawnPointsTeam1[0].position,
                                                         GameSetup.GS.spawnPointsTeam1[0].rotation,
                                                         0);
                    Debug.LogError(GamePreps.PI.allCharacters[GamePreps.PI.selectedCharacter].name + "//" + GamePreps.PI.selectedCharacter.ToString());
                }
            }
            else
            {
                int spawnPicker = PV.OwnerActorNr - 1;
                if (PV.IsMine)
                {
                    myAvatar = PhotonNetwork.Instantiate(Path.Combine("playerFiles", GamePreps.PI.allCharacters[GamePreps.PI.selectedCharacter].name),
                                                         GameSetup.GS.spawnPointsTeam2[0].position,
                                                         GameSetup.GS.spawnPointsTeam2[0].rotation,
                                                         0);
                    Debug.LogError(GamePreps.PI.allCharacters[GamePreps.PI.selectedCharacter].name + "//" + GamePreps.PI.selectedCharacter.ToString());
                }
            }
        }
    }

    [PunRPC]
    void RPC_GetTeam()
    {
        myTeam = GameSetup.GS.nextPlayerTeam;
        GameSetup.GS.updateTeam();
        PV.RPC("RPC_SentTeam", RpcTarget.OthersBuffered, myTeam);
    }

    [PunRPC]
    void RPC_SentTeam(int whichTeam)
    {
        myTeam = whichTeam;
    }
}
