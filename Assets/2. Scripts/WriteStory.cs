using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WriteStory : MonoBehaviour
{
    public static WriteStory Instance;

    public string WSN;

    public Text Halla;
    public Text Manjang;
    //public Text Urine;

    public InputField wsn;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void WriteStroyBtn()
    {
        if (WSN == "Mountain_Halla")
        {
            print("»ê ´­·¶À½");
            Halla.text = wsn.text;
            this.gameObject.SetActive(false);
        }
        else if (WSN == "Manjang")
        {
            Manjang.text = wsn.text;
            this.gameObject.SetActive(false);
        }
        else if (WSN == "Urine")
        {
            print("Urine");
        }
    }
}
