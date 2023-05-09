using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class BuildStructure2 : MonoBehaviourPun
{
    public GameObject constructionSite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            if (Input.GetKeyDown(KeyCode.B))
                constructionSite.SetActive(true);
        }
    }

    public void BuildBtn1()
    {
        constructionSite.SetActive(true);        
    }
}
