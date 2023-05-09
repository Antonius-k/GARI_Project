using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEditor;
using System.IO;
using UnityEngine.SceneManagement;
using SFB;


//경기도, 강원도, 충청북도, 충청남도, 경상북도, 경상남도,
//전라북도, 전라남도, 제주특별자치도, 서울특별시, 인천광역시, 세종특별지치사,
//대전광역시, 대구광역시, 광주광역시, 울산광역시, 부산광역시
public class ImageManager2 : MonoBehaviour
{
    [Header("스토리")]
    //지역
    public InputField inputLabel;
    //스토리의 제목
    public InputField inputStoryTitleToLoad;
    //스토리의 내용
    public InputField inputDescription;
    //목적지
    public InputField[] inputDestination;
    //이미지
    public Image image;
    //지역구
    public Text adressText;

    [Header("테이블")]
    int boardId;
    string loginId = AccountManager.id;
    //지역 위치
    string label;
    string title = "titleTest";
    string description;
    string destination;
    //지역구
    string adress1;

    //텍스쳐 변환
    Texture2D convertedTexture;

    //boardId 뒤에 .jpg를 붙여준다.
    //이미지 파일 이름
    string fileName;

    //사진 올릴때
    byte[] pic;
    string imgPath = "";
    //string savepth = "";

    [Header("예명")]
    public Book page;
    public Text pageLeft;
    public Text pageRight;

    public int lPage = 0;
    public int rPage = 0;

    private void Update()
    {
        //if(page.UpdateBook())
        //{
        //    lPage = page.currentPage / 2;
        //    rPage = page.currentPage;

        //    var result = DBManager.Select("SELECT *" + "FROM boardinfo " + "WHERE adress1 =" + "'부산광역시'");
        //    //int resultLength = result.Count;
        //    //page.bookPages = new Sprite[resultLength];
        //    pageLeft.text = result[lPage]["title"] as string;
        //    pageRight.text = result[rPage]["title"] as string;
        //}
    }    

