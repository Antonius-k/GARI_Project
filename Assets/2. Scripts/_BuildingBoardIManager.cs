using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _BuildingBoardIManager : MonoBehaviour
{
    BuildManager bmm;

    // Start is called before the first frame update
    void Start()
    {
        bmm = GetComponent<BuildManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void CYM_InsertQuerry()
    {
        string query =
            string.Format("INSERT INTO BuildingBoardInfo VALUES(0, '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", bmm.TypeTxt.text, bmm.NameTxt.text, "睡骯惜羲衛", bmm.Adress2Txt_On.text, bmm.l3_d.captionText.text, bmm.Adress4Txt.text, bmm.PriceTxt.text, bmm.KeywordTxt.text);
        DBManager.Execute(query);
    }

    public void CYM_OnClickLoad()
    {
        //print();

        var result = DBManager.Select("SELECT *" + "FROM BuildingBoardInfo");
        foreach (var dict in result)
        {
            foreach (var row in dict)
            {
                print(row.Key + ": " + row.Value);
            }
            print("天天天天天天天");
        }
    }
}
