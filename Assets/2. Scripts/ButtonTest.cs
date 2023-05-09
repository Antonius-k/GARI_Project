using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonTest : MonoBehaviour
{
    public Ray mouseRay;
    public RaycastHit mouseInfo;
    Outline oll;

    public GameObject StoryTxtPanel;

    private void Start()
    {
        oll = GetComponent<Outline>();
    }

    void Update()
    {
        mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(mouseRay, out mouseInfo))
        {
            if (mouseInfo.transform.gameObject.tag == "Structure")
            {
                Outline ol = mouseInfo.transform.gameObject.GetComponent<Outline>();
                ol.enabled = true;

                if(Input.GetButton("Fire1"))
                {
                    StoryTxtPanel.SetActive(true);

                    WriteStory.Instance.WSN = mouseInfo.transform.gameObject.name;
                }
            }  
            else
            {
                oll.enabled = false;
            }
        }
    }
}
