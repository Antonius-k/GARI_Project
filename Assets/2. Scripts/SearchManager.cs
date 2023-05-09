using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchManager : MonoBehaviour
{
    public GameObject Search_NamePanel;
    public GameObject Search_TypePanel;
    public GameObject Search_KeywordPanel;

    public GameObject SearchingBtnOn;
    public GameObject SearchingBtnOff;

    public InputField Search_Name;
    public Text Search_Type;
    public Text Search_Keyword;

    public DetailedInformation[] apple;

    //public AudioSource ass;

    void Start()
    {
             
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{

        //}
    }

    public void NameNextClick()
    {
        //ass.Play();
        Search_NamePanel.SetActive(false);
        Search_TypePanel.SetActive(true);
        Search_KeywordPanel.SetActive(false);
    }

    public void TypeNextClick()
    {
        //ass.Play();
        Search_NamePanel.SetActive(false);
        Search_TypePanel.SetActive(false);
        Search_KeywordPanel.SetActive(true);
    }

    public void KeywordNextClick()
    {
        //ass.Play();
        Search_NamePanel.SetActive(true);
        Search_TypePanel.SetActive(false);
        Search_KeywordPanel.SetActive(false);

        SearchingBtnOff.SetActive(true);
        SearchingBtnOn.SetActive(false);
    }

    public void SearchNameClick()
    {
        //ass.Play();
        apple = GameObject.FindObjectsOfType<DetailedInformation>();

        for (int i = 0; i < apple.Length; i++)
        {
            if (apple[i].BuildingName == Search_Name.text)
            {
                //Destroy(apple[i].transform.parent.gameObject);
                apple[i].Bang();
            }
            else if (apple[i].BuildingName != Search_Name.text)
            {
                apple[i].BangOff();
            }
        }

        Search_TypePanel.SetActive(false);
        Search_NamePanel.SetActive(false);
        Search_KeywordPanel.SetActive(false);

        SearchingBtnOff.SetActive(true);
        SearchingBtnOn.SetActive(false);
    }

    public void SearchTypeClick()
    {
        //ass.Play();
        apple = GameObject.FindObjectsOfType<DetailedInformation>();

        for (int i = 0; i < apple.Length; i++)
        {
            if (apple[i].BuildingType == Search_Type.text)
            {
                apple[i].Bang();
            }
            else if (apple[i].BuildingType != Search_Type.text)
            {
                apple[i].BangOff();
            }
        }

        Search_TypePanel.SetActive(false);
        Search_NamePanel.SetActive(false);
        Search_KeywordPanel.SetActive(false);

        SearchingBtnOff.SetActive(true);
        SearchingBtnOn.SetActive(false);
    }

    

    public void SearchKeywordClick()
    {
        //ass.Play();
        apple = GameObject.FindObjectsOfType<DetailedInformation>();

        for (int i = 0; i < apple.Length; i++)
        {
            if (apple[i].BuildingKeyword == Search_Keyword.text)
            {
                apple[i].Bang();
            }
            else if (apple[i].BuildingKeyword != Search_Keyword.text)
            {
                apple[i].BangOff();
            }
        }

        Search_TypePanel.SetActive(false);
        Search_NamePanel.SetActive(false);
        Search_KeywordPanel.SetActive(false);

        SearchingBtnOff.SetActive(true);
        SearchingBtnOn.SetActive(false);
    }

    public void SearchingCancel()
    {
        //ass.Play();
        for (int i = 0; i < apple.Length; i++)
        {
            apple[i].BangOff();
        }

        Search_TypePanel.SetActive(false);
        Search_NamePanel.SetActive(false);
        Search_KeywordPanel.SetActive(false);

        SearchingBtnOff.SetActive(false);
        SearchingBtnOn.SetActive(true);
    }
}
