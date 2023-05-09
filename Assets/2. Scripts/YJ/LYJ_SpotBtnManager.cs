using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LYJ_SpotBtnManager : MonoBehaviour, IPointerDownHandler
{
    public Text spotName;
    
    // Start is called before the first frame update
    void Start()
    {

        spotName = transform.root.GetChild(2).GetChild(0).Find("Text_SpotInput").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        spotName.text = transform.GetChild(0).GetComponent<Text>().text;
    }
}
