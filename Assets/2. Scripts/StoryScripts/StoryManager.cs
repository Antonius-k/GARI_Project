using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEditor;
using System.IO;
using UnityEngine.SceneManagement;
//using SFB;
using TMPro;

public class StoryData
{
    public string storyTitle;
    public string description;
    public byte[] picture;
}

public class StoryManager : MonoBehaviour
{
    //storyCanvasOpen
    public GameObject storyCanvas;

    //inputStoryTitleToLoad -> �޴� ��� ��� ��������
    public TMP_InputField inputStoryTitleToLoad; //�ҷ��� ���丮�� ����
    public TMP_InputField inputPicDescription; //�ۼ��� ���丮�� ����
    public TMP_InputField inputTitle; //�ۼ��� ���丮�� ����
    public Text textTitle; //�ҷ��� ���丮�� ����
    public Text textDescription; //�ҷ��� ���丮�� ����
    public RawImage storyImg; //�ҷ��� ���丮�� �̹���

    byte[] pic;
    string path = "";
    string savepth = "";

    private void Start()
    {
        //   pic.Initialize();   
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
        //path = EditorUtility.OpenFilePanel("Show all images(.png)", "", "png");
        //path = WriteResult(StandaloneFileBrowser.OpenFilePanel("Open File", "", "", false));
        StartCoroutine(IESetImg());
    }

    //������ �̹���(texture)�� byte[]�������� ��ȯ�Ͽ� pic ������ ����ִ� �Լ�
    //�̹����� byte[]�������� ��ȯ�ϴ� ����??
    //=> byte[] �������� ��ȯ�ؾ� txt ���Ͽ� �� �� �ֱ� ������
    IEnumerator IESetImg()
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture("file:///" + path);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Texture myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            Texture2D convertedTexture = (Texture2D)myTexture;
            pic = convertedTexture.EncodeToPNG();

            /*            
            if (Directory.Exists(savepth) == false)
            {
                Directory.CreateDirectory(savepth);
            }
            File.WriteAllBytes(savepth + "/mapData.png", textuerData);
            bg.material.SetTexture("_MainTex", convertedTexture);
            */
        }
    }

    //UI Open
    public void OnClickUIOpen()
    {
        storyCanvas.SetActive(true);
    }

    public void OnClickUIClose()
    {
        storyCanvas.SetActive(false);
    }

    //����, ������ �����ְ�, �̹����� ���ε� �Ǿ� ������ ���丮 ���ε�
    //��, ���丮�� �������� json������ txt������ Resources ������ ��������
    public void OnClickUpLoad()
    {
        if (inputPicDescription.text.Length > 0 && pic.Length>0 && inputTitle.text.Length>0)
        {
            //���� ���� ���� �������� json ���Ϸ� �ۼ�
            OnClickSaveStory();
        }
    }

    //���丮�� �������� json������ txt������ Resources ������ �������ִ� �Լ�
    // = �������ִ� �Լ�
    public void OnClickSaveStory()
    {
        StoryData postData = new StoryData();
        string path = Application.dataPath + "/Resources";
        postData.storyTitle = inputTitle.text;
        postData.description = inputPicDescription.text;
        postData.picture = pic;
        string jsonPost = JsonUtility.ToJson(postData);
        Debug.Log(postData.description);
        File.WriteAllText(path + "/" + postData.storyTitle+ ".txt", jsonPost);
    }

    //Resources �������� ���丮�� �������� txt������ �ҷ��ͼ� ȭ�鿡 ����ִ� �Լ�
    // = �ҷ����� �Լ�
    public void OnClickLoadStory()
    {
        //resources/���� ������ txt������ �ҷ��´�.
        string storyPath = Application.dataPath + "/Resources/UserId" + inputStoryTitleToLoad.text + ".txt";
        string jsonData = File.ReadAllText(storyPath);
        StoryData postData = new StoryData();
        postData = JsonUtility.FromJson<StoryData>(jsonData);

        textTitle.text = postData.storyTitle;
        textDescription.text = postData.description;
        storyImg.texture = Base64ToTexture2D(postData.picture);

        print(textTitle.text);
        print(textDescription.text);
        print(storyImg.texture);
    }

    //��� ������ �ҷ�����
    public string[] OnClickGetSearchFile(string strPath)
    {
        string[] files = { "", };
        try
        {
            files = Directory.GetFiles(strPath, "*.*", SearchOption.AllDirectories);
        }
        catch (IOException ex)
        {
            //MessageBox.Show(ex.Message);
        }
        return files;
    }

    // -> Sprite�� �־���ߵȴٰ�?
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

    private void GetImageSize(byte[] imageData, out int width, out int height)
    {
        width = ReadInt(imageData, 3 + 15);
        height = ReadInt(imageData, 3 + 15 + 2 + 2);
    }

    private int ReadInt(byte[] imageData, int offset)
    {
        return (imageData[offset] << 8 | imageData[offset + 1]);
    }
}