using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMMM : MonoBehaviour
{
    Ray mouseRay;
    RaycastHit mouseInfo;
    Outline ol;

    void Update()
    {
        mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(mouseRay, out mouseInfo))
        {            
            if (mouseInfo.transform.gameObject == this.gameObject)
            {
                print("okay");
                //ol = mouseInfo.transform.gameObject.GetComponent<Outline>();
                //ol.enabled = true;
                ////print("³ª¹«");
                //if (mouseInfo.transform.gameObject.tag != "Tree")
                //{
                //    ol.enabled = false;
                //}
            }

            //else if (mouseInfo.transform.gameObject.tag != "Tree")
            //{
            //    ol.enabled = false;
            //}
        }
    }
}
