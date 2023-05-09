using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public static UIManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    public GameObject loginUI;
    public GameObject signupUI;
    public GameObject popupSignupFail;
    public GameObject popupSignupComplete;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowAllUI(bool show)
    {
        ShowLoginUI(show);
        ShowSignupUI(show);
        ShowAllPopupUI(show);
    }

    public void ShowLoginUI(bool show)
    {
        loginUI.SetActive(show);
    }
    
    public void ShowSignupUI(bool show)
    {
        signupUI.SetActive(show);
    }

    public void ShowAllPopupUI(bool show)
    {
        ShowPopupCompleteUI(show);
        ShowPopupFailUI(show);
    }

    public void ShowPopupCompleteUI(bool show)
    {
        popupSignupComplete.SetActive(show);
    }
    public void ShowPopupFailUI(bool show)
    {
        popupSignupFail.SetActive(show);
    }
}
