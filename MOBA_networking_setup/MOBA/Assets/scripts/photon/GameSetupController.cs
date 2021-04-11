using Photon.Pun;
using System.IO;
using UnityEngine;


public class GameSetupController : MonoBehaviour
{
    private void Start()
    {
        //create a player object for each networked player loads in the multiplayer scene
        createPlayer();
    }

    private void createPlayer()
    {
        Debug.Log("Creating player gameObject");
        PhotonNetwork.Instantiate(Path.Combine("playerFiles", "playerPrefab"), Vector3.zero, Quaternion.identity);
    }
}
