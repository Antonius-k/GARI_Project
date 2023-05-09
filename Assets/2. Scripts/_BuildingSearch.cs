using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _BuildingSearch : MonoBehaviour
{
    public DetailedInformation[] buildings;
    //public InputField buildingName;

    public GameObject minimapCam;

    LineRenderer lr;
    public WriteBuildings wb;

    GameObject b1;
    GameObject b2;
    GameObject b3;
    GameObject b4;
    GameObject b5;

    public Material lineColor;

    private void Start()
    {
        //wb = GetComponent<WriteBuildings>();
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Y))
        //    //print(wb.buildings1);
        //    LineRedererCon();
    }

    public void LineRedererCon()
    {
        buildings = GameObject.FindObjectsOfType<DetailedInformation>();

        lr = minimapCam.AddComponent<LineRenderer>();
        lr.startWidth = 2f;
        lr.endWidth = 2f;
        lr.material = lineColor;

        for (int i = 0; i < buildings.Length; i++)
        {
            print("111111");
            if (buildings[i].BuildingName == wb.buildings1)
            {
                //Destroy(apple[i].transform.parent.gameObject);
                //buildings[i].HeartOn();
                b1 = buildings[i].gameObject;                
                lr.SetPosition(0, b1.transform.position + new Vector3(6000, 0, 0));                

                if (wb.buildings2 != "")
                {
                    for (int k = 0; k < buildings.Length; k++)
                    {
                        if (buildings[k].BuildingName == wb.buildings2)
                        {
                            //buildings[i].HeartOn();
                            b2 = buildings[k].gameObject;
                            
                            lr.SetPosition(1, b2.transform.position + new Vector3(6000, 0, 0));

                            if (wb.buildings3 != "")
                            {
                                for (int j = 0; j < buildings.Length; j++)
                                {
                                    if (buildings[j].BuildingName == wb.buildings3)
                                    {
                                        //buildings[i].HeartOn();
                                        b3 = buildings[j].gameObject;

                                        lr.positionCount += 1;

                                        lr.SetPosition(2, b3.transform.position + new Vector3(6000, 0, 0));

                                        if (wb.buildings4 != "")
                                        {
                                            for (int l = 0; l < buildings.Length; l++)
                                            {
                                                if (buildings[l].BuildingName == wb.buildings4)
                                                {
                                                    //buildings[i].HeartOn();
                                                    b4 = buildings[l].gameObject;

                                                    lr.positionCount += 1;
                                                    lr.SetPosition(3, b4.transform.position + new Vector3(6000, 0, 0));

                                                    if (wb.buildings5 != "")
                                                    {
                                                        for (int h = 0; h < buildings.Length; h++)
                                                        {
                                                            if (buildings[h].BuildingName == wb.buildings5)
                                                            {
                                                                //buildings[i].HeartOn();
                                                                b5 = buildings[h].gameObject;

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

        

        //if (wb.buildings3 != "")
        //{
        //    for (int i = 0; i < buildings.Length; i++)
        //    {
        //        if (buildings[i].BuildingName == wb.buildings3)
        //        {
        //            //buildings[i].HeartOn();
        //            b3 = buildings[i].gameObject;

        //            lr.positionCount += 1;

        //            lr.SetPosition(0, b1.transform.position);
        //            lr.SetPosition(1, b2.transform.position);
        //            lr.SetPosition(2, b3.transform.position);

        //        }
        //    }
        //}

        //if (wb.buildings4 != "")
        //{
        //    for (int i = 0; i < buildings.Length; i++)
        //    {
        //        if (buildings[i].BuildingName == wb.buildings4)
        //        {
        //            //buildings[i].HeartOn();
        //            b4 = buildings[i].gameObject;

        //            lr.positionCount += 1;


        //            lr.SetPosition(0, b1.transform.position);
        //            lr.SetPosition(1, b2.transform.position);
        //            lr.SetPosition(2, b3.transform.position);
        //            lr.SetPosition(3, b4.transform.position);
        //        }
        //    }
        //}

        //if (wb.buildings5 != "")
        //{
        //    for (int i = 0; i < buildings.Length; i++)
        //    {
        //        if (buildings[i].BuildingName == wb.buildings5)
        //        {
        //            //buildings[i].HeartOn();
        //            b5 = buildings[i].gameObject;

        //            lr.SetPosition(0, b1.transform.position);
        //            lr.SetPosition(1, b2.transform.position);
        //            lr.SetPosition(2, b3.transform.position);
        //            lr.SetPosition(3, b4.transform.position);
        //            lr.SetPosition(4, b5.transform.position);
        //        }
        //    }
        //}
    }
}
