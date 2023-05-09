using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseMouse : MonoBehaviour
{
    public static OnMouseMouse Instance;

    public Ray mouseRay;
    public RaycastHit mouseInfo;
    Outline ol;

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {        
        mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);                       

        if(Physics.Raycast(mouseRay, out mouseInfo))
        {
            if (mouseInfo.transform.gameObject.tag == "Tree")
            {
                //ol = mouseInfo.transform.gameObject.GetComponent<Outline>();
                //ol.enabled = true;
                
                
            }
            
            //else if (mouseInfo.transform.gameObject.tag != "Tree")
            //{
            //    print("³ª¹«");
            //    //ol.enabled = false;
            //}

            //else if (mouseInfo.transform.gameObject.tag != "Tree")
            //{
            //    ol.enabled = false;
            //}
        }
    }
}
