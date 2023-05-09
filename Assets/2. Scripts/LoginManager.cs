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
        
        //DB 뒤져서 아이디, 패스워드 맞는지 찾아줌
        
        //로그인 성공
        if(AccountManager.Login(id, pw))
        {
            //다음 페이지로 넘겨줘
            demo_1.Button3();
            Debug.Log("로그인 성공");
        }
        //로그인 실패
        else
        {
            //다시 로그인 패널 하나 만들어줘
            demo_1.Button4();
            Debug.Log("로그인 실패");
        }
    }

    //회원가입 버튼 
    public void OnClickSingUp()
    {
        id = _id.text;
        pw = _pw.text;
        

        //새로운 회원가입 패널 만들어주고 띄워주고 기존꺼 꺼주고
        //디비에 아이디 패스워드 체크해서 확인해줌
        if (AccountManager.SignUp(id, pw))
        {
            //완료 패널 만들어줘
            demo_1.Button4();
            Debug.Log("회원가입이 완료 되었습니다.");
        }
        else
        {
            //실패 패널 만들어줘
            demo_1.Button3();
            Debug.Log("회원가입 실패");
        }
    }
}