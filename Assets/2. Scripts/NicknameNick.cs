using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class NicknameNick : MonoBehaviourPunCallbacks, IPunObservable
{
    public Text nick;

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(nick);
        }
        else
        {
            nick.text = (string)stream.ReceiveNext();
        }
    }
}
