using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoTxtTest : MonoBehaviour
{
    public Text Bub;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Bub.text == "")
        {
            this.gameObject.SetActive(false);
        }
    }
}
