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
/// CheckReg 的摘要说明
/// </summary>
/// 

namespace nbyd.CheckReg
{
    public class CheckReg
    {
        public CheckReg()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        /// <summary>
        /// 检查用户注册名(注册名不可用返回false ,否则返回true)
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public static bool CheckRegName(string UserName)
        {
            SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["HomeChatConnectionString"].ToString());
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM [RegName] WHERE RegName=@UserName";
            cmd.Parameters.AddWithValue("@UserName", UserName);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            bool temp = !dr.HasRows;
            dr.Close();
            conn.Close();
            return temp;
        }
    }
}