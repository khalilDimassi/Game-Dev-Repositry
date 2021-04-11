using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class roomController : MonoBehaviourPunCallbacks
{
    [SerializeField] // scene navigation index
    private int waitingRoomSceneIndex;

    public override void OnEnable()
    {
        //register to photon call back functions
        PhotonNetwork.AddCallbackTarget(this);
    }

    public override void OnDisable()
    {
        //unregister to photon call back functions
        PhotonNetwork.RemoveCallbackTarget(this);
    }

    //after successfully joinging a room
    public override void OnJoinedRoom()
    {
        //load the player into the waiting room scene
        SceneManager.LoadScene(waitingRoomSceneIndex);
    }
}
