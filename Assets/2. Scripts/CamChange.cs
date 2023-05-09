using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamChange : MonoBehaviour
{
    public bool canChange = false;
    public bool canChange2 = false;

    public GameObject teleportPanel;

    public Text localName;
    public Text spotName;

    public GameObject localPanel;
    public GameObject spotPanel;
    public GameObject spotPanel2;
    public GameObject spotPanel3;

    public PlayerMove PlayerCharacter;
    public GameObject el;

    CamRot cr;

    // Start is called before the first frame update
    void Start()
    {
        cr = GetComponent<CamRot>();
        PlayerCharacter = GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canChange == true)
        {
            if (transform.position.x > -850)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(-851, 54.4f, -2135.3f), Time.deltaTime);
                

            }

            else
            {
                cr.enabled = true;
                transform.rotation = Quaternion.Euler(4.3f, 7.5f, -2.4f);
            }
        }

        if (canChange2 == true)
        {
            if (transform.position.z > 0)
            {
                
                cr.enabled = true;

            }

            else
            {
                
                cr.enabled = false;
                transform.position = Vector3.Lerp(transform.position, new Vector3(-4.31f, 86.48f, 1684.66f), Time.deltaTime);
                transform.rotation = Quaternion.Euler(4.3f, 7.5f, -2.4f);
                
            }
        }
    }

    public void OkaySet()
    {
        if(localName.text == "경기도")
        {
            localName.text = "";
            spotName.text = "";
            localPanel.SetActive(true);
            spotPanel.SetActive(false);
            spotPanel2.SetActive(false);
            spotPanel3.SetActive(false);

            
            PlayerCharacter.canMove = false;
            PlayerCharacter.gameObject.transform.position = new Vector3(1000, 1000, 0);

            canChange2 = true;
            canChange = false;
            cr.enabled = false;
            teleportPanel.transform.localPosition = new Vector3(0, 1000, 0);
        }
        else if(localName.text == "제주특별자치도")
        {
            localName.text = "";
            spotName.text = "";
            localPanel.SetActive(true);
            spotPanel.SetActive(false);
            spotPanel2.SetActive(false);
            spotPanel3.SetActive(false);

            canChange = true;
            canChange2 = false;
            teleportPanel.transform.localPosition = new Vector3(0, 1000, 0);
        }
        else
        {
            localName.text = "";
            spotName.text = "";
            localPanel.SetActive(true);
            spotPanel.SetActive(false);
            spotPanel2.SetActive(false);
            spotPanel3.SetActive(false);
        }
    }
}
