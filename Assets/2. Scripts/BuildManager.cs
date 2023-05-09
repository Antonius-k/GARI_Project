using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UnityEngine.Networking;
using UnityEditor;
using System.IO;
using UnityEngine.SceneManagement;
using SFB;

public class BuildManager : MonoBehaviourPun
{
    public static BuildManager Instance;

    public Dropdown buildType;
    public Dropdown local2_Busan;
    public Dropdown local3_kijang;
    public Dropdown local3_Namgu;
    public Dropdown local3_Dongrae;
    public Dropdown local3_Sasang;
    public Dropdown local3_Seogu;
    public Dropdown local3_Suyeong;
    public Dropdown local3_Yeonje;
    public Dropdown local3_Haeundae;

    public Text TypeTxt;
    public Text NameTxt;
    public Text Adress2Txt_On;
    public Text Adress4Txt;
    public Text PriceTxt;
    public Text KeywordTxt;

    public GameObject[] Local3;
    public Dropdown l3_d;

    public GameObject writePanel;

    Vector3 buildTransform;

    public int buildcount = 0;

    public Image image;

    string path;
    string fileName;
    byte[] pic;
    Texture2D convertedTexture;

    public _BuildNumber bn;

    private void Awake()
    {
        Instance = null;
    }

    public void BuildBtnClick()
    {
        if(local2_Busan.value == 1)
        {
            buildTransform = new Vector3(922.3f, 60, -328.4f);
        }
        else if(local2_Busan.value == 4)
        {
            buildTransform = new Vector3(882.1f, 60, -375);
        }
        else if (local2_Busan.value == 6)
        {
            buildTransform = new Vector3(868, 60, -353.3f);
        }
        else if (local2_Busan.value == 14)
        {
            buildTransform = new Vector3(877, 60, -390);
        }
        //------------------------ 기장군
        if (local3_kijang.gameObject.activeSelf == true)
        {
            if (local3_kijang.value == 0)
            {
                buildTransform = new Vector3(978.9f, 60, -340.57f);
            }
            else if (local3_kijang.value == 1)
            {
                buildTransform = new Vector3(984.13f, 60, -314.43f);
            }
            else if (local3_kijang.value == 2)
            {
                buildTransform = new Vector3(984.7f, 60, -303.4f);
            }
            else if (local3_kijang.value == 3)
            {
                buildTransform = new Vector3(871.3f, 60, -295f);
            }
            else if (local3_kijang.value == 4)
            {
                buildTransform = new Vector3(958.5f, 60, -307.5f);
            }
        }
        //------------------------ 남구
        else if (local3_Namgu.gameObject.activeSelf == true)
        {
            if (local3_Namgu.value == 0)
            {
                buildTransform = new Vector3(904.3f, 60, -385.4f);
            }
            else if (local3_Namgu.value == 1)
            {
                buildTransform = new Vector3(908.9f, 60, -380.1f);
            }
            else if (local3_Namgu.value == 2)
            {
                buildTransform = new Vector3(904.5f, 60, -369.3f);
            }
            else if (local3_Namgu.value == 3)
            {
                buildTransform = new Vector3(908f, 60, -394.23f);
            }
            else if (local3_Namgu.value == 4)
            {
                buildTransform = new Vector3(908f, 60, -394.23f);
            }
            else if (local3_Namgu.value == 5)
            {
                buildTransform = new Vector3(904.3f, 60, -385.4f);
            }
        }
        //--------------------------
        else if (local3_Dongrae.gameObject.activeSelf == true)
        {
            if (local3_Dongrae.value == 0)
            {
                buildTransform = new Vector3(921.84f, 60, -337f);
            }
            else if (local3_Dongrae.value == 1)
            {
                buildTransform = new Vector3(921.84f, 60, -337f);
            }
            else if (local3_Dongrae.value == 2)
            {
                buildTransform = new Vector3(921.84f, 60, -337f);
            }
            else if (local3_Dongrae.value == 3)
            {
                buildTransform = new Vector3(921.84f, 60, -337f);
            }
            else if (local3_Dongrae.value == 4)
            {
                buildTransform = new Vector3(911.7f, 60, -332.97f);
            }
            else if (local3_Dongrae.value == 5)
            {
                buildTransform = new Vector3(921.84f, 60, -337f);
            }
            else if (local3_Dongrae.value == 6)
            {
                buildTransform = new Vector3(921.84f, 60, -337f);
            }
            else if (local3_Dongrae.value == 7)
            {
                buildTransform = new Vector3(911.7f, 60, -332.97f);
            }
            else if (local3_Dongrae.value == 8)
            {
                buildTransform = new Vector3(921.84f, 60, -337f);
            }
        }
        //----------------------- 사상구
        else if (local3_Sasang.gameObject.activeSelf == true)
        {
            if (local3_Sasang.value == 0)
            {
                buildTransform = new Vector3(846.2f, 60, -358.7f);
            }
            else if (local3_Sasang.value == 1)
            {
                buildTransform = new Vector3(846.2f, 60, -353);
            }
            else if (local3_Sasang.value == 2)
            {
                buildTransform = new Vector3(846.2f, 60, -353);
            }
            else if (local3_Sasang.value == 3)
            {
                buildTransform = new Vector3(846.2f, 60, -345);
            }
            else if (local3_Sasang.value == 4)
            {
                buildTransform = new Vector3(846.2f, 60, -345f);
            }
            else if (local3_Sasang.value == 5)
            {
                buildTransform = new Vector3(846.2f, 60, -374.1f);
            }
            else if (local3_Sasang.value == 6)
            {
                buildTransform = new Vector3(861f, 60, -370);
            }
            else if (local3_Sasang.value == 1)
            {
                buildTransform = new Vector3(852.3f, 60, -370);
            }
        }
        // -------------------- 서구
        else if (local3_Seogu.gameObject.activeSelf == true)
        {
            if (local3_Seogu.value == 0)
            {
                buildTransform = new Vector3(859, 60, -402.6f);
            }
            else if (local3_Seogu.value == 1)
            {
                buildTransform = new Vector3(874, 60, -380.8f);
            }
            else if (local3_Seogu.value == 2)
            {
                buildTransform = new Vector3(874, 60, -380.8f);
            }
            else if (local3_Seogu.value == 3)
            {
                buildTransform = new Vector3(874, 60, -380.8f);
            }
            else if (local3_Seogu.value == 4)
            {
                buildTransform = new Vector3(865.5f, 60, -393.4f);
            }
            else if (local3_Seogu.value == 5)
            {
                buildTransform = new Vector3(865.5f, 60, -393.4f);
            }
            else if (local3_Seogu.value == 6)
            {
                buildTransform = new Vector3(865.5f, 60, -393.4f);
            }
            else if (local3_Seogu.value == 7)
            {
                buildTransform = new Vector3(865.5f, 60, -393.4f);
            }
            else if (local3_Seogu.value == 8)
            {
                buildTransform = new Vector3(865.5f, 60, -393.4f);
            }
            else if (local3_Seogu.value == 9)
            {
                buildTransform = new Vector3(865.5f, 60, -393.4f);
            }
            else if (local3_Seogu.value == 10)
            {
                buildTransform = new Vector3(865.5f, 60, -393.4f);
            }
            else if (local3_Seogu.value == 11)
            {
                buildTransform = new Vector3(865.4f, 60, -380.5f);
            }
            else if (local3_Seogu.value == 12)
            {
                buildTransform = new Vector3(859, 60, -402.6f);
            }
            else if (local3_Seogu.value == 13)
            {
                buildTransform = new Vector3(859, 60, -402.6f);
            }
            else if (local3_Seogu.value == 14)
            {
                buildTransform = new Vector3(860f, 60, -421f);
            }
            else if (local3_Seogu.value == 15)
            {
                buildTransform = new Vector3(865.5f, 60, -393.4f);
            }
            else if (local3_Seogu.value == 16)
            {
                buildTransform = new Vector3(865.5f, 60, -402f);
            }
            else if (local3_Seogu.value == 17)
            {
                buildTransform = new Vector3(865.5f, 60, -402f);
            }
            else if (local3_Seogu.value == 18)
            {
                buildTransform = new Vector3(865.5f, 60, -402f);
            }
        }
        // ------------------------- 수영구
        else if (local3_Suyeong.gameObject.activeSelf == true)
        {
            if (local3_Suyeong.value == 0)
            {
                buildTransform = new Vector3(926.6f, 60, -361.5f);
            }
            else if (local3_Suyeong.value == 1)
            {
                buildTransform = new Vector3(921.76f, 60, -367.5f);
            }
            else if (local3_Suyeong.value == 2)
            {
                buildTransform = new Vector3(914.7f, 60, -356.4f);
            }
            else if (local3_Suyeong.value == 3)
            {
                buildTransform = new Vector3(926.6f, 60, -361.5f);
            }
            else if (local3_Suyeong.value == 4)
            {
                buildTransform = new Vector3(926.6f, 60, -361.5f);
            }
        }
        //---------------- 연제구
        else if (local3_Yeonje.gameObject.activeSelf == true)
        {
            if (local3_Yeonje.value == 0)
            {
                buildTransform = new Vector3(910.5f, 60, -342);
            }
            else if (local3_Yeonje.value == 1)
            {
                buildTransform = new Vector3(917.5f, 60, -348);
            }
        }
        // ------------------ 해운대구
        else if (local3_Haeundae.gameObject.activeSelf == true)
        {
            if (local3_Haeundae.value == 0)
            {
                buildTransform = new Vector3(937, 60, -333);
            }
            else if (local3_Haeundae.value == 1)
            {
                buildTransform = new Vector3(937, 60, -340);
            }
            else if (local3_Haeundae.value == 2)
            {
                buildTransform = new Vector3(932, 60, -330.5f);
            }
            else if (local3_Haeundae.value == 3)
            {
                buildTransform = new Vector3(973, 60, -352);
            }
            else if (local3_Haeundae.value == 4)
            {
                buildTransform = new Vector3(946.5f, 60, -360);
            }
            else if (local3_Haeundae.value == 5)
            {
                buildTransform = new Vector3(935, 60, -345.7f);
            }
            else if (local3_Haeundae.value == 6)
            {
                buildTransform = new Vector3(964.3f, 60, -354);
            }
            else if (local3_Haeundae.value == 7)
            {
                buildTransform = new Vector3(964.3f, 60, -358.4f);
            }
        }

        //if(buildType.value == 0)
        //{
        //    for(int i = 0; i < Local3.Length; i++)
        //    {
        //        if(Local3[i].activeSelf == false)
        //        {
        //            //l3_d = Local3[i].GetComponent<Dropdown>();
        //            //print(i);
        //        }
        //        else
        //        {
        //            print(i);
        //            l3_d = Local3[i].GetComponent<Dropdown>();
        //        }
        //    }

        //    GameObject building = PhotonNetwork.Instantiate("CombinationBuilding", buildTransform, Quaternion.identity);
        //    building.name = 033.ToString();
        //    DetailedInformation dii = building.GetComponentInChildren<DetailedInformation>();
        //    dii.BuildingType = TypeTxt.text;
        //    dii.BuildingName = NameTxt.text;
        //    dii.Adrees1 = "부산광역시";
        //    dii.Adrees2 = Adress2Txt_On.text;
        //    dii.Adrees3 = l3_d.captionText.text;
        //    dii.Adrees4 = Adress4Txt.text;
        //    dii.BuildingPrice = PriceTxt.text;
        //    dii.BuildingKeyword = KeywordTxt.text;
        //}
        if (buildType.value == 0)
        {
            for (int i = 0; i < Local3.Length; i++)
            {
                if (Local3[i].activeSelf == false)
                {
                    //l3_d = Local3[i].GetComponent<Dropdown>();
                    //print(i);
                }
                else
                {
                    print(i);
                    l3_d = Local3[i].GetComponent<Dropdown>();
                }
            }

            GameObject building = PhotonNetwork.Instantiate("4_ConcertHall", buildTransform, Quaternion.identity);

            var test = DBManager.Select("SELECT *" + "FROM BuildingBoardInfo " + "ORDER BY BuildingBoardNum DESC LIMIT 1");
            string buildNumberInput = test[0]["BuildingBoardNum"].ToString();
            int bni = int.Parse(buildNumberInput) + 1;
            string bbni = bni.ToString();
            building.name = bbni;

            DetailedInformation dii = building.GetComponentInChildren<DetailedInformation>();
            dii.BuildingType = TypeTxt.text;
            dii.BuildingName = NameTxt.text;
            dii.Adrees1 = "부산광역시";
            dii.Adrees2 = Adress2Txt_On.text;
            dii.Adrees3 = l3_d.captionText.text;
            dii.Adrees4 = Adress4Txt.text;
            dii.BuildingPrice = PriceTxt.text;
            dii.BuildingKeyword = KeywordTxt.text;
        }
        else if (buildType.value == 1)
        {
            for (int i = 0; i < Local3.Length; i++)
            {
                if (Local3[i].activeSelf == false)
                {
                    //l3_d = Local3[i].GetComponent<Dropdown>();
                    //print(i);
                }
                else
                {
                    print(i);
                    l3_d = Local3[i].GetComponent<Dropdown>();
                }
            }

            GameObject building = PhotonNetwork.Instantiate("5_Park", buildTransform, Quaternion.identity);

            var test = DBManager.Select("SELECT *" + "FROM BuildingBoardInfo " + "ORDER BY BuildingBoardNum DESC LIMIT 1");
            string buildNumberInput = test[0]["BuildingBoardNum"].ToString();
            int bni = int.Parse(buildNumberInput) + 1;
            string bbni = bni.ToString();
            building.name = bbni;

            DetailedInformation dii = building.GetComponentInChildren<DetailedInformation>();
            dii.BuildingType = TypeTxt.text;
            dii.BuildingName = NameTxt.text;
            dii.Adrees1 = "부산광역시";
            dii.Adrees2 = Adress2Txt_On.text;
            dii.Adrees3 = l3_d.captionText.text;
            dii.Adrees4 = Adress4Txt.text;
            dii.BuildingPrice = PriceTxt.text;
            dii.BuildingKeyword = KeywordTxt.text;
        }
        else if (buildType.value == 2)
        {
            for (int i = 0; i < Local3.Length; i++)
            {
                if (Local3[i].activeSelf == false)
                {
                    //l3_d = Local3[i].GetComponent<Dropdown>();
                    //print(i);
                }
                else
                {
                    print(i);
                    l3_d = Local3[i].GetComponent<Dropdown>();
                }
            }

            GameObject building = PhotonNetwork.Instantiate("7_Beach", buildTransform, Quaternion.identity);

            var test = DBManager.Select("SELECT *" + "FROM BuildingBoardInfo " + "ORDER BY BuildingBoardNum DESC LIMIT 1");
            string buildNumberInput = test[0]["BuildingBoardNum"].ToString();
            int bni = int.Parse(buildNumberInput) + 1;
            string bbni = bni.ToString();
            building.name = bbni;

            DetailedInformation dii = building.GetComponentInChildren<DetailedInformation>();
            dii.BuildingType = TypeTxt.text;
            dii.BuildingName = NameTxt.text;
            dii.Adrees1 = "부산광역시";
            dii.Adrees2 = Adress2Txt_On.text;
            dii.Adrees3 = l3_d.captionText.text;
            dii.Adrees4 = Adress4Txt.text;
            dii.BuildingPrice = PriceTxt.text;
            dii.BuildingKeyword = KeywordTxt.text;
        }
        else if (buildType.value == 3)
        {
            for (int i = 0; i < Local3.Length; i++)
            {
                if (Local3[i].activeSelf == false)
                {
                    //l3_d = Local3[i].GetComponent<Dropdown>();
                    //print(i);
                }
                else
                {
                    print(i);
                    l3_d = Local3[i].GetComponent<Dropdown>();
                }
            }

            GameObject building = PhotonNetwork.Instantiate("3_Museum", buildTransform, Quaternion.identity);

            var test = DBManager.Select("SELECT *" + "FROM BuildingBoardInfo " + "ORDER BY BuildingBoardNum DESC LIMIT 1");
            string buildNumberInput = test[0]["BuildingBoardNum"].ToString();
            int bni = int.Parse(buildNumberInput) + 1;
            string bbni = bni.ToString();
            building.name = bbni;

            DetailedInformation dii = building.GetComponentInChildren<DetailedInformation>();
            dii.BuildingType = TypeTxt.text;
            dii.BuildingName = NameTxt.text;
            dii.Adrees1 = "부산광역시";
            dii.Adrees2 = Adress2Txt_On.text;
            dii.Adrees3 = l3_d.captionText.text;
            dii.Adrees4 = Adress4Txt.text;
            dii.BuildingPrice = PriceTxt.text;
            dii.BuildingKeyword = KeywordTxt.text;
        }
        else if (buildType.value == 4)
        {
            for (int i = 0; i < Local3.Length; i++)
            {
                if (Local3[i].activeSelf == false)
                {
                    //l3_d = Local3[i].GetComponent<Dropdown>();
                    //print(i);
                }
                else
                {
                    print(i);
                    l3_d = Local3[i].GetComponent<Dropdown>();
                }
            }

            GameObject building = PhotonNetwork.Instantiate("0_Restaurant", buildTransform, Quaternion.identity);

            var test = DBManager.Select("SELECT *" + "FROM BuildingBoardInfo " + "ORDER BY BuildingBoardNum DESC LIMIT 1");
            string buildNumberInput = test[0]["BuildingBoardNum"].ToString();
            int bni = int.Parse(buildNumberInput) + 1;
            string bbni = bni.ToString();
            building.name = bbni;

            //-----------
            //var result = DBManager.Select("SELECT *" + "FROM BuildingBoardInfo");
            //SELECT * FROM BuildingBoardInfo where BuildingBoardNum = '46'

            //print(test[0]["Name"] as string);

            //cp_Name.text = ConvertUtf8(test[0]["Name"].ToString());
            //cp_Type.text = ConvertUtf8(test[0]["Type"].ToString());
            //cp_Adress1.text = ConvertUtf8(test[0]["Adress1"].ToString());
            //cp_Adress2.text = ConvertUtf8(test[0]["Adress2"].ToString());
            //cp_Adress3.text = ConvertUtf8(test[0]["Adress3"].ToString());
            //cp_Adress4.text = ConvertUtf8(test[0]["Adress4"].ToString());
            //cp_Price.text = ConvertUtf8(test[0]["Price"].ToString());
            //cp_Keyword.text = ConvertUtf8(test[0]["Keyword"].ToString());
            //-------------------------------

            DetailedInformation dii = building.GetComponentInChildren<DetailedInformation>();
            dii.BuildingType = TypeTxt.text;
            dii.BuildingName = NameTxt.text;
            dii.Adrees1 = "부산광역시";
            dii.Adrees2 = Adress2Txt_On.text;
            dii.Adrees3 = l3_d.captionText.text;
            dii.Adrees4 = Adress4Txt.text;
            dii.BuildingPrice = PriceTxt.text;
            dii.BuildingKeyword = KeywordTxt.text;
        }
        //else if (buildType.value == 6)
        //{
        //    for (int i = 0; i < Local3.Length; i++)
        //    {
        //        if (Local3[i].activeSelf == false)
        //        {
        //            //l3_d = Local3[i].GetComponent<Dropdown>();
        //            //print(i);
        //        }
        //        else
        //        {
        //            print(i);
        //            l3_d = Local3[i].GetComponent<Dropdown>();
        //        }
        //    }

        //    GameObject building = PhotonNetwork.Instantiate("1_Cafe", buildTransform, Quaternion.identity);
        //    building.name = 033.ToString();
        //    DetailedInformation dii = building.GetComponentInChildren<DetailedInformation>();
        //    dii.BuildingType = TypeTxt.text;
        //    dii.BuildingName = NameTxt.text;
        //    dii.Adrees1 = "부산광역시";
        //    dii.Adrees2 = Adress2Txt_On.text;
        //    dii.Adrees3 = l3_d.captionText.text;
        //    dii.Adrees4 = Adress4Txt.text;
        //    dii.BuildingPrice = PriceTxt.text;
        //    dii.BuildingKeyword = KeywordTxt.text;
        //}
        else if (buildType.value == 5)
        {
            for (int i = 0; i < Local3.Length; i++)
            {
                if (Local3[i].activeSelf == false)
                {
                    //l3_d = Local3[i].GetComponent<Dropdown>();
                    //print(i);
                }
                else
                {
                    print(i);
                    l3_d = Local3[i].GetComponent<Dropdown>();
                }
            }

            GameObject building = PhotonNetwork.Instantiate("1_Cafe", buildTransform, Quaternion.identity);

            var test = DBManager.Select("SELECT *" + "FROM BuildingBoardInfo " + "ORDER BY BuildingBoardNum DESC LIMIT 1");
            string buildNumberInput = test[0]["BuildingBoardNum"].ToString();
            int bni = int.Parse(buildNumberInput) + 1;
            string bbni = bni.ToString();
            building.name = bbni;

            DetailedInformation dii = building.GetComponentInChildren<DetailedInformation>();
            dii.BuildingType = TypeTxt.text;
            dii.BuildingName = NameTxt.text;
            dii.Adrees1 = "부산광역시";
            dii.Adrees2 = Adress2Txt_On.text;
            dii.Adrees3 = l3_d.captionText.text;
            dii.Adrees4 = Adress4Txt.text;
            dii.BuildingPrice = PriceTxt.text;
            dii.BuildingKeyword = KeywordTxt.text;
        }
        else if (buildType.value == 6)
        {
            for (int i = 0; i < Local3.Length; i++)
            {
                if (Local3[i].activeSelf == false)
                {
                    //l3_d = Local3[i].GetComponent<Dropdown>();
                    //print(i);
                }
                else
                {
                    print(i);
                    l3_d = Local3[i].GetComponent<Dropdown>();
                }
            }

            GameObject building = PhotonNetwork.Instantiate("2_Hotel", buildTransform, Quaternion.identity);
           
            var test = DBManager.Select("SELECT *" + "FROM BuildingBoardInfo " + "ORDER BY BuildingBoardNum DESC LIMIT 1");
            string buildNumberInput = test[0]["BuildingBoardNum"].ToString();
            int bni = int.Parse(buildNumberInput) + 1;
            string bbni = bni.ToString();
            building.name = bbni;

            photonView.RPC("bnPlus", RpcTarget.All);

            DetailedInformation dii = building.GetComponentInChildren<DetailedInformation>();
            dii.BuildingType = TypeTxt.text;
            dii.BuildingName = NameTxt.text;
            dii.Adrees1 = "부산광역시";
            dii.Adrees2 = Adress2Txt_On.text;
            dii.Adrees3 = l3_d.captionText.text;
            dii.Adrees4 = Adress4Txt.text;
            dii.BuildingPrice = PriceTxt.text;
            dii.BuildingKeyword = KeywordTxt.text;
        }
        //else if (buildType.value == 9)
        //{
        //    for (int i = 0; i < Local3.Length; i++)
        //    {
        //        if (Local3[i].activeSelf == false)
        //        {
        //            //l3_d = Local3[i].GetComponent<Dropdown>();
        //            //print(i);
        //        }
        //        else
        //        {
        //            print(i);
        //            l3_d = Local3[i].GetComponent<Dropdown>();
        //        }
        //    }

        //    GameObject building = PhotonNetwork.Instantiate("1_Cafe", buildTransform, Quaternion.identity);
        //    building.name = 033.ToString();
        //    DetailedInformation dii = building.GetComponentInChildren<DetailedInformation>();
        //    dii.BuildingType = TypeTxt.text;
        //    dii.BuildingName = NameTxt.text;
        //    dii.Adrees1 = "부산광역시";
        //    dii.Adrees2 = Adress2Txt_On.text;
        //    dii.Adrees3 = l3_d.captionText.text;
        //    dii.Adrees4 = Adress4Txt.text;
        //    dii.BuildingPrice = PriceTxt.text;
        //    dii.BuildingKeyword = KeywordTxt.text;
        //}

        writePanel.SetActive(false);
    }

