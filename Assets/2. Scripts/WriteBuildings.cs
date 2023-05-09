using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WriteBuildings : MonoBehaviour
{
    public string buildings1;
    public string buildings2;
    public string buildings3;
    public string buildings4;
    public string buildings5;

    DetailedInformation[] buildings;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Y))
        //{
        //    StoryHearts();
        //}
    }

    public void StoryHearts()
    {
        buildings = GameObject.FindObjectsOfType<DetailedInformation>();

        if (buildings1 != "")
        {
            for (int i = 0; i < buildings.Length; i++)
            {
                if (buildings[i].BuildingName == buildings1)
                {
                    buildings[i].HeartOn();
                }
            }
        }

        if (buildings2 != "")
        {
            for (int i = 0; i < buildings.Length; i++)
            {
                if (buildings[i].BuildingName == buildings2)
                {
                    buildings[i].HeartOn();
                }
            }
        }

        if (buildings3 != "")
        {
            for (int i = 0; i < buildings.Length; i++)
            {
                if (buildings[i].BuildingName == buildings3)
                {
                    buildings[i].HeartOn();
                }
            }
        }

        if (buildings4 != "")
        {
            for (int i = 0; i < buildings.Length; i++)
            {
                if (buildings[i].BuildingName == buildings4)
                {
                    buildings[i].HeartOn();
                }
            }
        }

        if (buildings5 != "")
        {
            for (int i = 0; i < buildings.Length; i++)
            {
                if (buildings[i].BuildingName == buildings5)
                {
                    buildings[i].HeartOn();
                }
            }
        }
    }
}
