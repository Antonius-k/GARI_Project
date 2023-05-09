using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonTest1 : MonoBehaviour
{
    public Ray mouseRay;
    public RaycastHit mouseInfo;
    Outline1 oll;

    public GameObject StoryTxtPanel;

    private void Start()
    {
        oll = GetComponent<Outline1>();
    }

    void Update()
    {
        mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(mouseRay, out mouseInfo))
        {
            if (mouseInfo.transform.gameObject.tag == "Tree")
            {
                Outline1 ol = mouseInfo.transform.gameObject.GetComponent<Outline1>();
                ol.enabled = true;

                if(Input.GetButton("Fire1"))
                {
                    StoryTxtPanel.SetActive(true);
                    PlayerMove.Instance.canMove = false;
                }
            }  
            else
            {
                oll.enabled = false;
            }
        }
    }
}
