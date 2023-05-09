using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoTxtNoImg : MonoBehaviour
{
    public Text Bub1;
    public GameObject img1;

    public Text Bub2;
    public GameObject img2;

    public Text Bub3;
    public GameObject img3;

    public Text Bub4;
    public GameObject img4;

   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Bub1.text == "")
        {
            img1.SetActive(false);
        }
        else if (Bub1.text != "")
        {
            img1.SetActive(true);
        }

        if (Bub2.text == "")
        {
            img2.SetActive(false);
        }
        else if (Bub2.text != "")
        {
            img2.SetActive(true);
        }

        if (Bub3.text == "")
        {
            img3.SetActive(false);
        }
        else if (Bub3.text != "")
        {
            img3.SetActive(true);
        }

        if (Bub4.text == "")
        {
            img4.SetActive(false);
        }
        else if (Bub4.text != "")
        {
            img4.SetActive(true);
        }

        
    }
}
