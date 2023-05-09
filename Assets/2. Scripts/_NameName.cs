using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _NameName : MonoBehaviour
{
    GameObject cc;

    // Start is called before the first frame update
    void Start()
    {
        cc = GameObject.Find("Cam_Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.forward = cc.transform.forward;
    }
}
