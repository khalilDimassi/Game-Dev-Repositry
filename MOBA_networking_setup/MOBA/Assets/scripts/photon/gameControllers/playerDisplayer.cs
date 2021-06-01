using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDisplayer : MonoBehaviour
{
    [SerializeField]
    public PhotonView PV;

    public int myTeam;

    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
        if (PV.IsMine)
        {
            PV.RPC("RPC_GetTeam", RpcTarget.MasterClient);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (myTeam == 0)
        {
            if (WaitingRoomController.WRC.Team1dis[PV.OwnerActorNr - 1].text != DbManager.username)
            {
                WaitingRoomController.WRC.Team1dis[PV.OwnerActorNr - 1].text = DbManager.username;

                foreach (var item in WaitingRoomController.WRC.Team1dis)
                {
                    if (item.text == DbManager.username)
                    {
                        Debug.Log(item.name);
                    }
                }

            }
        }
        else
        {
            if (WaitingRoomController.WRC.Team2dis[PV.OwnerActorNr - 1].text != DbManager.username)
            {
                WaitingRoomController.WRC.Team2dis[PV.OwnerActorNr - 1].text = DbManager.username;
               
                foreach (var item in WaitingRoomController.WRC.Team2dis)
                {
                    if (item.text == DbManager.username)
                    {
                        Debug.Log(item.name);
                    }
                }
            }
        }
    }


    #region RPC functions
    [PunRPC]
    void RPC_GetTeam()
    {
        myTeam = WaitingRoomController.WRC.nextPlayerTeam;
        WaitingRoomController.WRC.updateTeam();
        PV.RPC("RPC_SentTeam", RpcTarget.OthersBuffered, myTeam);
    }

    [PunRPC]
    void RPC_SentTeam(int whichTeam)
    {
        myTeam = whichTeam;
    }
    #endregion
}
