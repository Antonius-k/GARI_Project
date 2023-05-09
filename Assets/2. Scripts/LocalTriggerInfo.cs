using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalTriggerInfo : MonoBehaviour
{
    public string LocalName;
    public int LocalX = 0;
    public int LocalY = 0;

    public Text localName;
    public Text weatherTemp;
    public Text weatherInfo;

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
        if (other.gameObject.tag == "Player")
        {
            WeatherManager_InPlayer wmip = other.gameObject.GetComponent<WeatherManager_InPlayer>();

            wmip.LocalXval = LocalX;
            wmip.LocalYval = LocalY;
            wmip.LocalNameVal = LocalName;

            wmip.EntranceLocal();
        }
    }
}
