using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class __Test2 : MonoBehaviourPunCallbacks, IPunObservable
{
    public DetailedInformation ddi;

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(ddi.BuildingType);
            stream.SendNext(ddi.BuildingName);
            stream.SendNext(ddi.BuildingKeyword);
            stream.SendNext(ddi.BuildingPrice);
            stream.SendNext(ddi.Adrees1);
            stream.SendNext(ddi.Adrees2);
            stream.SendNext(ddi.Adrees3);
            stream.SendNext(ddi.Adrees4);
            //stream.SendNext(ddi.SiteImage);
        }
        else
        {
            ddi.BuildingType = (string)stream.ReceiveNext();
            ddi.BuildingName = (string)stream.ReceiveNext();
            ddi.BuildingKeyword = (string)stream.ReceiveNext();
            ddi.BuildingPrice = (string)stream.ReceiveNext();
            ddi.Adrees1 = (string)stream.ReceiveNext();
            ddi.Adrees2 = (string)stream.ReceiveNext();
            ddi.Adrees3 = (string)stream.ReceiveNext();
            ddi.Adrees4 = (string)stream.ReceiveNext();
            //ddi.SiteImage = (Texture)stream.ReceiveNext();
        }
    }
}
