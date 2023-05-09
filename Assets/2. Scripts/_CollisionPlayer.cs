using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Photon.Pun;
using System.Text;

public class _CollisionPlayer : MonoBehaviourPun
{
    public GameObject InfoPanel;

    public Text cp_Name;
    public Text cp_Type;
    public Text cp_Keyword;
    public Text cp_Adress1;
    public Text cp_Adress2;
    public Text cp_Adress3;
    public Text cp_Adress4;
    public Text cp_Price;
    public Image cp_Img;

    string num = "0";
    int iNum = 0;

    //--------------------
    string path;
    string fileName;
    byte[] pic;
    Texture2D convertedTexture;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Structure")
        {
            

            if (photonView.IsMine)
            {
                num = other.gameObject.name;
                iNum = int.Parse(num);
                StopAllCoroutines();
                StartCoroutine(InfoNotice());
            }
            //foreach (var dict in result)
            //{
            //    foreach (var row in dict)
            //    {
            //        print(row.Key + ": " + row.Value);
            //    }
            //    print("ㅡㅡㅡㅡㅡㅡㅡ");
            //}
        }
    }

    public string WriteResult(string[] paths)
    {
        string result = "";
        if (paths.Length == 0)
        {
            return "";
        }
        foreach (string p in paths)
        {
            result += p + "\n";
        }
        return result;
    }

    string ConvertUtf8(string data)
    {
        byte[] source = Encoding.UTF8.GetBytes(data);
        return Encoding.UTF8.GetString(source);
    }

    IEnumerator InfoNotice()
    {
        InfoPanel.SetActive(true);
        var result = DBManager.Select("SELECT *" + "FROM BuildingBoardInfo");
        //SELECT * FROM BuildingBoardInfo where BuildingBoardNum = '46'
        var test = DBManager.Select("SELECT *" + "FROM BuildingBoardInfo " + "WHERE BuildingBoardNum = " + num);
        print(test);
        //print(test[0]["Name"] as string);

        cp_Name.text = ConvertUtf8(test[0]["Name"].ToString());
        cp_Type.text = ConvertUtf8(test[0]["Type"].ToString());
        cp_Adress1.text = ConvertUtf8(test[0]["Adress1"].ToString());
        cp_Adress2.text = ConvertUtf8(test[0]["Adress2"].ToString());
        cp_Adress3.text = ConvertUtf8(test[0]["Adress3"].ToString());
        cp_Adress4.text = ConvertUtf8(test[0]["Adress4"].ToString());
        cp_Price.text = ConvertUtf8(test[0]["Price"].ToString());
        cp_Keyword.text = ConvertUtf8(test[0]["Keyword"].ToString());

        //---------------------------

        cp_Img.overrideSprite = MediaProcessor.ToSprite(FTPManager.Download(num + ".png"));

        //UnityWebRequest www = UnityWebRequestTexture.GetTexture("file://" + path.Replace("\\", "/"));
        //yield return www.SendWebRequest();

        //if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
        //{
        //    Debug.Log(www.error);
        //}
        //else
        //{
        //    Texture myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
        //    convertedTexture = (Texture2D)myTexture;
        //    pic = convertedTexture.EncodeToPNG();

        //    fileName = path.Substring(path.LastIndexOf("\\") + 1);

        //    print(fileName);
        //    //사진 디비에 업데이트, 경로에 한글이름이 있으면 안올라가 짐
        //    FTPManager.Upload(pic, fileName);

        //    print(fileName);
        //    //사진 읽어오기
        //    cp_Img.overrideSprite = MediaProcessor.ToSprite(FTPManager.Download(num));

        //}
        //---------------------------

        

        yield return new WaitForSeconds(6.0f);

        InfoPanel.SetActive(false);
    }
}
