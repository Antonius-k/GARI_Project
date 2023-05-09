/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEditor;
using System.IO;
using UnityEngine.SceneManagement;
using SFB;
using Photon.Pun;
using Photon.Realtime;


[System.Serializable]
public class StoryInfoList
{
    public string name;
    public List<StoryInfo> storyInfos;
}


[System.Serializable]
public class StoryInfo
{
    public string storyTitle;
    public string description;
    public byte[] picture;
}
public class StoryManager_LJH : MonoBehaviourPunCallbacks
{
    public InputField inputStoryTitleToLoad;//�ҷ��� ���丮�� ����
    public InputField inputPicDescription;//�ۼ��� ���丮�� ����
    public InputField inputTitle;//�ۼ��� ���丮�� ����
    public Text textTitle;//�ҷ��� ���丮�� ����
    public Text textDescription;//�ҷ��� ���丮�� ����
    public RawImage storyImg;//�ҷ��� ���丮�� �̹���
    public DetailedInformation[] detailedInformationArray;
    public GameObject storyPrefab;
    public GameObject story;

    Texture2D convertedTexture;
    Transform contentTr;
    byte[] pic;
    string path = "";
    string savepth = "";
    private void Start()
    {
        #region Test���� ���� ���� ���� �� �����
        PhotonNetwork.ConnectUsingSettings();
        
        #endregion
        //   pic.Initialize();
    }
    private void Update()
    {

    }
    #region Test���� ���� ���� ���� �� �����

    public override void OnConnected()
    {
        base.OnConnected();
        print(System.Reflection.MethodBase.GetCurrentMethod().Name);
    }

