using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class CollisionCollision : MonoBehaviourPunCallbacks
{
    public GameObject body;
    public GameObject signPanel;

    //private void OnCollisionEnter(Collision other)
    //{        
    //    if (other.gameObject.tag == "Structure")
    //    {
    //        print("Äô");
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Structure")
        {
            //Destroy(other.gameObject);
            //GetComponent<BoxCollider>().enabled = false;
            Destroy(gameObject.GetComponent<Rigidbody>());
            body.SetActive(false);
            signPanel.SetActive(true);

            BuildManager bm = GameObject.Find("BuildManager").GetComponent<BuildManager>();
            bm.buildcount++;
        }

        //if (other.gameObject.tag == "Player")
        //{
        //    di.didi();
        //}
    }

    //private void Update()
    //{
    //    if(callNum <= 2)
    //        PhotonNetwork.Instantiate("CombinationBuilding", gameObject.transform.position, Quaternion.identity);
    //}

    private void Start()
    {
        StartCoroutine(DestRigid());

        Invoke("StopStop", 2.0f);
    }

    public void StopStop()
    {
        GetComponent<CollisionCollision>().enabled = false;
    }

    IEnumerator DestRigid()
    {
        yield return new WaitForSeconds(5.0f);
        Destroy(gameObject.GetComponent<Rigidbody>());
    }
}
