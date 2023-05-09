using System.Collections;
using System.Collections.Generic;


public static class AccountManager
{
    static string DB_USERINFO = Encoder.Decode("dXNlcmluZm8=");

    public static string id;
    public static bool isLogined;

    public static bool Login(string _id, string _passwd)
    {
        string query = string.Format("SELECT * FROM " + DB_USERINFO + " WHERE id = '{0}' AND passwd = '{1}';", _id, Encoder.Encode(_passwd));
        List<Dictionary<string, object>> result = DBManager.Select(query);

        isLogined = (0 < result.Count);

        if (isLogined)
        {
            id = _id;
        }
        else
        {
            id = null;
        }

        return isLogined;
    }

    public static void Logout()
    {
        id = null;
        isLogined = false;
    }

    //회원가입
    public static bool SignUp(string _id, string _passwd)
    {
        //데이터베이스 언어 쿼리
        string query = string.Format("INSERT INTO " + DB_USERINFO + " VALUES('{0}', '{1}');", _id, Encoder.Encode(_passwd));
        
        return DBManager.Execute(query);
        
    }

    //쿼리 날려서 id값 찾아오기
    public static bool Update(string _passwd)
    {
        if (id == null)
        {
            return false;
        }
        string query = string.Format("UPDATE " + DB_USERINFO + " SET passwd = '{0}' WHERE id = '{2}';", Encoder.Encode(_passwd), id);
        
        return DBManager.Execute(query);
    }
}
