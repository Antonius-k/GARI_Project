using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetailedInformation : MonoBehaviour
{
    public string BuildingType;
    public string BuildingName;
    public string BuildingKeyword;
    public string BuildingPrice;
    public string Adrees1;
    public string Adrees2;
    public string Adrees3;
    public string Adrees4;
    public Texture SiteImage;

    //public GameObject Canvas;
    //public GameObject MotherBuilding;
    public GameObject bang;
    public GameObject heart;

    public GameObject InfoNotice;
    public Text InfoNotice_Type;
    public Text InfoNotice_Name;
    public Text InfoNotice_Keyword;
    public Text InfoNotice_Price;
    public Text InfoNotice_Adress1;
    public Text InfoNotice_Adress2;
    public Text InfoNotice_Adress3;
    public Text InfoNotice_Adress4;
    public RawImage InfoNotice_Texture;


    //==========
    //누나꺼 건물 좋아요 기능
    //건물 하위에 DetailedInformation/Canva/PreferNotice
    //건물마다 perfetNotice가 있어야 좋아요 됨
    //디비에도 좋아요 싫어요 붙여서 연동해서 올려줘야됨! 
    [Header("YJ")]
    public GameObject preferNotice;
    public int loveCount;
    public Text loveCountTxt;
    public int dislikeCount;
    public Text dislikeCountTxt;

    private void Start()
    {
        //preferNotice = transform.GetChild(0).Find("PreferNotice").gameObject;

    }

    //public InputField nameTxt;
    //public Text typeTxt;   
    //public Text keywordTxt;   

    //public void BuildPermission()
    //{
    //    if (nameTxt.text != "" && keywordTxt.text != "")
    //    {
    //        BuildingName = nameTxt.text;
    //        BuildingType = typeTxt.text;
    //        BuildingKeyword = keywordTxt.text;

    //        //Destroy(Canvas);
    //        Canvas.SetActive(false);
    //    }
    //}

    //public void BuildCancel()
    //{
    //    Destroy(MotherBuilding);
    //}

    public void Bang()
    {
        bang.SetActive(true);
    }

    public void BangOff()
    {
        bang.SetActive(false);
    }

    public void HeartOn()
    {
        heart.SetActive(true);
    }

    public void HeartOff()
    {
        heart.SetActive(false);
    }

    //public void didi()
    //{
    //    StartCoroutine(NoticeNotice());
    //}

    //IEnumerator NoticeNotice()
    //{
    //    InfoNotice.SetActive(true);

    //    InfoNotice_Type.text = BuildingType;
    //    InfoNotice_Name.text = BuildingName;
    //    InfoNotice_Keyword.text = BuildingKeyword;
    //    InfoNotice_Price.text = BuildingPrice;
    //    InfoNotice_Adress1.text = Adrees1;
    //    InfoNotice_Adress2.text = Adrees2;
    //    InfoNotice_Adress3.text = Adrees3;
    //    InfoNotice_Adress4.text = Adrees4;
    //    InfoNotice_Texture.texture = SiteImage;


    //yield return new WaitForSeconds(4.0f);

    //    InfoNotice.SetActive(false);
    //}
}
