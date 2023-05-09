using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitBtn : MonoBehaviour
{
    public GameObject QuitPanel;
    public AudioSource ass;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CallQuit()
    {
        QuitPanel.SetActive(true);
        ass.Play();
    }

    public void QuitBtnBtn()
    {
        Application.Quit();
        ass.Play();
    }

    public void QuitCancelBtn()
    {
        QuitPanel.SetActive(false);
        ass.Play();
    }
}
