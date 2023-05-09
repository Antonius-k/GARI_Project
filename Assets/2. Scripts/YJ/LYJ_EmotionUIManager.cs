using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LYJ_EmotionUIManager : MonoBehaviour
{
    public static LYJ_EmotionUIManager Instance;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    public GameObject emotionUI;

    // Start is called before the first frame update
    void Start()
    {
        ShowEmotionUI(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowEmotionUI(bool show)
    {
        emotionUI.SetActive(show);
    }
}
