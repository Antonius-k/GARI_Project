using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinationBuilding : MonoBehaviour
{
    public int BuildingCount = 0;
    public int countCount = 0;

    public Transform[] spot;

    public bool s1 = false;
    public bool s2 = false;
    public bool s3 = false;
    public bool s4 = false;
    public bool s5 = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Structure2")
        {
            if (s1 == false)
            {
                other.gameObject.transform.position = spot[0].position;
                other.gameObject.transform.rotation = spot[0].rotation;
                s1 = true;
            }
            else if (s2 == false)
            {
                other.gameObject.transform.position = spot[1].position;
                other.gameObject.transform.rotation = spot[1].rotation;
                s2 = true;
            }
            else if (s3 == false)
            {
                other.gameObject.transform.position = spot[2].position;
                other.gameObject.transform.rotation = spot[2].rotation;
                s3 = true;
            }
            else if (s4 == false)
            {
                other.gameObject.transform.position = spot[3].position;
                other.gameObject.transform.rotation = spot[3].rotation;
                s4 = true;
            }
            else if (s5 == false)
            {
                other.gameObject.transform.position = spot[3].position;
                other.gameObject.transform.rotation = spot[3].rotation;
                s4 = true;
            }
            //else if (s5 == false)
            //{
            //    other.gameObject.transform.position = spot[4].position;
            //    other.gameObject.transform.rotation = spot[4].rotation;
            //    s4 = true;
            //}
            //else if (countCount == 6)
            //    BuildingCount = 3;

            //else if (countCount <= 8)
            //    BuildingCount = 4;

            //countCount++;
            //print(countCount);

            //other.gameObject.transform.position = spot[BuildingCount].position;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //if (other.gameObject.tag == "Structure2")
        //{
        //    if (countCount == 3)
        //        BuildingCount = 1;

        //    else if (countCount == 4)
        //        BuildingCount = 2;

        //    else if (countCount == 6)
        //        BuildingCount = 3;

        //    else if (countCount <= 8)
        //        BuildingCount = 4;

        //    //Destroy(other.gameObject);
        //    //BoxCollider bc = other.gameObject.GetComponent<BoxCollider>();
        //    //bc.enabled = false;

        //    other.gameObject.transform.position = spot[BuildingCount].position;
        //}
    }
}
