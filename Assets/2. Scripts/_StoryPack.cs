using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _StoryPack : MonoBehaviour
{
    public GameObject storyStoryAll;

    public GameObject storySet;
    public GameObject storyPack;
    public GameObject WritePack;
    public GameObject LastPack;
    
    public Text LastPackName;
    public Text LastPackContent;    

    public InputField nameName;
    public InputField content;
    public InputField Buildings1;
    public InputField Buildings2;
    public InputField Buildings3;
    public InputField Buildings4;
    public InputField Buildings5;

    public StoryPack sp;

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

    public void WritePackBtn()
    {
        storyPack.SetActive(true);

        //sp = storyPack.GetComponent<StoryPack>();
        
        sp.StoryName = nameName.text;
        sp.StoryContent = content.text;
        sp.buildings1_Write = Buildings1.text;
        sp.buildings2_Write = Buildings2.text;
        sp.buildings3_Write = Buildings3.text;
        sp.buildings4_Write = Buildings4.text;
        sp.buildings5_Write = Buildings5.text;

        WritePack.SetActive(false);

        sp.ShowInfo();
    }

    public void WritePackCancel()
    {
        storySet.SetActive(false);
        storyPack.SetActive(false);
        WritePack.SetActive(true);
    }

    public void GoBtn()
    {
        storySet.SetActive(false);
        storyPack.SetActive(false);
        WritePack.SetActive(true);

        LastPack.SetActive(true);
        LastPackName.text = sp.StoryName;
        LastPackContent.text = sp.StoryContent;
    }

    public void RealGo()
    {
        //LastPack.SetActive(false);

        wb.buildings1 = Buildings1.text;
        wb.buildings2 = Buildings2.text;
        wb.buildings3 = Buildings3.text;
        wb.buildings4 = Buildings4.text;
        wb.buildings5 = Buildings5.text;
        
        wb.StoryHearts();
        //bs.LineRedererCon();
    }

    public void RealCut()
    {
        storyPack.SetActive(true);
        WritePack.SetActive(false);
        LastPack.SetActive(false);

        bs.LineRedererCon();

        storyStoryAll.SetActive(false);
    }
}
