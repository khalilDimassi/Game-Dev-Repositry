using Photon.Realtime;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Networking;
using System.IO;
using System.Collections.Generic;

public class WaitingRoomController : MonoBehaviourPunCallbacks
{
    #region variables
    //photon view for sending rpc that updates the time
    private PhotonView myPhotonView;

    //scene navigation indexes
    [SerializeField]
    private int multiplayerSceneIndex;
    [SerializeField]
    private int lobbySceneIndex;

    //number of players in the room out of room size
    private int playerCount;
    private int roomSize;

    [SerializeField]
    private int minPlayerCountToStart;

    //text variable that holds the timer and player count
    [SerializeField]
    private Text playerCounterDisplay;
    [SerializeField]
    private Text timerToStartDisplay;

    //bool values: if timer can start counting down (min number players reached)
    private bool readyToCountdown;
    private bool readyToStart;
    private bool startingGame;

    //countdown timer variables
    private float timerToStartGame;
    private float notFullGameTimer;
    private float fullGameTimer;

    //countdown timer reset variables
    [SerializeField]
    private float maxWaitTime;
    [SerializeField]
    private float maxFullGameWaitTime;

    //display variables
    [SerializeField]
    public Text[] Team1dis;
    [SerializeField]
    public Text[] Team2dis;
    GameObject playerDisplayer;

    //Instance
    public static WaitingRoomController WRC;
    public int nextPlayerTeam;

    #endregion


    void OnApplicationQuit()
    {
        StartCoroutine(disconnectOffGame(DbManager.username));
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

    private void Start()
    {

        #region intializing variables
        //initialize variables
        if (WaitingRoomController.WRC == null) WaitingRoomController.WRC = this;
        myPhotonView = GetComponent<PhotonView>();
        fullGameTimer = maxFullGameWaitTime;
        notFullGameTimer = maxWaitTime;
        timerToStartGame = maxWaitTime;
        #endregion

        playerCounterUpdate();

        playerDisplayer = PhotonNetwork.Instantiate(Path.Combine("playerFiles", "playerDisplayer"),
                                                    gameObject.transform.position,
                                                    Quaternion.identity,
                                                    0);
    }

    void playerCounterUpdate()
    {
        //update player counter text when players join the room
        //display player count
        //triggers counter time
        playerCount = PhotonNetwork.PlayerList.Length;
        roomSize = PhotonNetwork.CurrentRoom.MaxPlayers;
        playerCounterDisplay.text = playerCount + "/" + roomSize;

        if (playerCount == roomSize)
        {
            readyToStart = true;
        }
        else if (playerCount >= minPlayerCountToStart)
        {
            readyToCountdown = true;
        }
        else
        {
            readyToCountdown = false;
            readyToStart = false;
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        //called whenever new player join the room
        playerCounterUpdate();

        //send master client countdow timer to sync timer for all players
        if (PhotonNetwork.IsMasterClient) myPhotonView.RPC("RPC_SendTimer", RpcTarget.Others, timerToStartGame);
    }


    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        //called when a player leaves the room
        playerCounterUpdate();
    }

    private void Update()
    {
        WaitForMorePlayers();
    }

    void WaitForMorePlayers()
    {
        //if there is one player in the room, te timer will stop and reset
        if (playerCount <= 1)
        {
            resetTimer();
        }
        //if there is a full room
        if (readyToStart)
        {
            fullGameTimer -= Time.deltaTime;
            timerToStartGame = fullGameTimer;
        }
        else if (readyToCountdown)
        {
            notFullGameTimer -= Time.deltaTime;
            timerToStartGame = notFullGameTimer;
        }

        //display and format timer
        string tempTimer = string.Format("{0:00}", timerToStartGame);
        timerToStartDisplay.text = tempTimer;

        //if timer reaches 0, game launches
        if (timerToStartGame <= 0)
        {
            if (startingGame) return;
            StartGame();
        }
    }

    void resetTimer()
    {
        //reset countdown timer
        timerToStartGame = maxWaitTime;
        notFullGameTimer = maxWaitTime;
        fullGameTimer = maxFullGameWaitTime;
    }
    void StartGame()
    {
        //multiplayer scene is loaded to start the game
        startingGame = true;

        if (!PhotonNetwork.IsMasterClient) return;

        PhotonNetwork.CurrentRoom.IsOpen = false;
        PhotonNetwork.LoadLevel(multiplayerSceneIndex);
    }

    public void leaveRoom()
    {
        if (PhotonNetwork.CurrentRoom == null)
        {
            Debug.Log("not in a room to excute leaveRoom()");
            PhotonNetwork.LeaveLobby();
            SceneManager.LoadScene(lobbySceneIndex);
        }
        //leave the waiting room scene
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene(lobbySceneIndex);
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

    [PunRPC]
    private void RPC_SendTimer(float timeIn)
    {
        //RPC for syncing the countdown timer to those who join after the timer started the countdown
        timerToStartGame = timeIn;
        notFullGameTimer = timeIn;
        if (timeIn < fullGameTimer)
        {
            fullGameTimer = timeIn;
        }
    }

}
