using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LYJ_LocalBtnManager : MonoBehaviour, IPointerDownHandler
{
    public Text localName;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        localName.text = transform.GetChild(0).GetComponent<Text>().text;
        // KoreaRawImage.Instance.SetRawImage(transform.name);
        
        LYJ_TeleportUIManager.instance.ShowSpotPanel(true, transform.name);
    }
}
