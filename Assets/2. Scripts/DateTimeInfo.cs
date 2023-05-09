using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DateTimeInfo : MonoBehaviour
{
    public Text DateTxt;
    public Text TimeTxt;

    void Start()
    {
        
    }

    void Update()
    {
        string yy = System.DateTime.Now.ToString("yyyy");
        string mm = System.DateTime.Now.ToString("MM");
        string dd = System.DateTime.Now.ToString("dd");

        string hhh = System.DateTime.Now.ToString("HH");
        string mmm = System.DateTime.Now.ToString("mm");

        DateTxt.text = $"{yy}³â {mm}¿ù {dd}ÀÏ";
        TimeTxt.text = $"{hhh} : {mmm}";
    }
}
