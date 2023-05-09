using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _PlusBookPage : MonoBehaviour
{
    public Book page;

    public Sprite se1;
    public Sprite se2;
    public Sprite se3;

    // Start is called before the first frame update
    void Start()
    {
        page = GetComponent<Book>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.P))
        //{
        //    print("p press");

        //    //page.bookPages = new Sprite[3];

        //    //page.bookPages[0] = se1;
        //    //page.bookPages[0] = se2;
        //    //page.bookPages[0] = se3;

        //    //var result = DBManager.Select("SELECT *" + "FROM boardinfo");
        //    //var result = DBManager.Select("SELECT *" + "FROM BuildingBoardInfo " + "WHERE BuildingBoardNum = 46");
        //    var result = DBManager.Select("SELECT *" + "FROM boardinfo " + "WHERE adress1 = 'ºÎ»ê±¤¿ª½Ã'");

        //    print(result.Count);

        //    print("p ok");
        //}
    }
}
