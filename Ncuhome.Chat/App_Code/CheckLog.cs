using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using nbyd.DataAccess;
using nbyd;
using System.Data.SqlClient;

/// <summary>
/// CheckLog 的摘要说明
/// </summary>
/// 
namespace nbyd.CheckLog
{
    public class CheckLog
    {
        public CheckLog()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
    }
    public class Check
    {
        public static bool CheckUserSession()
        {
            if (HttpContext.Current.Request.Cookies["UserName"] == null)
            {
                HttpContext.Current.Response.Redirect("login.aspx");
                return false;
            }
            return true;
            //else
            //{
            //    try
            //    {

            //        if (!DataAccess.DataAccess.user.IsOnline(Convert.ToInt64(DataAccess.DataAccess.user.UserID(HttpContext.Current.Request.Cookies["UserName"].ToString()))))
            //        {
            //            HttpContext.Current.Response.Redirect("login.aspx");
            //            return false;
            //        }
            //        else
            //        {
            //            return true;
            //        }
            //    }
            //    catch
            //    {
            //        HttpContext.Current.Response.Redirect("login.aspx");
            //        return false;
            //    }
            //}

        }
        public static bool CheckAdminSession()
        {
            if (HttpContext.Current.Session["AdminName"] == null && HttpContext.Current.Request.Cookies["AdminName"] == null)
            {
                HttpContext.Current.Response.Redirect("Default.aspx");
                return false;
            }
            else
            {
                return false;
            }
        }

    }
    public class UserLogin
    {
        /// <summary>
        /// 安全退出
        /// </summary>
        /// <param name="UserName"></param>
        public static void LoginOut(string UserName)
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["HomeChatConnectionString"].ToString());
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE [User] SET IsOnline=0 WHERE UserName=@name";
            cmd.Parameters.AddWithValue("@name",UserName);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}