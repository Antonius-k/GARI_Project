using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartSceneBtn_Fade : MonoBehaviour
{
    public GameObject FadePannel;

    public void PageSkip()
    {
        Invoke("PageSkip2", 4.0f);
    }

    public void PageSkip2()
    {
        SceneManager.LoadScene(1);
    }

}
