using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _StoryInput : MonoBehaviour
{
    public Text trip1;
    public Text trip2;
    public Text trip3;
    public Text trip4;
    public Text trip5;

    public WriteBuildings wb;
    public _BuildingSearch bs;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoGoGo()
    {
        wb = GameObject.Find("WriteStorySet").GetComponent<WriteBuildings>();
        bs = GameObject.Find("WriteStorySet").GetComponent<_BuildingSearch>();

        wb.buildings1 = trip1.text;
        wb.buildings2 = trip2.text;
        wb.buildings3 = trip3.text;
        wb.buildings4 = trip4.text;
        wb.buildings5 = trip5.text;

        wb.StoryHearts();
        bs.LineRedererCon();

        LinkBtn lb = GameObject.Find("ButtonManager").GetComponent<LinkBtn>();
        lb.LinkPanelOff();
    }
}
