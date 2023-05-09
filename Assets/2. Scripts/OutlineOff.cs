using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineOff : MonoBehaviour
{
    void LateUpdate()
    {
        if(OnMouseMouse.Instance.mouseInfo.transform.gameObject.tag != "Tree")
        {
            Outline oll = GetComponent<Outline>();
            oll.enabled = false;
        }
        else if(OnMouseMouse.Instance.mouseInfo.transform == null)
        {
            print("soe");
        }
    }


}
