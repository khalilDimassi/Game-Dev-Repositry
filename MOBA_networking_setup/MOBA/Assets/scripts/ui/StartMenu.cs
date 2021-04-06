using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class StartMenu : MonoBehaviour
{
    #region main UI buttons
    public GameObject playBtn;
    public GameObject leaderBoardBtn;
    public GameObject rulesBtn;
    public GameObject ExitBtn;
    #endregion

    #region Profile Details:
    public Text usernameDisplay;
    public Text userLevelDisplay;
    public Text userExpDisplay;
    #endregion

    private void Awake()
    {
        usernameDisplay.text = DbManager.userInfo[11];
        userLevelDisplay.text ="Level: " + DbManager.userInfo[9];
        userExpDisplay.text ="Exp: " +  DbManager.userInfo[10];
    }

    public void goToLobby()
    {
        SceneManager.LoadScene(3);
    }
}