    public void OnClickBoardUploadButton()
    {
        loginId = AccountManager.id;
        title = inputStoryTitleToLoad.text;
        description = inputDescription.text;
        adress1 = adressText.text;

        for (int i = 0; i < inputDestination.Length; i++)
        {
            destination += inputDestination[i].text;
            destination += "/";
        }

        //데이터 디비에 저장
        InsertQuerry();
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


    //파일 탐색기에서 이미지 찾게 해주는 함수
    public void OnClickSetImg()
    {
        imgPath = WriteResult(StandaloneFileBrowser.OpenFilePanel("Open File", "", "", false));
        print(imgPath);
        StartCoroutine(IESetImg());
    }


    //선택한 이미지(texture)를 byte[]형식으로 변환하여 pic 변수에 담아주는 함수
    //이미지를 byte[]형식으로 변환하는 이유??
    //=> byte[] 형식으로 변환해야 txt 파일에 쓸 수 있기 때문에
    IEnumerator IESetImg()
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture("file://" + imgPath.Replace("\\", "/"));
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Texture myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            convertedTexture = (Texture2D)myTexture;
            pic = convertedTexture.EncodeToPNG();

            fileName = imgPath.Substring(imgPath.LastIndexOf("\\") + 1);

            print(fileName);
            //사진 디비에 업데이트, 경로에 한글이름이 있으면 안올라가 짐
            FTPManager.Upload(pic, fileName);

            //사진 읽어오기
            image.overrideSprite = MediaProcessor.ToSprite(FTPManager.Download(fileName));
        }
    }


    //boardinfo 테이블에 넣어주기
    public void InsertQuerry()
    {
        string query =
            string.Format("INSERT INTO boardinfo VALUES(0,'{0}','{1}','{2}','{3}','{4}','{5}')", loginId, title, description, destination, fileName, adress1);
        DBManager.Execute(query);

        print(fileName);
    }


    //byte[] to Texture2D 변환해주는 함수
    private Texture2D Base64ToTexture2D(byte[] imageData)
    {
        int width, height;
        GetImageSize(imageData, out width, out height);

        // 매프레임 new를 해줄경우 메모리 문제 발생 -> 멤버 변수로 변경
        Texture2D texture = new Texture2D(width, height, TextureFormat.ARGB32, false, true);

        texture.hideFlags = HideFlags.HideAndDontSave;
        texture.filterMode = FilterMode.Point;
        texture.LoadImage(imageData);
        texture.Apply();

        return texture;
    }


    public void ImageDownload()
    {
        byte[] image = FTPManager.Download("파일이름");
    }

    private void GetImageSize(byte[] imageData, out int width, out int height)
    {
        width = ReadInt(imageData, 3 + 15);
        height = ReadInt(imageData, 3 + 15 + 2 + 2);
    }


    private int ReadInt(byte[] imageData, int offset)
    {
        return (imageData[offset] << 8 | imageData[offset + 1]);
    }

    //===============================================
    [Header("지역별 스토리 불러오기")]

    //storySetsPrefab안에 넣어논다.
    public GameObject temp;
    public GameObject parentObject;
    public Text dropLocal1;
    public Image[] loadImagePath;


    //Stories2 지역별로 불러오기
    //SELECT * FROM boardinfo where Adress1 = '충청북도'
    public void OnClickAdressBoardList() // 승기형꺼
    {
        var result = DBManager.Select("SELECT *" + "FROM boardinfo " + "WHERE adress1 =" + "'" + dropLocal1.text + "'");

        foreach (var dict in result)
        {
            print("Count: " + dict.Count);

            temp = Instantiate(Resources.Load("StorySets") as GameObject);
            temp.transform.SetParent(parentObject.transform);

            Image image = temp.transform.Find("StoryArticle/Image").GetComponent<Image>();
            Text text = temp.transform.Find("StoryArticle/Text").GetComponent<Text>();

            text.text = dict["title"] as string;
            image.overrideSprite = MediaProcessor.ToSprite(FTPManager.Download(dict["ImgPath"] as string));

            foreach (var row in dict)
            {
                print(row.Key + ": " + row.Value);
            }
            print("ㅡㅡㅡㅡㅡㅡㅡ");
        }
    }

    public void OnClickAdressImgList()
    {
        var result = DBManager.Select("SELECT *" + "FROM boardinfo " + "WHERE adress1 =" + "'부산광역시'");
        int resultLength = result.Count;
        page.bookPages = new Sprite[resultLength];

        for(int i = 0; i < resultLength; i++)
        {

            page.bookPages[i] = image.overrideSprite = MediaProcessor.ToSprite(FTPManager.Download(result[i]["ImgPath"] as string));
        }


        //foreach (var dict in result)
        //{
        //    temp = Instantiate(Resources.Load("StorySets") as GameObject);
        //    temp.transform.SetParent(parentObject.transform);

        //    Image image = temp.transform.Find("StoryArticle/Image").GetComponent<Image>();
        //    Text text = temp.transform.Find("StoryArticle/Text").GetComponent<Text>();

        //    text.text = dict["title"] as string;
        //    image.overrideSprite = MediaProcessor.ToSprite(FTPManager.Download(dict["ImgPath"] as string));
        //}
    }


    //boardinfo 테이블 내용 전부 불러오기
    public void OnClickLoadBoardInfo()
    {
        var result = DBManager.Select("SELECT *" + "FROM boardinfo");
        foreach (var dict in result)
        {
            foreach (var row in dict)
            {
                print(row.Key + ": " + row.Value);
            }
            print("ㅡㅡㅡㅡㅡㅡㅡ");
        }
    }


    //boardinfo 테이블 내용 전부 불러오기
    public static void OnClickLoadBoardInfo_Test()
    {
        var result = DBManager.Select("SELECT *" + "FROM boardinfo");

        /*for (int i = 0; i < ; i++)
        {

        }
        print(result[i]["destination"] as string);
        print(result[i][] as string);
        string s = result[0]["destination"] as string;
        */

        foreach (var dict in result)
        {
            foreach (var row in dict)
            {

                print(row.Key + ": " + row.Value);


            }
            print("ㅡㅡㅡㅡㅡㅡㅡ");
        }
    }


    //1.가져온 행 갯수만큼 프리팹 인스턴스 해서 해놓던가
    //2.미리 만들어놓고 가져온 갯수만큼 켜서 보이게 한다.

}