using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class __Test : MonoBehaviourPunCallbacks, IPunObservable
{
    public _StoryContent sc;    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {        
        //photonView.RequestOwnership();
        //if(Input.GetKeyDown(KeyCode.LeftShift))
        //    photonView.RPC("Jebal2", RpcTarget.All);
    }

    //public void Jebal()
    //{
    //    photonView.RPC("Jebal2", RpcTarget.All);
    //}

    //[PunRPC]
    //public void Jebal2()
    //{
    //    sc.sc_name = ss.text;
    //}

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(sc.sc_name);
            stream.SendNext(sc.sc_content);
            stream.SendNext(sc.sc_Template);
            stream.SendNext(sc.sc_Trip1);
            stream.SendNext(sc.sc_Trip2);
            stream.SendNext(sc.sc_Trip3);
            stream.SendNext(sc.sc_Trip4);
            stream.SendNext(sc.sc_Trip5);
        }
        else
        {
            sc.sc_name = (string)stream.ReceiveNext();
            sc.sc_content = (string)stream.ReceiveNext();
            sc.sc_Template = (string)stream.ReceiveNext();
            sc.sc_Trip1 = (string)stream.ReceiveNext();
            sc.sc_Trip2 = (string)stream.ReceiveNext();
            sc.sc_Trip3 = (string)stream.ReceiveNext();
            sc.sc_Trip4 = (string)stream.ReceiveNext();
            sc.sc_Trip5 = (string)stream.ReceiveNext();
        }
    }
}
