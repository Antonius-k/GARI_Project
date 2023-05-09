using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;
using UnityEngine.UI;

public class NetworkTime : MonoBehaviour
{
    public string url = "";
    public Text timeText;

    void Update()
    {
        StartCoroutine(WebChk());
    }

    IEnumerator WebChk()
    {
        UnityWebRequest request = new UnityWebRequest();
        using (request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();

            if(request.isNetworkError)
            {
                Debug.Log(request.error);
            }
            else
            {
                string date = request.GetResponseHeader("date");

                DateTime dateTime = DateTime.Parse(date).ToUniversalTime();
                timeText.text = dateTime.ToString();
            }
        }
    }
}
