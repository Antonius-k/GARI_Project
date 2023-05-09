using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        CreateRoom();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 10;
        roomOptions.IsVisible = true;

        PhotonNetwork.CreateRoom("Gari", roomOptions);
    }

    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        base.OnCreateRoomFailed(returnCode, message);
        print("OnCreateRoomFailed." + returnCode + ". " + message);

        JoinRoom();
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom("Gari");
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();

        //SceneManager.LoadScene("MainScene");
        PhotonNetwork.LoadLevel("CYM_MainScene");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        base.OnJoinRandomFailed(returnCode, message);
        print("OnJoinedRoomFailed." + returnCode + ". " + message);
    }
}