    public void WritePanelOn()
    {
        writePanel.SetActive(true);
    }

    public void WritePanelOff()
    {
        writePanel.SetActive(false);
    }

    private void Update()
    {
        if (buildcount == 2)
        {
            PhotonNetwork.Instantiate("CombinationBuilding", buildTransform, Quaternion.identity);
            buildcount = 0;
        }
    }

    //----------------------------------------------

    public string WriteResult(string[] paths)
    {
        string result = "";
        if (paths.Length == 0)
        {
            return "";
        }
        foreach (string p in paths)
        {
            result += p + "\n";
        }
        return result;
    }

    public void ImgSave()
    {
        path = WriteResult(StandaloneFileBrowser.OpenFilePanel("Open File", "", "", false));
        StartCoroutine(IESetImg());
    }

    //선택한 이미지(texture)를 byte[]형식으로 변환하여 pic 변수에 담아주는 함수
    //이미지를 byte[]형식으로 변환하는 이유??
    //=> byte[] 형식으로 변환해야 txt 파일에 쓸 수 있기 때문에
    IEnumerator IESetImg()
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture("file://" + path.Replace("\\", "/"));
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Texture myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            convertedTexture = (Texture2D)myTexture;
            pic = convertedTexture.EncodeToPNG();

            fileName = path.Substring(path.LastIndexOf("\\") + 1);

            print(fileName);
            //사진 디비에 업데이트, 경로에 한글이름이 있으면 안올라가 짐
            FTPManager.Upload(pic, fileName);

            print(fileName);
            //사진 읽어오기
            image.overrideSprite = MediaProcessor.ToSprite(FTPManager.Download(fileName));

        }
    }

    public void ImgLoad()
    {
        image.overrideSprite = MediaProcessor.ToSprite(FTPManager.Download(fileName));
    }    
}
