using Photon.Pun;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class GameSetup : MonoBehaviour
{
    public int profileSceneIndex;
    private GameObject pFab;

    public static GameSetup GS;
    public int nextPlayerTeam;

    public Transform[] spawnPointsTeam1;
    public Transform[] spawnPointsTeam2;

    void OnApplicationQuit()
    {
        if (DbManager.username != null)
        {
            StartCoroutine(disconnectOffGame(DbManager.username));
        }
    }

    IEnumerator disconnectOffGame(string username)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/GameDevRep/MOBA_networking_setup/players_accounts/disconnect.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("user Login failed. Error number " + www.downloadHandler.text);
            }
        }
    }
    public void Start()
    {
        if (GameSetup.GS == null) GameSetup.GS = this;
        pFab = PhotonNetwork.Instantiate(Path.Combine("playerFiles", "AvatarInstanciator"),
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
