using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEditor;
using System.IO;
using UnityEngine.SceneManagement;
using SFB;


//��⵵, ������, ��û�ϵ�, ��û����, ���ϵ�, ��󳲵�,
//����ϵ�, ���󳲵�, ����Ư����ġ��, ����Ư����, ��õ������, ����Ư����ġ��,
//����������, �뱸������, ���ֱ�����, ��걤����, �λ걤����
public class ImageManager2 : MonoBehaviour
{
    [Header("���丮")]
    //����
    public InputField inputLabel;
    //���丮�� ����
    public InputField inputStoryTitleToLoad;
    //���丮�� ����
    public InputField inputDescription;
    //������
    public InputField[] inputDestination;
    //�̹���
    public Image image;
    //������
    public Text adressText;

    [Header("���̺�")]
    int boardId;
    string loginId = AccountManager.id;
    //���� ��ġ
    string label;
    string title = "titleTest";
    string description;
    string destination;
    //������
    string adress1;

    //�ؽ��� ��ȯ
    Texture2D convertedTexture;

    //boardId �ڿ� .jpg�� �ٿ��ش�.
    //�̹��� ���� �̸�
    string fileName;

    //���� �ø���
    byte[] pic;
    string imgPath = "";
    //string savepth = "";

    [Header("����")]
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

        //    var result = DBManager.Select("SELECT *" + "FROM boardinfo " + "WHERE adress1 =" + "'�λ걤����'");
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

        //������ ��� ����
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


    //���� Ž���⿡�� �̹��� ã�� ���ִ� �Լ�
    public void OnClickSetImg()
    {
        imgPath = WriteResult(StandaloneFileBrowser.OpenFilePanel("Open File", "", "", false));
        print(imgPath);
        StartCoroutine(IESetImg());
    }


    //������ �̹���(texture)�� byte[]�������� ��ȯ�Ͽ� pic ������ ����ִ� �Լ�
    //�̹����� byte[]�������� ��ȯ�ϴ� ����??
    //=> byte[] �������� ��ȯ�ؾ� txt ���Ͽ� �� �� �ֱ� ������
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
            //���� ��� ������Ʈ, ��ο� �ѱ��̸��� ������ �ȿö� ��
            FTPManager.Upload(pic, fileName);

            //���� �о����
            image.overrideSprite = MediaProcessor.ToSprite(FTPManager.Download(fileName));
        }
    }


    //boardinfo ���̺� �־��ֱ�
    public void InsertQuerry()
    {
        string query =
            string.Format("INSERT INTO boardinfo VALUES(0,'{0}','{1}','{2}','{3}','{4}','{5}')", loginId, title, description, destination, fileName, adress1);
        DBManager.Execute(query);

        print(fileName);
    }


    //byte[] to Texture2D ��ȯ���ִ� �Լ�
    private Texture2D Base64ToTexture2D(byte[] imageData)
    {
        int width, height;
        GetImageSize(imageData, out width, out height);

        // �������� new�� ���ٰ�� �޸� ���� �߻� -> ��� ������ ����
        Texture2D texture = new Texture2D(width, height, TextureFormat.ARGB32, false, true);

        texture.hideFlags = HideFlags.HideAndDontSave;
        texture.filterMode = FilterMode.Point;
        texture.LoadImage(imageData);
        texture.Apply();

        return texture;
    }


    public void ImageDownload()
    {
        byte[] image = FTPManager.Download("�����̸�");
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
    [Header("������ ���丮 �ҷ�����")]

    //storySetsPrefab�ȿ� �־���.
    public GameObject temp;
    public GameObject parentObject;
    public Text dropLocal1;
    public Image[] loadImagePath;


    //Stories2 �������� �ҷ�����
    //SELECT * FROM boardinfo where Adress1 = '��û�ϵ�'
    public void OnClickAdressBoardList() // �±�����
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
            print("�ѤѤѤѤѤѤ�");
        }
    }

    public void OnClickAdressImgList()
    {
        var result = DBManager.Select("SELECT *" + "FROM boardinfo " + "WHERE adress1 =" + "'�λ걤����'");
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


    //boardinfo ���̺� ���� ���� �ҷ�����
    public void OnClickLoadBoardInfo()
    {
        var result = DBManager.Select("SELECT *" + "FROM boardinfo");
        foreach (var dict in result)
        {
            foreach (var row in dict)
            {
                print(row.Key + ": " + row.Value);
            }
            print("�ѤѤѤѤѤѤ�");
        }
    }


    //boardinfo ���̺� ���� ���� �ҷ�����
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
            print("�ѤѤѤѤѤѤ�");
        }
    }


    //1.������ �� ������ŭ ������ �ν��Ͻ� �ؼ� �س�����
    //2.�̸� �������� ������ ������ŭ �Ѽ� ���̰� �Ѵ�.

}