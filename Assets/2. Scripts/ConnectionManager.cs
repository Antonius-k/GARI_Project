using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class ConnectionManager : MonoBehaviourPunCallbacks
{
    //void Start()
    //{
    //    PhotonNetwork.ConnectUsingSettings();

    //}
    public InputField id;
    public InputField pw;

    public PanelAnimator pa;

    public AudioSource asss;

    private void Update()
    {
    //    if(Input.GetKeyDown(KeyCode.P))
    //        PhotonNetwork.ConnectUsingSettings();
    }

    public void LoginAccess()
    {
        if (AccountManager.Login(id.text, pw.text))
        {
            pa.StartAnimIn();
            print("LoginSuccess");

            asss.Play();

            Invoke("LoginAccessInvoke", 4.0f);
        }
        else
            print("LoginFailed");
    }

    void LoginAccessInvoke()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnected()
    {
        base.OnConnected();

    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();

        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();

        PhotonNetwork.LoadLevel("LobbyScene");
    }
}
