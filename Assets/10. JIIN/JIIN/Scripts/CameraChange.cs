using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    // �� ī�޶�
    public GameObject top;
    // �÷��̾� �� ī�޶� // CamPos
    public GameObject back;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // ���� ���� 1�� Ű�� ������ �� 
        if (Input.GetKey(KeyCode.Alpha1))
        {
            // �÷��̾� �� ī�޶� �ѱ�
            top.SetActive(false);

            back.SetActive(true);
        }
        // ���� ���� 2�� Ű�� ������ �� 
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            back.SetActive(false);

            // �� ī�޶� �ѱ�
            top.SetActive(true);
        }
       
    }
}
