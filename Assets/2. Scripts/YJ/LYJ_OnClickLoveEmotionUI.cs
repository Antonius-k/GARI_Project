using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class LYJ_OnClickLoveEmotionUI : MonoBehaviour
{
    public static LYJ_OnClickLoveEmotionUI Instance;
    public Animator playerAnim;
    private GameObject player;
    public Camera cam;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    public Animator loveAnim;
    private bool canCount;
    public int loveClickCount;

    public GameObject curBuilding;
    
    // Start is called before the first frame update
    void Start()
    {
        canCount = true;
        player = playerAnim.transform.root.gameObject;
        cam = Camera.main;
        
        print(cam.gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        // print("loveClickCount: " + loveClickCount);
    }

    private Quaternion fstPlayerRot;
    
    private void OnMouseEnter()
    {
        Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
        fstPlayerRot = player.transform.rotation;
        
        loveAnim.enabled = true;
        player.GetComponent<_PlayerMove>().enabled = false;
        playerAnim.SetBool("HappyDance", true);
    }

    private float curTime;
    private void OnMouseOver()
    {
        curTime += Time.deltaTime;
        curTime = Mathf.Clamp(curTime, 0, 1);
        cam.fieldOfView = Mathf.Lerp(60, 36.6f, curTime);
        
        player.transform.rotation = Quaternion.Lerp(player.transform.rotation, Quaternion.Euler(0, 180, 0), 0.1f);
    }

    private void OnMouseExit()
    {
        curTime = 0;
        Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
        player.transform.rotation = fstPlayerRot;
        cam.fieldOfView = 60f;
        
        loveAnim.enabled = false;
        player.GetComponent<_PlayerMove>().enabled = true;
        playerAnim.SetBool("HappyDance", false);
        playerAnim.SetTrigger("Idle");
    }
    
    private void OnMouseDown()
    {
        Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
        print(canCount);
        if (canCount)
        {
            canCount = false;
            loveAnim.enabled = false;

            loveClickCount++;
        
            print(curBuilding.name);
            
            //curBuilding
            curBuilding.GetComponentInChildren<DetailedInformation>().loveCount++;
            curBuilding.GetComponentInChildren<DetailedInformation>().loveCountTxt.text = curBuilding.GetComponentInChildren<DetailedInformation>().loveCount.ToString();
            
        }
    }
    
    private void OnMouseUp()
    {
        Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
    }
}
