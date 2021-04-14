using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSetup : MonoBehaviour
{
    public int profileSceneIndex;
    private GameObject pFab;

    public static GameSetup GS;
    public int nextPlayerTeam;

    public Transform[] spawnPointsTeam1;
    public Transform[] spawnPointsTeam2;

    public void Start()
    {
        Debug.Log("enabled GS");

        if (GameSetup.GS == null)
        {
            GameSetup.GS = this;
        }

        Debug.Log("instanciating playerFab");
        pFab = PhotonNetwork.Instantiate(Path.Combine("playerFiles", "playerPrefab"),
                                         gameObject.transform.position,
                                         gameObject.transform.rotation,
                                         0);
    }

    public void disconnectPlayer()
    {
        StartCoroutine(disconnectAndLoad());
    }

    IEnumerator disconnectAndLoad()
    {
        PhotonNetwork.Disconnect();
        while (PhotonNetwork.IsConnected)
        {
            yield return null;
        }
        SceneManager.LoadScene(profileSceneIndex);
    }

    public void updateTeam()
    {
        if (nextPlayerTeam == 1)
        {
            nextPlayerTeam = 2;
        }
        else
        {
            nextPlayerTeam = 1;
        }
    }
}
