using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMapManager : MonoBehaviour
{
    public GameObject minimapOpen;
    public GameObject minimapClose;

    public GameObject WorldMap;

    //public AudioSource ass;

    public void WorldMapOn()
    {
        //ass.Play();
        WorldMap.SetActive(true);
    }

    public void WorldMapOff()
    {
        //ass.Play();
        WorldMap.SetActive(false);
    }

    public void MinimapOn()
    {
        minimapOpen.SetActive(false);
        minimapClose.SetActive(true);
    }

    public void MinimapOff()
    {
        minimapOpen.SetActive(true);
        minimapClose.SetActive(false);
    }
}
