using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WriteStroy2 : MonoBehaviour
{
    public InputField ws;
    public Text SpeechBub;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WriteStroyBtn2()
    {
        SpeechBub.text = ws.text;
        PlayerMove.Instance.canMove = true;
        this.gameObject.SetActive(false);
    }
}
