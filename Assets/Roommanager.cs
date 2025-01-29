using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class Roommanager : MonoBehaviourPunCallbacks
{
    private int requiredPlayers = 0; // Number of players required to proceed.

    public Button ConnectBtn;
    public TextMeshProUGUI SearchingText;

    public void Start()
    {
        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.GameVersion = "1.0";
        }
    }

    // Called when connected to the Photon server
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Photon Master Server");
        PhotonNetwork.JoinLobby();
        //LoadingScreen.SetActive(false);
        ConnectBtn.gameObject.SetActive(true);

    }

    // Create a room
    public void CreateRoom()
    {
        requiredPlayers = 2; // Set this to the desired number of players for the room
        RoomOptions roomOptions = new RoomOptions
        {
            MaxPlayers = (byte)requiredPlayers

        };
        roomOptions.IsVisible = true; // Room is visible in the lobby
        roomOptions.IsOpen = true;
        PhotonNetwork.CreateRoom("Room" + Random.Range(1000, 9999), roomOptions);

    }

    // Join a random room
    public void JoinRoom()
    {
        PhotonNetwork.JoinRandomRoom();
        ConnectBtn.interactable = false;
        SearchingText.text="Searching";
        Debug.Log("__ROOM JOIN");

    }

    // Called when the room is successfully created
    public override void OnCreatedRoom()
    {
        Debug.Log("__ROOM CREATE__");

    }

    // Called when a player joins the room
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log($"Player {newPlayer.NickName} joined. Players in room: {PhotonNetwork.CurrentRoom.PlayerCount}/{PhotonNetwork.CurrentRoom.MaxPlayers}");

        // Check if all players are in the room
        if (PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers)
        {
            LoadGameScene();
        }
    }

    // Called when the local player successfully joins a room
    public override void OnJoinedRoom()
    {
        Debug.Log($"Joined room: {PhotonNetwork.CurrentRoom.Name}. Players in room: {PhotonNetwork.CurrentRoom.PlayerCount}/{PhotonNetwork.CurrentRoom.MaxPlayers}");

        // Check if the room is full
        if (PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers)
        {
            LoadGameScene();
        }
    }

    // Called if joining a random room fails
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("__JOIN ROOM FAIL");
        CreateRoom();
        ConnectBtn.interactable = false;
    }

    // Load the game scene
    private void LoadGameScene()
    {
        Debug.Log("All players have joined. Loading the game scene...");
        Debug.Log("AllPlayerEnter");
        PhotonNetwork.LoadLevel(1);
        //SceneManager.LoadScene(0, LoadSceneMode.Additive);
    }
    public void LoadSceneByIndex(int Sceneint)
    {
        SceneManager.LoadScene(Sceneint); // Replace '1' with the build index of the scene you want to load.
    }
}
