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

    //[SerializeField]
    //private GameObject testingChar;
    //[SerializeField]
    //private Avatar testingAvatar;

    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
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

        //testing code
        //myCharacter = Instantiate(testingChar, transform.position, transform.rotation, transform);
        //GetComponent<Animator>().avatar = testingAvatar;
        //GetComponent<Animator>().applyRootMotion = true;       
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
