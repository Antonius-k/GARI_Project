using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using UnityEngine;
using System.Text;

//GB DB
public static class DBManager
{
    static string SERVER =  Encoder.Decode("d3d3NS5keW51Lm5ldA==");
    static string PORT = Encoder.Decode("NTYwMzM=");
    static string database = Encoder.Decode("YXJhcg==");
    static string userid = Encoder.Decode("YXJhcg==");
    static string passwd = Encoder.Decode("YXJhcg==");
    static string connInfo = "Server=" + SERVER + ";Port=" + PORT + ";Database=" + database + ";User Id=" + userid + ";Password=" + passwd + "";
    
    static MySqlConnection conn;

    static string ConvertUtf8(string data)
    {
        byte[] source = Encoding.UTF8.GetBytes(data);
        return Encoding.UTF8.GetString(source);
    }




    static void Connect()
    {
        connInfo = ConvertUtf8(connInfo);

        // Debug.Log("connection prepare!");
        conn = new MySqlConnection(connInfo);
        conn.Open();
        // Debug.Log("connection start!");
    }

    static void Disconnect()
    {
        conn.Close();
        conn = null;
    }
    
    //삽입, 갱신, 삭제 쿼리
    public static bool Execute(string query)
    {
        Connect();

        MySqlCommand command = new MySqlCommand(query, conn);

        int rows = command.ExecuteNonQuery();

        Disconnect();

        return 0 < rows;
    }

    //찾아오는 쿼리
    public static List<Dictionary<string, object>> Select(string query)
    {
        //Debug.Log($"table: , adaptor: ");
        Connect();

        DataTable dt = new DataTable();

        MySqlDataAdapter adapter =  new MySqlDataAdapter(query, conn);

        //Debug.Log($"table: {dt != null}, adaptor: {adapter != null}");

        adapter.Fill(dt);

        Disconnect();

        return Simplify(dt);
    }


    static List<Dictionary<string, object>> Simplify(DataTable dt)
    {
        List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
        
        for (int i = 0; i < dt.Rows.Count; ++i)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();

            for (int j = 0; j < dt.Columns.Count; ++j)
                dict[dt.Columns[j].ColumnName] = dt.Rows[i][j];

            list.Add(dict);
        }

        return list;
    }
}
