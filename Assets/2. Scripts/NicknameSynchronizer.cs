using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class NicknameSynchronizer : MonoBehaviourPun
{
    public Text nickname;
    
    [PunRPC]
    void SyncNickname(string name)
    {
        nickname.text = name;
    }
}
