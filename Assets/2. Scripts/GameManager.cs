using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class GameManager : MonoBehaviour, IPunObservable
{
    GameObject player;
    Text playerTxt;

    // Start is called before the first frame update
    void Start()
    {
        //PhotonNetwork.Instantiate("Player", new Vector3(2084, 61, 1268), Quaternion.identity);
        player = PhotonNetwork.Instantiate("Player", new Vector3(860.7f, 70, -428), Quaternion.identity);
        player.GetPhotonView().RPC("SyncNickname", RpcTarget.AllBuffered, AccountManager.id);
        //playerTxt = player.transform.Find("NameCanvas/PlayerNameTxt").GetComponent<Text>();
        //playerTxt.text = AccountManager.id;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        
        if (stream.IsWriting)
        {
            stream.SendNext(playerTxt);
        }
        else
        {
            playerTxt.text = (string)stream.ReceiveNext();
            
        }
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
