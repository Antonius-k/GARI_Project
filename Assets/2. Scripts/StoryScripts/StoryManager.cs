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

    //inputStoryTitleToLoad -> 받는 즉시 출력 시켜주자
    public TMP_InputField inputStoryTitleToLoad; //불러올 스토리의 제목
    public TMP_InputField inputPicDescription; //작성할 스토리의 내용
    public TMP_InputField inputTitle; //작성할 스토리의 제목
    public Text textTitle; //불러온 스토리의 제목
    public Text textDescription; //불러온 스토리의 내용
    public RawImage storyImg; //불러온 스토리의 이미지

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

    //파일 탐색기에서 이미지 찾게 해주는 함수
    public void OnClickSetImg()
    {
        //path = EditorUtility.OpenFilePanel("Show all images(.png)", "", "png");
        //path = WriteResult(StandaloneFileBrowser.OpenFilePanel("Open File", "", "", false));
        StartCoroutine(IESetImg());
    }

    //선택한 이미지(texture)를 byte[]형식으로 변환하여 pic 변수에 담아주는 함수
    //이미지를 byte[]형식으로 변환하는 이유??
    //=> byte[] 형식으로 변환해야 txt 파일에 쓸 수 있기 때문에
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

    //제목, 내용이 쓰여있고, 이미지가 업로드 되어 있으면 스토리 업로드
    //즉, 스토리의 제목으로 json형태의 txt파일을 Resources 폴더에 생성해줌
    public void OnClickUpLoad()
    {
        if (inputPicDescription.text.Length > 0 && pic.Length>0 && inputTitle.text.Length>0)
        {
            //사진 설명에 뭐가 써있으면 json 파일로 작성
            OnClickSaveStory();
        }
    }

    //스토리의 제목으로 json형태의 txt파일을 Resources 폴더에 생성해주는 함수
    // = 저장해주는 함수
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

    //Resources 폴더에서 스토리의 제목으로 txt파일을 불러와서 화면에 띄워주는 함수
    // = 불러오는 함수
    public void OnClickLoadStory()
    {
        //resources/하위 선택한 txt파일을 불러온다.
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

    //모든 파일을 불러오기
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

    // -> Sprite로 넣어줘야된다고?
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