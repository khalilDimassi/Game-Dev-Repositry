using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhotonLobby : MonoBehaviourPunCallbacks
{
    public static PhotonLobby lobby;

    public GameObject matchUpButton;
    public GameObject cancelButton;

    public byte roomSize = 2;

    private void Awake()
    {
        lobby = this; //singleton declaration in the main menu
    }

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings(); //connect to master photon 
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        Debug.Log("player has connected to photon master server");
        matchUpButton.SetActive(true); //player is connected, enabling match up button to search for rooms
    }

    public void onMatchUpBtnClicked()
    {
        matchUpButton.SetActive(false);
        cancelButton.SetActive(true);

        PhotonNetwork.JoinRandomRoom(); //picks random room of the available for the player to join
        Debug.Log("Looking for rooms ...");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {       
        Debug.Log("tried to joing a random room and failed. there must be no open rooms available, " + message);
        createRoom(); 
    }


    void createRoom()
    {
        Debug.Log("trying to create new Room");

        int randomRoomName = Random.Range(0, 10000);
        RoomOptions roomOps = new RoomOptions() {IsVisible = true, IsOpen = true, MaxPlayers = (byte)roomSize}; //make new room options: visible, available and hosts 10 players at max
        PhotonNetwork.CreateRoom("Room n: " + randomRoomName, roomOps); //create the room
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("tried to create room failed, there must be two rooms with the same name, " + message);
        createRoom(); //recreate room after failing
    }


    public override void OnJoinedRoom()
    {
        Debug.Log("room joined successfully");
    }

    public void onCancelBtnClicked()
    {
        Debug.Log("left room!");

        cancelButton.SetActive(false);
        matchUpButton.SetActive(true);

        PhotonNetwork.LeaveRoom();
    }

    public void returnToLobby()
    {
        if (PhotonNetwork.InRoom)
        {
            onCancelBtnClicked();
        }

        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.Disconnect();
        }

        SceneManager.LoadScene(2);
    }
}
