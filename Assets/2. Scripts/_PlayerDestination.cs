using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _PlayerDestination : MonoBehaviour
{
    public string trip1;
    public string trip2;
    public string trip3;
    public string trip4;
    public string trip5;

    DetailedInformation di;

    // Start is called before the first frame update
    void Start()
    {
        trip1 = "부산대학교";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Structure")
        {
            di = other.gameObject.GetComponent<DetailedInformation>();

            print(di);
            print(trip1);

            //if (di.BuildingName == trip1)
            //    print("222");
            //else
            //    print("333");
        }

        


    }
}
