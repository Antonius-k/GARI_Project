using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignupManager : MonoBehaviour
{
    public InputField _id;
    public InputField _pw;
    
    string id;
    string pw;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    //회원가입 버튼 
    public void OnClickSignUp()
    {
        id = _id.text;
        pw = _pw.text;
        

        //새로운 회원가입 패널 만들어주고 띄워주고 기존꺼 꺼주고
        //디비에 아이디 패스워드 체크해서 확인해줌
        if (AccountManager.SignUp(id, pw))
        {
            AccountManager.Login(id, pw);


            //완료 패널 만들어줘
            UIManager.Instance.ShowSignupUI(false);
            UIManager.Instance.ShowPopupCompleteUI(true);
            Debug.Log("회원가입이 완료 되었습니다.");
        }
        else
        {
            //실패 패널 만들어줘
            UIManager.Instance.ShowPopupFailUI(true);
            Debug.Log("회원가입 실패");
        }
    }
}
