using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    public Text playerDisplay;
    public Button regBtn;
    public Button loginBtn;

    private void Start()
    {
        if (DbManager.loggedIn)
        {
            playerDisplay.text = "player rank: " + DbManager.userInfo;
            loginBtn.interactable = false;
        }
    }

    public void goToLogin()
    {
        SceneManager.LoadScene(1);
    }
}
