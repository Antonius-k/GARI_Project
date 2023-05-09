using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Map_RawImage : MonoBehaviour
{
    public RawImage mapRawImage;    

    [Header("¸Ê Á¤º¸ ÀÔ·Â")]
    public string strBaseURL = "";
    public float latitude;
    public float longitude;
    public int level = 14;
    public int mapWidth;
    public int mapHeight;
    public string strAPIKey = "";
    public string secretKey = "";

    string lat;
    string lon;


    // Start is called before the first frame update
    void Start()
    {
        //mapRawImage = GetComponent<RawImage>();
        //StartCoroutine(MapLoader());

        lat = latitude.ToString();
        lon = longitude.ToString();
    }

    private void LateUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        print(v);

        latitude = latitude + (latitude * v);
        longitude = longitude + (longitude * h);

        lat = latitude.ToString();
        lon = longitude.ToString();

        //if (Input.GetAxis(KeyCode.K))
        //{
        //    latitude = latitude + 0.1f;
        //    longitude = longitude + 0.2f;

        //    lat = latitude.ToString();
        //    lon = longitude.ToString();
        //}

        mapRawImage = GetComponent<RawImage>();
        StartCoroutine(MapLoader());

    }

    IEnumerator MapLoader()
    {
        string str = strBaseURL + "?w=" + mapWidth.ToString() + "&h=" + mapHeight.ToString() + "&center=" + lon + "," + lat + "&level=" + level.ToString();

        //Debug.Log(str.ToString());

        UnityWebRequest request = UnityWebRequestTexture.GetTexture(str);

        request.SetRequestHeader("X-NCP-APIGW-API-KEY-ID", strAPIKey);
        request.SetRequestHeader("X-NCP-APIGW-API-KEY", secretKey);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            //Debug.Log(request.error);
        }
        else
        {
            mapRawImage.texture = DownloadHandlerTexture.GetContent(request);
        }
    }
}
