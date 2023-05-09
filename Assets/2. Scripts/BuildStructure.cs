using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[System.Serializable]
//public class Craft
//{
//    public string craftName;
//    public GameObject go_Prefab;
//    public GameObject go_PreviewPrefab;
//}

public class BuildStructure : MonoBehaviour
{
    //[SerializeField]
    //private Craft[] craft_park;

    //private GameObject go_Preview;

    public GameObject buildPanel;
    public GameObject[] structure_Possible;
    public GameObject[] structure_Impossible;
    public GameObject[] structure_Build;
    public Transform Player;
    public GameObject buildBtnPanel;

    GameObject structure;
    bool StrucMov = false;
    int structureSet;

    void Start()
    {
        
    }

    void Update()
    {
        if(StrucMov == true)
        {
            structure.transform.position = Player.transform.position + Player.forward * 5;
            buildBtnPanel.SetActive(true);

            
        }
    }

    public void BuildBtnYes()
    {
        if(structureSet == 0)
        {

        }

        else if (structureSet == 1)
        {
            GameObject sb = Instantiate(structure_Build[1]);
            sb.transform.position = structure.transform.position;

            Destroy(structure);
        }
    }

    public void BuildBtnNo()
    {

    }

    public void BuildPanelOpen()
    {
        buildPanel.SetActive(true);
    }

    public void BuildBtn1()
    {
        structure = Instantiate(structure_Possible[0]);
        buildPanel.transform.localPosition = new Vector3(334, 500, 0);

        StrucMov = true;
        structureSet = 0;
    }

    public void BuildBtn2()
    {
        structure = Instantiate(structure_Possible[1]);
        buildPanel.transform.localPosition = new Vector3(334, 500, 0);
        //structure.transform.position = Player.transform.position + Player.forward * 8;

        StrucMov = true;
        structureSet = 1;
    }

    public void BuildBtn3()
    {
        structure = Instantiate(structure_Possible[2]);
        buildPanel.transform.localPosition = new Vector3(334, 500, 0);
        structure.transform.position = Player.transform.position + Player.forward * 3;
    }

    public void BuildBtn4()
    {
        structure = Instantiate(structure_Possible[3]);
        buildPanel.transform.localPosition = new Vector3(334, 500, 0);
        structure.transform.position = Player.transform.position + Player.forward * 3;
    }
}
