using Photon.Pun;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EscapeMenu : MonoBehaviour
{
    #region UI elements
    [SerializeField] GameObject escMenuPanel;
    [SerializeField] Text usernameDisplay;
    [SerializeField] GameObject reminderTocken;
    [SerializeField] Text timerToDc;
    [SerializeField] Button dcComfirmBtn;
    [SerializeField] Button dcBtn;
    #endregion

    [SerializeField] public PhotonView PV;
    [SerializeField] public int profileSceneIndex;

    public static bool pauseMenuOut = false;
    private float timeRemaining = 10;

    private void Awake()
    {
        if (PV.IsMine)
        {
            usernameDisplay.text = DbManager.username;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && PV.IsMine)
        {
            if (pauseMenuOut)
            {
                hide();
            }
            else
            {
                show();
            }
        }

        if (reminderTocken.activeInHierarchy)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                timerToDc.text = timeRemaining.ToString();
            }
            else
            {
                dcComfirmBtn.interactable = true;
            }

            string tempTimer = string.Format("{00}", timerToDc);
            timerToDc.text = tempTimer;
        }
    }


    private void show()
    {
        if (reminderTocken.activeInHierarchy)
        {
            reminderTocken.SetActive(false);
            dcComfirmBtn.interactable = false;
        }

        escMenuPanel.SetActive(true);
        pauseMenuOut = true;

        Debug.Log("menu up");
    }

    private void hide()
    {
        escMenuPanel.SetActive(false);
        pauseMenuOut = false;

        if (reminderTocken.activeInHierarchy)
        {
            cancelDc();
        }

        Debug.Log("menu down");
    }

    public void firstDc()
    {
        Debug.Log("this button is hella clicked");
        dcBtn.gameObject.SetActive(false);
        reminderTocken.SetActive(true);
    }

    public void cancelDc()
    {
        reminderTocken.SetActive(false);
        //reset countdown timer
        timeRemaining = 10;
        dcComfirmBtn.interactable = false;
        dcBtn.gameObject.SetActive(true);
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
}