    //������ ���� ���Ӽ����� ȣ��(Lobby�� ������ �� �ִ� ����)
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        //�κ� ���� ��û
        PhotonNetwork.JoinLobby();
    }

    //�κ� ���� ������ ȣ��
    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        print(System.Reflection.MethodBase.GetCurrentMethod().Name);

        RoomOptions roomOptions = new RoomOptions();
        

        PhotonNetwork.JoinOrCreateRoom("Test",roomOptions,null);
  
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        print("joined room");
    }
    #endregion


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
        path = WriteResult(StandaloneFileBrowser.OpenFilePanel("Open File", "", "", false));
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
            convertedTexture = (Texture2D)myTexture;
            pic = convertedTexture.EncodeToPNG();

            *//*            if (Directory.Exists(savepth) == false)
                        {
                            Directory.CreateDirectory(savepth);
                        }
                        File.WriteAllBytes(savepth + "/mapData.png", textuerData);
                        bg.material.SetTexture("_MainTex", convertedTexture);*//*
        }
    }

    //����, ������ �����ְ�, �̹����� ���ε� �Ǿ� ������ ���丮 ���ε�
    //��, ���丮�� �������� json������ txt������ Resources ������ ��������
    public void OnClickUpLoad()
    {
        if (inputPicDescription.text.Length > 0 && pic.Length > 0 && inputTitle.text.Length > 0)
        {
            //���� ���� ���� �������� json ���Ϸ� �ۼ�
            OnClickSaveStory();
        }
    }

    //���� Ŭ���ϸ� �� ������ �̸����� serManager_LJH.instance.clickedBuildingName �������־�� ��
    //@@@@@@@@�Ұ�

    //���丮�� �������� json������ txt������ Resources ������ �������ִ� �Լ�
    // = �������ִ� �Լ�
    public void OnClickSaveStory()
    {
        // string storyPath = Application.dataPath + "/Resources/" + inputStoryTitleToLoad.text + ".txt";
        string storyPath = Application.dataPath + "/Resources/" + UserManager_LJH.instance.clickedBuildingName + ".txt";
        FileInfo fileInfo = new FileInfo(storyPath);
        if (fileInfo.Exists) //�̹� �� ������ �̸����� ������ ������, �� �Խñ��� �ۼ��Ǿ�������
        {
            string jsonData = File.ReadAllText(storyPath);

            StoryInfoList postDatas = new StoryInfoList();
            postDatas.storyInfos = new List<StoryInfo>();
            StoryInfo postData = new StoryInfo();

            postData.storyTitle = inputTitle.text;
            postData.description = inputPicDescription.text;
            postData.picture = pic;

            if (postDatas.storyInfos.Count < 5)
            {
                postDatas.storyInfos.Add(postData);
                string jsonPost = JsonUtility.ToJson(postDatas);
                Debug.Log(postData.description);
                File.WriteAllText(storyPath, jsonPost);

                detailedInformationArray = GameObject.FindObjectsOfType<DetailedInformation>();

                story = PhotonNetwork.Instantiate("StoryPrefab", Vector3.zero, Quaternion.identity);

                //story.transform.SetParent(contentTr);
                photonView.RPC("RpcSetPostOnContent", RpcTarget.All, UserManager_LJH.instance.clickedBuildingName,
                    postData.storyTitle, postData.description);


                // �ۼ��� �� �ʱ�ȭ
                inputPicDescription.text = "";
                inputTitle.text = "";
            }
            else
            {
               
                    print("�Խñ� ���� 5���� ����~");
            }

            //�� ����Ʈ ������Ʈ ����
        }

        else//�Խñ��� �ۼ��Ǿ����� ������ �� ���� �ۼ�
        {
            StoryInfoList postDatas = new StoryInfoList();
            postDatas.storyInfos = new List<StoryInfo>();
            StoryInfo postData = new StoryInfo();

            postData.storyTitle = inputTitle.text;
            postData.description = inputPicDescription.text;
            postData.picture = pic;

            postDatas.name = UserManager_LJH.instance.clickedBuildingName;
            postDatas.storyInfos.Add(postData);

            string jsonPost = JsonUtility.ToJson(postDatas);
            Debug.Log(postData.description);
            File.WriteAllText(storyPath, jsonPost);

            detailedInformationArray = GameObject.FindObjectsOfType<DetailedInformation>();

            story = PhotonNetwork.Instantiate("StoryPrefab", Vector3.zero, Quaternion.identity);

            //story.transform.SetParent(contentTr);
            photonView.RPC("RpcSetPostOnContent", RpcTarget.All, UserManager_LJH.instance.clickedBuildingName,
                postData.storyTitle, postData.description);
            //�� ����Ʈ ������Ʈ ���� 


            // �ۼ��� �� �ʱ�ȭ
            inputPicDescription.text = "";
            inputTitle.text = "";
        }
    }


    [PunRPC]
    public void RpcSetPostOnContent(string buildingName, string title, string description)
    {
        SearchBuildingContent(buildingName);
        story.transform.SetParent(contentTr);
        //story�� ����, �̸�, ���� �������־�� ��
        story.transform.GetChild(0).GetComponent<Text>().text = title;
        //story.transform.GetChild(1).GetComponent<RawImage>().texture = Base64ToTexture2D(img);
        story.transform.GetChild(2).GetComponent<Text>().text = description;
    }

    //Resources �������� ���丮�� �������� txt������ �ҷ��ͼ� ȭ�鿡 ����ش� �Լ�
    // = �ҷ����� �Լ�
    public void OnClickLoadStory()
    {
        string storyPath = Application.dataPath + "/Resources/" + UserManager_LJH.instance.clickedBuildingName + ".txt";
        string jsonData = File.ReadAllText(storyPath);
        StoryInfoList storyDatas = new StoryInfoList();

        storyDatas = JsonUtility.FromJson<StoryInfoList>(jsonData);

        for (int i = 0; i < storyDatas.storyInfos.Count; i++)
        {
            //�ǹ� ��ũ�Ѻ� �г� ã�Ƽ� �� ��ũ�Ѻ��� content�� �ϳ��� �־��ֱ�

        }

        *//*textTitle.text = postData.storyTitle;
        textDescription.text = postData.description;
        storyImg.texture = Base64ToTexture2D(postData.picture);*//*
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

    private void GetImageSize(byte[] imageData, out int width, out int height)
    {
        width = ReadInt(imageData, 3 + 15);
        height = ReadInt(imageData, 3 + 15 + 2 + 2);
    }

    private int ReadInt(byte[] imageData, int offset)
    {
        return (imageData[offset] << 8 | imageData[offset + 1]);
    }

    public void SearchBuildingContent(string buildingName)
    {
        contentTr = null;
        for (int i = 0; i < detailedInformationArray.Length; i++)
        {
            if (detailedInformationArray[i].BuildingName == buildingName)
            {
                //Destroy(apple[i].transform.parent.gameObject);
                print("ã���� "+detailedInformationArray[i].BuildingName);
                print("�̸� : " + detailedInformationArray[i].gameObject.transform.parent.GetChild(3).GetChild(0).GetChild(0).GetChild(0).name);
                contentTr = detailedInformationArray[i].gameObject.transform.parent.GetChild(3).GetChild(0).GetChild(0).GetChild(0);
                story.transform.SetParent(contentTr);
                //print("Bang?");
            }
        }
    }
}
*/