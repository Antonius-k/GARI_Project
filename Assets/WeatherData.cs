using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WeatherData : MonoBehaviour
{
    string jsonResult;
    bool isOnLoading = true;

    void Start()
    {
        StartCoroutine(LoadData());
    }


    IEnumerator LoadData() //json 문자열 받아오기
    {
        string GetDataUrl = "http://apis.data.go.kr/1360000/MidFcstInfoService/getMidFcst?serviceKey=rvVjg30DQYR25qnN8zM%2Buq2m4OBtOi6%2BuLZJRzyvyxClcgmjVBx8byFspchg%2BvrIVtqZOvbjSNwiUuCR4IW0dA%3D%3D&numOfRows=10&pageNo=1&stnId=133&tmFc=202211080600&_returnType=json";
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
                    Debug.Log(jsonResult);
                }
            }
            www.Dispose();
        }

    }

}