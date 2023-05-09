using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LYJ_SetSpotComponent : MonoBehaviour
{
    private GameObject[] spots;

    private void Awake()
    {
        spots = new GameObject[transform.childCount];
        
        for (int i = 0; i < transform.childCount; i++)
        {
            print("transform.GetChild(i).gameObject: " + transform.GetChild(i).gameObject);
            spots[i] = transform.GetChild(i).gameObject;
            print(spots[i]);
            spots[i].AddComponent<LYJ_SpotBtnManager>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
