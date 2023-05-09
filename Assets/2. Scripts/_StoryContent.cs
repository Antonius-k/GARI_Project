using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _StoryContent : MonoBehaviourPun
{
    public string sc_name;
    public string sc_content;
    public string sc_Trip1;
    public string sc_Trip2;
    public string sc_Trip3;
    public string sc_Trip4;
    public string sc_Trip5;
    public string sc_Template;

    public Image Template_Img;
    public Sprite[] template_Set;

    public Text Txt_name;
    public Text Txt_trip1;
    public Text Txt_trip2;
    public Text Txt_trip3;
    public Text Txt_trip4;
    public Text Txt_trip5;

    public GameObject minimapCam;
    public Material lineColor;

    public GameObject AllPack;
    public GameObject lastPack;
    public Text lp_name;
    public Text lp_content;

    public float yValue = -900;

    DetailedInformation[] buildings;
    LineRenderer lr;

    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
            print("master");
        else
            print("NoMaster");
        photonView.RequestOwnership();
    }

    // Update is called once per frame
    void Update()
    {
        Txt_name.text = sc_name;
        Txt_trip1.text = sc_Trip1;
        Txt_trip2.text = sc_Trip2;
        Txt_trip3.text = sc_Trip3;
        Txt_trip4.text = sc_Trip4;
        Txt_trip5.text = sc_Trip5;

        if (sc_Template == "초록한느낌")
        {
            Template_Img.sprite = template_Set[0];
        }
        else if (sc_Template == "여름이다아")
        {
            Template_Img.sprite = template_Set[1];
        }
        else if (sc_Template == "크리스마스")
        {
            Template_Img.sprite = template_Set[2];
        }
        else if (sc_Template == "없음" || sc_Template == "")
        {
            Template_Img.sprite = template_Set[3];
        }
        else if (sc_Template == "꽃")
        {
            Template_Img.sprite = template_Set[4];
        }
        else if (sc_Template == "다크")
        {
            Template_Img.sprite = template_Set[5];
        }
        else if (sc_Template == "치킨이닭")
        {
            Template_Img.sprite = template_Set[6];
        }
    }

    public void StoryHearts()
    {
        buildings = GameObject.FindObjectsOfType<DetailedInformation>();

        if (sc_Trip1 != "")
        {
            for (int i = 0; i < buildings.Length; i++)
            {
                if (buildings[i].BuildingName == sc_Trip1)
                {
                    buildings[i].HeartOn();
                }
            }
        }

        if (sc_Trip2 != "")
        {
            for (int i = 0; i < buildings.Length; i++)
            {
                if (buildings[i].BuildingName == sc_Trip2)
                {
                    buildings[i].HeartOn();
                }
            }
        }

        if (sc_Trip3 != "")
        {
            for (int i = 0; i < buildings.Length; i++)
            {
                if (buildings[i].BuildingName == sc_Trip3)
                {
                    buildings[i].HeartOn();
                }
            }
        }

        if (sc_Trip4 != "")
        {
            for (int i = 0; i < buildings.Length; i++)
            {
                if (buildings[i].BuildingName == sc_Trip4)
                {
                    buildings[i].HeartOn();
                }
            }
        }

        if (sc_Trip5 != "")
        {
            for (int i = 0; i < buildings.Length; i++)
            {
                if (buildings[i].BuildingName == sc_Trip5)
                {
                    buildings[i].HeartOn();
                }
            }
        }

        RenRen();
        CallLastPack();
    }

    public void RenRen()
    {
        buildings = GameObject.FindObjectsOfType<DetailedInformation>();

        lr = minimapCam.AddComponent<LineRenderer>();
        lr.startWidth = 2f;
        lr.endWidth = 2f;
        lr.material = lineColor;

        for (int i = 0; i < buildings.Length; i++)
        {
            print("111111");
            if (buildings[i].BuildingName == sc_Trip1)
            {
                //Destroy(apple[i].transform.parent.gameObject);
                //buildings[i].HeartOn();
                GameObject b1 = buildings[i].gameObject;
                lr.SetPosition(0, b1.transform.position + new Vector3(6000, 0, 0));
                print("2222");

                if (sc_Trip2 != "")
                {
                    for (int k = 0; k < buildings.Length; k++)
                    {
                        if (buildings[k].BuildingName == sc_Trip2)
                        {
                            //buildings[i].HeartOn();
                            GameObject b2 = buildings[k].gameObject;
                            lr.SetPosition(1, b2.transform.position + new Vector3(6000, 0, 0));

                            if (sc_Trip3 != "")
                            {
                                for (int j = 0; j < buildings.Length; j++)
                                {
                                    if (buildings[j].BuildingName == sc_Trip3)
                                    {
                                        //buildings[i].HeartOn();
                                        GameObject b3 = buildings[j].gameObject;

                                        lr.positionCount += 1;

                                        lr.SetPosition(2, b3.transform.position + new Vector3(6000, 0, 0));

                                        if (sc_Trip4 != "")
                                        {
                                            for (int l = 0; l < buildings.Length; l++)
                                            {
                                                if (buildings[l].BuildingName == sc_Trip4)
                                                {
                                                    //buildings[i].HeartOn();
                                                    GameObject b4 = buildings[l].gameObject;

                                                    lr.positionCount += 1;
                                                    lr.SetPosition(3, b4.transform.position + new Vector3(6000, 0, 0));

                                                    if (sc_Trip5 != "")
                                                    {
                                                        for (int h = 0; h < buildings.Length; h++)
                                                        {
                                                            if (buildings[h].BuildingName == sc_Trip5)
                                                            {
                                                                //buildings[i].HeartOn();
                                                                GameObject b5 = buildings[h].gameObject;

                                                                lr.positionCount += 1;

                                                                lr.SetPosition(4, b5.transform.position + new Vector3(6000, 0, 0));

                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    public void CallLastPack()
    {
        lastPack.SetActive(true);
        lp_name.text = sc_name;
        lp_content.text = sc_content;
    }

    public void OffLastPack()
    {
        lastPack.SetActive(false);
        AllPack.SetActive(false);
    }
}
