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
    public InputField inputStoryTitleToLoad;//불러올 스토리의 제목
    public InputField inputPicDescription;//작성할 스토리의 내용
    public InputField inputTitle;//작성할 스토리의 제목
    public Text textTitle;//불러온 스토리의 제목
    public Text textDescription;//불러온 스토리의 내용
    public RawImage storyImg;//불러온 스토리의 이미지
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
        #region Test용임 실제 포톤 연동 시 지우셈
        PhotonNetwork.ConnectUsingSettings();
        
        #endregion
        //   pic.Initialize();
    }
    private void Update()
    {

    }
    #region Test용임 실제 포톤 연동 시 지우셈

    public override void OnConnected()
    {
        base.OnConnected();
        print(System.Reflection.MethodBase.GetCurrentMethod().Name);
    }

    //마스터 서버 접속성공시 호출(Lobby에 진입할 수 있는 상태)
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        //로비 진입 요청
        PhotonNetwork.JoinLobby();
    }

    //로비 진입 성공시 호출
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

    //파일 탐색기에서 이미지 찾게 해주는 함수
    public void OnClickSetImg()
    {
        //path = EditorUtility.OpenFilePanel("Show all images(.png)", "", "png");
        path = WriteResult(StandaloneFileBrowser.OpenFilePanel("Open File", "", "", false));
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

    //제목, 내용이 쓰여있고, 이미지가 업로드 되어 있으면 스토리 업로드
    //즉, 스토리의 제목으로 json형태의 txt파일을 Resources 폴더에 생성해줌
    public void OnClickUpLoad()
    {
        if (inputPicDescription.text.Length > 0 && pic.Length > 0 && inputTitle.text.Length > 0)
        {
            //사진 설명에 뭐가 써있으면 json 파일로 작성
            OnClickSaveStory();
        }
    }

    //빌딩 클릭하면 그 빌딩의 이름으로 serManager_LJH.instance.clickedBuildingName 세팅해주어야 함
    //@@@@@@@@할것

    //스토리의 제목으로 json형태의 txt파일을 Resources 폴더에 생성해주는 함수
    // = 저장해주는 함수
    public void OnClickSaveStory()
    {
        // string storyPath = Application.dataPath + "/Resources/" + inputStoryTitleToLoad.text + ".txt";
        string storyPath = Application.dataPath + "/Resources/" + UserManager_LJH.instance.clickedBuildingName + ".txt";
        FileInfo fileInfo = new FileInfo(storyPath);
        if (fileInfo.Exists) //이미 이 빌딩의 이름으로 파일이 있으면, 즉 게시글이 작성되어있으면
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


                // 작성한 글 초기화
                inputPicDescription.text = "";
                inputTitle.text = "";
            }
            else
            {
               
                    print("게시글 수가 5개를 넘음~");
            }

            //이 포스트 오브젝트 생성
        }

        else//게시글이 작성되어있지 않으면 새 파일 작성
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
            //이 포스트 오브젝트 생성 


            // 작성한 글 초기화
            inputPicDescription.text = "";
            inputTitle.text = "";
        }
    }


    [PunRPC]
    public void RpcSetPostOnContent(string buildingName, string title, string description)
    {
        SearchBuildingContent(buildingName);
        story.transform.SetParent(contentTr);
        //story의 사진, 이름, 내용 설정해주어야 함
        story.transform.GetChild(0).GetComponent<Text>().text = title;
        //story.transform.GetChild(1).GetComponent<RawImage>().texture = Base64ToTexture2D(img);
        story.transform.GetChild(2).GetComponent<Text>().text = description;
    }

    //Resources 폴더에서 스토리의 제목으로 txt파일을 불러와서 화면에 띄워준느 함수
    // = 불러오는 함수
    public void OnClickLoadStory()
    {
        string storyPath = Application.dataPath + "/Resources/" + UserManager_LJH.instance.clickedBuildingName + ".txt";
        string jsonData = File.ReadAllText(storyPath);
        StoryInfoList storyDatas = new StoryInfoList();

        storyDatas = JsonUtility.FromJson<StoryInfoList>(jsonData);

        for (int i = 0; i < storyDatas.storyInfos.Count; i++)
        {
            //건물 스크롤뷰 패널 찾아서 그 스크롤뷰의 content에 하나씩 넣어주기

        }

        *//*textTitle.text = postData.storyTitle;
        textDescription.text = postData.description;
        storyImg.texture = Base64ToTexture2D(postData.picture);*//*
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
                print("찾았음 "+detailedInformationArray[i].BuildingName);
                print("이름 : " + detailedInformationArray[i].gameObject.transform.parent.GetChild(3).GetChild(0).GetChild(0).GetChild(0).name);
                contentTr = detailedInformationArray[i].gameObject.transform.parent.GetChild(3).GetChild(0).GetChild(0).GetChild(0);
                story.transform.SetParent(contentTr);
                //print("Bang?");
            }
        }
    }
}
*/