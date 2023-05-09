using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class _PlusBtn : MonoBehaviourPunCallbacks
{
    public _StoryContent[] stories;

    public GameObject WritePack2;
    public InputField wp2_name;
    public InputField wp2_content;
    public InputField wp2_trip1;
    public InputField wp2_trip2;
    public InputField wp2_trip3;
    public InputField wp2_trip4;
    public InputField wp2_trip5;
    public Text wp2_Template;

    public GameObject[] stories2;

    _StoryContent si;
    GameObject sii;

    public void StoryCall()
    {
        WritePack2.SetActive(true);
        //if (photonView.IsMine)
        //    WritePack2.SetActive(true);       
    }

    public void WriteWrite()
    {
        //sii = PhotonNetwork.Instantiate("StorySet", transform.position, Quaternion.identity);
        photonView.RPC("WriteWrite2", RpcTarget.All);

        
        //if (photonView.IsMine)
        //{
        //    photonView.RPC("WriteWrite2", RpcTarget.All); 
        //}
    }

    [PunRPC]
    public void WriteWrite2()
    {
        for (int i = 0; i < stories2.Length; i++)
        {
            if (stories2[i].activeSelf == false)
            {
                stories2[i].SetActive(true);
                si = stories2[i].GetComponent<_StoryContent>();                

                photonView.RequestOwnership();                

                si.sc_name = wp2_name.text;
                si.sc_content = wp2_content.text;
                si.sc_Trip1 = wp2_trip1.text;
                si.sc_Trip2 = wp2_trip2.text;
                si.sc_Trip3 = wp2_trip3.text;
                si.sc_Trip4 = wp2_trip4.text;
                si.sc_Trip5 = wp2_trip5.text;
                si.sc_Template = wp2_Template.text;
                si.yValue -= 250;


                wp2_name.text = "";
                wp2_content.text = "";
                wp2_trip1.text = "";
                wp2_trip2.text = "";
                wp2_trip3.text = "";
                wp2_trip4.text = "";
                wp2_trip5.text = "";
                WritePack2.SetActive(false);

                break;
            }
        }

        //si = sii.GetComponent<_StoryContent>();

        
    }
}
