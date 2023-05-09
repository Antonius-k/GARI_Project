using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkBtn : MonoBehaviour
{
    public GameObject StorySetPanel;
    public GameObject btn1;
    public GameObject btn2;

    public GameObject localPanel;
    //----------

    //public AudioSource ass;

    public void LinkPanelOn()
    {
        StorySetPanel.SetActive(true);
        btn1.SetActive(false);
        btn2.SetActive(true);
        localPanel.SetActive(true);
        //ass.Play();
    }

    public void LinkPanelOff()
    {
        StorySetPanel.SetActive(false);
        btn1.SetActive(true);
        btn2.SetActive(false);
        
        //ass.Play();
    }
}
