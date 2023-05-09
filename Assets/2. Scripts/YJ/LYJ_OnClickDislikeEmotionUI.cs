using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class LYJ_OnClickDislikeEmotionUI : MonoBehaviour
{
    public static LYJ_OnClickDislikeEmotionUI Instance;
    public Animator playerAnim;
    private GameObject player;
    private Quaternion fstPlayerRot;
    private Camera cam;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }
    
    public Animator disLikeAnim;
    private bool canCount;

    public GameObject curBuilding;
    
    // Start is called before the first frame update
    void Start()
    {
        canCount = true;
        player = playerAnim.transform.root.gameObject;

        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // print("loveClickCount: " + loveClickCount);
    }

    private void OnMouseEnter()
    {
        Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
        fstPlayerRot = player.transform.rotation;
        
        player.GetComponent<_PlayerMove>().enabled = false;
        disLikeAnim.enabled = true;
        playerAnim.SetBool("Dislike", true);
        
    }

    private void OnMouseExit()
    {
        Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
        player.transform.rotation = fstPlayerRot;
        disLikeAnim.enabled = false;
        playerAnim.SetBool("Dislike", false);
        playerAnim.SetTrigger("Idle");
        player.GetComponent<_PlayerMove>().enabled = true;
    }
    
    private float curTime;
    private void OnMouseOver()
    {
        curTime += Time.deltaTime;
        curTime = Mathf.Clamp(curTime, 0, 1);
        cam.fieldOfView = Mathf.Lerp(60, 36.6f, curTime);
        
        player.transform.rotation = Quaternion.Lerp(player.transform.rotation, Quaternion.Euler(0, 180, 0), 0.1f);
    }
    
    private void OnMouseDown()
    {
        Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
        print(canCount);
        if (canCount)
        {
            canCount = false;
            disLikeAnim.enabled = false;
            /*
            LYJ_OnClickLoveEmotionUI.Instance.curBuilding.GetComponentInChildren<DetailedInformation>().dislikeCount++;
            LYJ_OnClickLoveEmotionUI.Instance.curBuilding.GetComponentInChildren<DetailedInformation>().dislikeCountTxt.text =
            LYJ_OnClickLoveEmotionUI.Instance.curBuilding.GetComponentInChildren<DetailedInformation>().dislikeCount.ToString();
            */
        }
    }
    
    private void OnMouseUp()
    {
        Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
    }
}
