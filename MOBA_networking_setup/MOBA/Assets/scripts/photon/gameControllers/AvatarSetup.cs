﻿using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarSetup : MonoBehaviour
{
    private PhotonView PV;
    public int charaterValue;
    public GameObject myCharacter;

    public Camera myCamera;
    public AudioListener myAL;

    public int playerHealth = 100;
    public int playerDmg = 25;

    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
        if (PV.IsMine)
        {
            PV.RPC("RPC_AddCharacter", RpcTarget.AllBuffered, GamePreps.PI.selectedCharacter, GamePreps.PI.selectedSkin);
        }
        else
        {
            Destroy(myCamera);
            Destroy(myAL);
        }
    }
    
    [PunRPC]
    void RPC_AddCharacter(int whichCharacter, int whichSkin)
    {
        charaterValue = whichCharacter;
        myCharacter = Instantiate(GamePreps.PI.allCharacters[whichCharacter],
                                  transform.position,
                                  transform.rotation,
                                  transform);

        SkinnedMeshRenderer myRend = myCharacter.transform
                                        .GetChild(0).transform
                                        .GetChild(0).transform
                                        .GetChild(1).GetComponent<SkinnedMeshRenderer>();
        myRend.material.color = GamePreps.PI.allSkins[whichSkin];

    }
}
