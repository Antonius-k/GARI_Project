using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _PlayerTeleport : MonoBehaviour
{
    public Transform go;
    public AudioSource ass;
   
    _PlayerMove _pm;
    //public Transform Cam;

    float x;
    float y;

    void Start()
    {
        
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    GyeonggiTel();
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha2))
        //{
        //    KangwonTel();
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha3))
        //{
        //    JejuTel();
        //}
    }

    void GoGo()
    {
        go = GameObject.Find("Player(Clone)").transform;
        _pm = go.GetComponent<_PlayerMove>();
    }

    public void GyeonggiTel()
    {
        GoGo();

        x = -237.13f;
        y = 1224.03f;

        StartCoroutine(PlayerTeleport());
    }

    public void KangwonTel()
    {
        GoGo();

        x = 753.26f;
        y = 1477.19f;

        StartCoroutine(PlayerTeleport());
    }

    public void ChungbukTel()
    {
        GoGo();

        x = 210.64f;
        y = 902.3f;

        StartCoroutine(PlayerTeleport());
    }
    public void ChungnamTel()
    {
        GoGo();

        x = -529.46f;
        y = 813.95f;

        StartCoroutine(PlayerTeleport());
    }
    public void KyeongbukTel()
    {
        GoGo();

        x = 700.85f;
        y = 640.45f;

        StartCoroutine(PlayerTeleport());
    }
    public void KyeongnamTel()
    {
        GoGo();

        x = 428.87f;
        y = -406.92f;

        StartCoroutine(PlayerTeleport());
    }
    public void JeonbukTel()
    {
        GoGo();

        x = -191.2f;
        y = 80.85f;

        StartCoroutine(PlayerTeleport());
    }
    public void JeonnamTel()
    {
        GoGo();

        x = -246;
        y = -455;

        StartCoroutine(PlayerTeleport());
    }
    public void JejuTel()
    {
        GoGo();

        x = -540;
        y = -1630.5f;

        StartCoroutine(PlayerTeleport());
    }
    public void UleungTel()
    {
        GoGo();

        x = 1922.62f;
        y = 1281;

        StartCoroutine(PlayerTeleport());
    }
    public void SeoulTel()
    {
        GoGo();

        x = -286.63f;
        y = 1318.97f;

        StartCoroutine(PlayerTeleport());
    }
    public void IncheonTel()
    {
        GoGo();

        x = -441.57f;
        y = 1281.8f;

        StartCoroutine(PlayerTeleport());
    }
    public void SejongTel()
    {
        GoGo();

        x = -113.18f;
        y = 584.25f;

        StartCoroutine(PlayerTeleport());
    }
    public void DaejeonTel()
    {
        GoGo();

        x = -59.56f;
        y = 490.90f;

        StartCoroutine(PlayerTeleport());
    }
    public void DaeguTel()
    {
        GoGo();

        x = 636.11f;
        y = 157.54f;

        StartCoroutine(PlayerTeleport());
    }
    public void KwangjuTel()
    {
        GoGo();

        x = -362.3f;
        y = -351.43f;

        StartCoroutine(PlayerTeleport());
    }
    public void UlsanTel()
    {
        GoGo();

        x = 1038.02f;
        y = -76.95f;

        StartCoroutine(PlayerTeleport());
    }
    public void BusanTel()
    {
        GoGo();

        x = 902.80f;
        y = -322.234f;

        StartCoroutine(PlayerTeleport());
    }

    IEnumerator PlayerTeleport()
    {
        GoGo();

        //ass.Play();

        _pm.enabled = false;
        go.position = new Vector3(x, 100, y);

        yield return new WaitForSeconds(0.5f);

        _pm.enabled = true;
    }
}
