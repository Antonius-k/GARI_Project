using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LoginManager : MonoBehaviour
{
    public InputField _id;
    public InputField _pw;
    //public Button loginBtn;


    string id;
    string pw;

    Demo_1 demo_1;

    private void Start()
    {
        demo_1 = new Demo_1();
    }
    public void OnClickLogin()
    {
        id = _id.text;
        pw = _pw.text;
        
        //DB ������ ���̵�, �н����� �´��� ã����
        
        //�α��� ����
        if(AccountManager.Login(id, pw))
        {
            //���� �������� �Ѱ���
            demo_1.Button3();
            Debug.Log("�α��� ����");
        }
        //�α��� ����
        else
        {
            //�ٽ� �α��� �г� �ϳ� �������
            demo_1.Button4();
            Debug.Log("�α��� ����");
        }
    }

    //ȸ������ ��ư 
    public void OnClickSingUp()
    {
        id = _id.text;
        pw = _pw.text;
        

        //���ο� ȸ������ �г� ������ְ� ����ְ� ������ ���ְ�
        //��� ���̵� �н����� üũ�ؼ� Ȯ������
        if (AccountManager.SignUp(id, pw))
        {
            //�Ϸ� �г� �������
            demo_1.Button4();
            Debug.Log("ȸ�������� �Ϸ� �Ǿ����ϴ�.");
        }
        else
        {
            //���� �г� �������
            demo_1.Button3();
            Debug.Log("ȸ������ ����");
        }
    }
}