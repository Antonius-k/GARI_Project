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
//1.������ �� ������ŭ ������ �ν��Ͻ� �ؼ� �س�����
//2.�̸� �������� ������ ������ŭ �Ѽ� ���̰� �Ѵ�.
public class ImageManager : MonoBehaviour
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



    // ���� ����
    public string trip1;
    public string trip2;
    public string trip3;
    public string trip4;
    public string trip5;

    public GameObject localPanel;

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
    public void OnClickAdressBoardList()
    {
        var result = DBManager.Select("SELECT *" + "FROM boardinfo " + "WHERE adress1 =" + "'" + dropLocal1.text + "'");

        foreach (var dict in result)
        {
            print("Count: " + dict.Count);

            temp = Instantiate(Resources.Load("StorySets") as GameObject);
            temp.transform.SetParent(parentObject.transform);

            Image image = temp.transform.Find("StoryArticle/Image").GetComponent<Image>();
            Text text_1 = temp.transform.Find("StoryArticle/Text").GetComponent<Text>();
            Text text_2 = temp.transform.Find("StoryArticle/Description").GetComponent<Text>();            
            
            Text text_3 = temp.transform.Find("StoryArticle/Trip1").GetComponent<Text>();            
            Text text_4 = temp.transform.Find("StoryArticle/Trip2").GetComponent<Text>();            
            Text text_5 = temp.transform.Find("StoryArticle/Trip3").GetComponent<Text>();            
            Text text_6 = temp.transform.Find("StoryArticle/Trip4").GetComponent<Text>();            
            Text text_7 = temp.transform.Find("StoryArticle/Trip5").GetComponent<Text>();            

            //temp.transform.Find("DetailBtn").GetComponent<DetailBtn>().boardNum = dict["boardId"] as string;
            text_1.text = dict["title"] as string;
            text_2.text = dict["description"] as string;

            string ss = dict["destination"] as string;;

            //for(int i = 0; i < 5; i++)
            //{
            //    if ((ss.Split("/"))[0] != null)
            //    {
            //        text_3.text = (ss.Split("/"))[0];
            //    }
            //    if ((ss.Split("/"))[1] != null)
            //    {
            //        text_4.text = (ss.Split("/"))[1];
            //    }

            //    if ((ss.Split("/"))[2] != null)
            //    {
            //        text_5.text = (ss.Split("/"))[2];
            //    }

            //    if ((ss.Split("/"))[3] != null)
            //    {
            //        text_6.text = (ss.Split("/"))[3];
            //    }

            //    if ((ss.Split("/"))[4] != null)
            //    {
            //        text_7.text = (ss.Split("/"))[4];
            //    }
            //}

            //if ((ss.Split("/"))[0] != null)
            //{
            //    text_3.text = (ss.Split("/"))[0];
            //}

            //else if ((ss.Split("/"))[1] != null)
            //{
            //    text_3.text = (ss.Split("/"))[0];
            //    text_4.text = (ss.Split("/"))[1];
            //}

            //else if ((ss.Split("/"))[2] != null)
            //{
            //    text_3.text = (ss.Split("/"))[0];
            //    text_4.text = (ss.Split("/"))[1];
            //    text_5.text = (ss.Split("/"))[2];
            //}

            //else if ((ss.Split("/"))[3] != null)
            //{
            //    text_3.text = (ss.Split("/"))[0];
            //    text_4.text = (ss.Split("/"))[1];
            //    text_5.text = (ss.Split("/"))[2];
            //    text_6.text = (ss.Split("/"))[3];
            //}

            //else if ((ss.Split("/"))[4] != null)
            //{
            //    text_3.text = (ss.Split("/"))[0];
            //    text_4.text = (ss.Split("/"))[1];
            //    text_5.text = (ss.Split("/"))[2];
            //    text_6.text = (ss.Split("/"))[3];
            //    text_7.text = (ss.Split("/"))[4];
            //}

            text_3.text = ((dict["destination"] as string).Split("/"))[0];
            text_4.text = ((dict["destination"] as string).Split("/"))[1];
            text_5.text = ((dict["destination"] as string).Split("/"))[2];
            text_6.text = ((dict["destination"] as string).Split("/"))[3];
            text_7.text = ((dict["destination"] as string).Split("/"))[4];

            image.overrideSprite = MediaProcessor.ToSprite(FTPManager.Download(dict["ImgPath"] as string));

            foreach (var row in dict)
            {
                print(row.Key + ": " + row.Value);
            }
            print("�ѤѤѤѤѤѤ�");
            
            localPanel.SetActive(false);
        }
    }




    public GameObject storyPanel;

    public void OnClickPanelClose()
    {
        storyPanel.SetActive(false);
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


        foreach (var dict in result)
        {
            foreach (var row in dict)
            {

                print(row.Key + ": " + row.Value);
            }
            print("�ѤѤѤѤѤѤ�");
        }
    }



}