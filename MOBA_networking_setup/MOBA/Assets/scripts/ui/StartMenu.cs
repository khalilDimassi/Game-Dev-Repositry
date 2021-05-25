using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class StartMenu : MonoBehaviour
{
    #region main UI buttons
    public GameObject leaderBoardBtn;
    public GameObject rulesBtn;
    public GameObject ExitBtn;
    public GameObject SelectBtn;
    #endregion

    #region Profile Details:
    public Text usernameDisplay;
    public Text userLevelDisplay;
    #endregion

    private void Awake()
    {
        if (DbManager.userInfo == null)
        {
            return;
        }
        else
        {
            usernameDisplay.text = DbManager.userInfo[11];
            userLevelDisplay.text ="Level: " + DbManager.userInfo[9];
        }
    }

    public void goToLobby()
    {
        SceneManager.LoadScene(3);
    }

    public void disconnectAndExit()
    {
        StartCoroutine(disconnectOffGame(DbManager.username));
        Application.Quit();
        Debug.Log("game exiting!");
    }


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
}
