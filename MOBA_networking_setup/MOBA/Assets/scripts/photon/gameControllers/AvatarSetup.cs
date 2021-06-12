using Photon.Pun;
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

    public Camera myMiniCam;

    public int playerHealth = 100;
    public int playerDmg = 25;

    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
        Cursor.visible = false;
        if (PV.IsMine)
        {
            PV.RPC("RPC_AddCharacter", RpcTarget.AllBuffered, GamePreps.PI.selectedCharacter);
        }
        else
        {
            Destroy(myCamera);
            Destroy(myAL);
            Destroy(myMiniCam);
        }
    }
    
    [PunRPC]
    void RPC_AddCharacter(int whichCharacter)
    {
        charaterValue = whichCharacter;
        myCharacter = Instantiate(GamePreps.PI.allCharacters[whichCharacter],
                                  transform.position,
                                  transform.rotation,
                                  transform);

        GetComponent<Animator>().avatar = GamePreps.PI.allAvatars[whichCharacter];

    }
}
