using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryPack : MonoBehaviour
{
    public string StoryName;
    public string StoryContent;

    public string buildings1_Write;
    public string buildings2_Write;
    public string buildings3_Write;
    public string buildings4_Write;
    public string buildings5_Write;

    public Text sstoryName;
    public Text t1;
    public Text t2;
    public Text t3;
    public Text t4;
    public Text t5;

    public void ShowInfo()
    {
        sstoryName.text = StoryName;
        t1.text = buildings1_Write;
        t2.text = buildings2_Write;
        t3.text = buildings3_Write;
        t4.text = buildings4_Write;
        t5.text = buildings5_Write;
    }
}
