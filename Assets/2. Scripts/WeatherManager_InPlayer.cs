using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System.IO;

public class WeatherManager_InPlayer : MonoBehaviour
{
    public string LocalNameVal;
    public int LocalXval;
    public int LocalYval;

    public int skyCode;

    public GameObject Rain;
    public GameObject Snow;

    public GameObject ClearImg;
    public GameObject RainImg;
    public GameObject SnowImg;
    //public GameObject dust;

    public Text localName;
    public Text weatherTemp;
    public Text weatherInfo;
    public Text DateTxt;
    public Text TimeTxt;

    public Text weatherWeek;
    public GameObject WeekPanel;

    string jsonResult;
    string jsonResult2;
    bool isOnLoading = true;

    string yy = System.DateTime.Now.ToString("yyyy");
    string mm = System.DateTime.Now.ToString("MM");
    string dd = System.DateTime.Now.ToString("dd");
    string hh = System.DateTime.Now.ToString("HH");
    string mmm;
    string ddddd;

    AudioSet ause;

    // Start is called before the first frame update
    void Start()
    {
        ause = GameObject.Find("AudioSet").GetComponent<AudioSet>();
    }

    // Update is called once per frame
    void Update()
    {
        string mmm = System.DateTime.Now.ToString("mm");

        DateTxt.text = $"{yy}년 {mm}월 {dd}일";
        TimeTxt.text = $"{hh} : {mmm}";

        //if(Input.GetKeyDown(KeyCode.U))
        //{
        //    skyCode = 1;

        //    weatherInfo.text = "비";

        //    Rain.SetActive(true);
        //    Snow.SetActive(false);

        //    ClearImg.SetActive(false);
        //    RainImg.SetActive(true);
        //    SnowImg.SetActive(false);
        //}
        if (Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.U))
        {
            skyCode = 3;

            weatherInfo.text = "눈";

            Rain.SetActive(false);
            Snow.SetActive(true);

            ClearImg.SetActive(false);
            RainImg.SetActive(false);
            SnowImg.SetActive(true);

            ause.SnowWT();

        }
    }

    public void EntranceLocal()
    {
        localName.text = LocalNameVal;
        StartCoroutine(LoadData());
    }

    IEnumerator LoadData() //json 문자열 받아오기
    {
        int hhh = int.Parse(hh) - 1;
        string hhhh = hhh.ToString("D2");

        string GetDataUrl = "http://apis.data.go.kr/1360000/VilageFcstInfoService_2.0/getVilageFcst?serviceKey=rvVjg30DQYR25qnN8zM%2Buq2m4OBtOi6%2BuLZJRzyvyxClcgmjVBx8byFspchg%2BvrIVtqZOvbjSNwiUuCR4IW0dA%3D%3D&numOfRows=10&dataType=JSON&pageNo=1&base_date=" + yy + mm + dd + "&base_time=" + "0500&nx=" + LocalXval + "&ny=" + LocalYval;
        //GetDataUrl = JsonUtility.FromJson<>
        using (UnityWebRequest www = UnityWebRequest.Get(GetDataUrl))
        {
            //www.chunkedTransfer = false;
            yield return www.Send();
            if (www.isNetworkError || www.isHttpError) //불러오기 실패 시
            {
                Debug.Log(www.error);
            }
            else
            {
                if (www.isDone)
                {
                    isOnLoading = false;
                    jsonResult = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);

                    string aa = jsonResult.ToString();
                    string bb = aa.Substring(aa.IndexOf("TMP"));
                    string cc = bb.Substring(bb.IndexOf("lue\":\"") + 6);
                    string dd = cc.Substring(0, cc.IndexOf("\",\""));
                    //string[] split_aa = bb.Split(",");

                    string ee = aa.Substring(aa.IndexOf("PTY"));
                    string ff = ee.Substring(ee.IndexOf("lue\":\"") + 6);
                    string gg = ff.Substring(0, ff.IndexOf("\",\""));

                    skyCode = int.Parse(gg);

                    if (skyCode == 0)
                    {
                        weatherInfo.text = "맑음";

                        Rain.SetActive(false);
                        Snow.SetActive(false);

                        ClearImg.SetActive(true);
                        RainImg.SetActive(false);
                        SnowImg.SetActive(false);

                        ause.ClearWT();
                    }
                    else if (skyCode == 1 || skyCode == 2 || skyCode == 4 || skyCode == 5 || skyCode == 6)
                    {
                        weatherInfo.text = "비";

                        Rain.SetActive(true);
                        Snow.SetActive(false);

                        ClearImg.SetActive(false);
                        RainImg.SetActive(true);
                        SnowImg.SetActive(false);

                        ause.RainWT();
                    }
                    else if (skyCode == 3 || skyCode == 7)
                    {
                        weatherInfo.text = "눈";

                        Rain.SetActive(false);
                        Snow.SetActive(true);

                        ClearImg.SetActive(false);
                        RainImg.SetActive(false);
                        SnowImg.SetActive(true);

                        ause.SnowWT();
                    }

                    weatherTemp.text = dd + "도";


                    //string aa = jsonResult.ToString();
                    //string[] split_aa = aa.Split(",");
                    //print(split_aa[2]);
                }
            }

            www.Dispose();
        }

    }

    public void WeekWeatherSearch()
    {
        StartCoroutine(LoadWeekData());
    }

    IEnumerator LoadWeekData() //json 문자열 받아오기
    {
        int ddd = int.Parse(dd) - 1;
        string dddd = ddd.ToString("D2");

        string GetDataUrl = "https://apis.data.go.kr/1360000/MidFcstInfoService/getMidFcst?serviceKey=rvVjg30DQYR25qnN8zM%2Buq2m4OBtOi6%2BuLZJRzyvyxClcgmjVBx8byFspchg%2BvrIVtqZOvbjSNwiUuCR4IW0dA%3D%3D&pageNo=1&numOfRows=10&dataType=JSON&stnId=108&tmFc=" + yy + mm + dd + "0600";
        //GetDataUrl = JsonUtility.FromJson<>
        using (UnityWebRequest www = UnityWebRequest.Get(GetDataUrl))
        {
            //www.chunkedTransfer = false;
            yield return www.Send();
            if (www.isNetworkError || www.isHttpError) //불러오기 실패 시
            {
                Debug.Log(www.error);
            }
            else
            {
                if (www.isDone)
                {
                    isOnLoading = false;
                    jsonResult2 = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);

                    string aaa = jsonResult2.ToString();
                    string bbb = aaa.Substring(aaa.IndexOf("wfSv") + 7);
                    string ccc = bbb.Substring(0, bbb.IndexOf("\"}]"));

                    ddddd = ccc.Replace("\\n", "\n" + "\n");

                    StartCoroutine(WeekWeatherNotice());
                }
            }

            www.Dispose();
        }

    }

    IEnumerator WeekWeatherNotice()
    {
        weatherWeek.text = ddddd;
        WeekPanel.SetActive(true);

        yield return new WaitForSeconds(6.0f);

        WeekPanel.SetActive(false);
    }
}
