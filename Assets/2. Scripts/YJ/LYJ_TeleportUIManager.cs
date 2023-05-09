using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

/* UIManager
 * 
 */
public class LYJ_TeleportUIManager : MonoBehaviour
{
    public static LYJ_TeleportUIManager instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    public GameObject teleportPanel;
    
    public Transform localPanel;
    public Button[] localPanelChildren;
    
    public Transform spotPanelAll;
    public Dictionary<string, GameObject> spotPanelChildren;

    public GameObject storyPanel;
    
    // Start is called before the first frame update
    void Start()
    {
        spotPanelChildren = new Dictionary<string, GameObject>();
        
        localPanelChildren = localPanel.GetComponentsInChildren<Button>();
        for (int i = 0; i < spotPanelAll.childCount; i++)
        {
            spotPanelChildren.Add(spotPanelAll.GetChild(i).name, spotPanelAll.GetChild(i).gameObject);
        }
        ShowTeleportPanel(true);
        ShowStoryPanel(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowAllUI(bool show)
    {
        ShowTeleportPanel(show);
        ShowStoryPanel(show);
    }

    public void ShowTeleportPanel(bool show)
    {
        teleportPanel.SetActive(show);
    }

    public void ShowLocalPanel(bool show)
    {
        localPanel.gameObject.SetActive(show);
    }

    public void ShowSpotPanel(bool show, string spotKey)
    {
        spotPanelChildren.GetValueOrDefault(spotKey).SetActive(show);
    }

    public void ShowStoryPanel(bool show)
    {
        storyPanel.SetActive(show);
    }
}
