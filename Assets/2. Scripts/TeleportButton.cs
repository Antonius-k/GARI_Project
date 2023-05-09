using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportButton : MonoBehaviour
{
    // Minimap Hide, Open
    public GameObject HideStateBtn;
    public GameObject OpenStateBtn;

    public GameObject BtnSetTeleport;
    bool ese = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ese == true)
            BtnSetTeleport.transform.localPosition = Vector3.Lerp(transform.position, new Vector3(0, 0, 0), Time.deltaTime);
    }

    public void TeleportCall()
    {
        ese = true;
    }

    public void HideStateClick()
    {
        HideStateBtn.SetActive(false);
        OpenStateBtn.SetActive(true);
    }

    public void OpenStateClick()
    {
        HideStateBtn.SetActive(true);
        OpenStateBtn.SetActive(false);
    }
}
