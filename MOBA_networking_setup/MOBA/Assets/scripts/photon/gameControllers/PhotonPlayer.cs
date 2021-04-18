using Photon.Pun;
using System.IO;
using UnityEngine;

public class PhotonPlayer : MonoBehaviour
{
    #region variables
    public PhotonView PV;
    public GameObject myAvatar;
    public int myTeam;
    #endregion

    void Start()
    {
        PV = GetComponent<PhotonView>();
        if (PV.IsMine)
        {
            PV.RPC("RPC_GetTeam", RpcTarget.MasterClient);
        }
    }

    void Update()
    {
        if (myAvatar == null && myTeam != 0)
        {
            int spawnPicker = PV.OwnerActorNr - 1;
            if (PV.IsMine)
            {
                myAvatar = photonAvatarInstance((this.PV.OwnerActorNr - 1) / 2);
            }
        }
    }

    private GameObject photonAvatarInstance(int spawnPoint)
    {
        Transform[] spawner = myTeam == 1 ? spawner = GameSetup.GS.spawnPointsTeam1 : GameSetup.GS.spawnPointsTeam2;

        return PhotonNetwork.Instantiate(Path.Combine("playerFiles", "AvatarInstanciator"),
                                         spawner[spawnPoint].position,
                                         spawner[spawnPoint].rotation);
    }

    #region RPC functions
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
    #endregion
}
