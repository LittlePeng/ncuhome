using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

/// <summary>
/// Replace 的摘要说明
/// </summary>
/// 
namespace nbyd.Replace
{
    public class Replace
    {
        public Replace()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        public static string ChatReplace(string chat)
        {
            SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["HomeChatConnectionString"].ToString());
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT Replace,ReplaceTo FROM Replace";
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                chat = chat.Replace(dr[0].ToString().Trim(), dr[1].ToString().Trim());
            }
            dr.Close();
            conn.Close();
            return chat;
        }
    }
}