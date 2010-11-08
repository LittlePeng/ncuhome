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
using nbyd.DataAccess;
using nbyd;
using nbyd.CheckReg;

public partial class GuestLogin : System.Web.UI.Page
{
 protected void Page_Load(object sender, EventArgs e)
    {
        TextBox_Username.Attributes.Add("onkeydown", "SubmitKeyClick('Button1')");
        if (!DataAccess.chat.IsOpen())
        {
            Literal1.Text = "<span style=\"color:red;\">【聊天室稍候开放】开放时间：每周五晚上 19：00-21：00</span>";
            Literal1.Text = Literal1.Text +"<br />"+ nbyd.DataAccess.DataAccess.chat.notice();
            Panel_login.Enabled = false;
        }
        else
        {
            Literal1.Text = "<span style=\"color:red;\">【聊天室已开放】开放时间：每周五晚上 19：00-21：00</span><br/>";
            Literal1.Text += DataAccess.chat.notice();
        }
    }
 protected void Button1_Click(object sender, EventArgs e)
 {


     SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["HomeChatConnectionString"].ToString());
     SqlCommand cmd2 = con.CreateCommand();
     cmd2.CommandText = "SELECT * FROM [User] WHERE Username=@Name and userpwd=@pwd";
     cmd2.Parameters.AddWithValue("@Name", TextBox_Username.Text.Trim());
     cmd2.Parameters.Add("@pwd", txtPwd.Text);
     con.Open(); 
     SqlDataReader dr1 = cmd2.ExecuteReader();
     if (dr1.Read())
     {
         SaveCookie(TextBox_Username.Text.Trim());
         DataAccess.user.UserReg(Convert.ToInt64(DataAccess.user.UserID(TextBox_Username.Text)));
         GetRealIP();
         Response.Redirect("chat.aspx");
     }
     else
     {
         Response.Write("<script>alert('用户名或密码错误')</script>");
     }
     dr1.Close();
     con.Close();
 }
    public static void GetRealIP()
    {
        string ip;
        try
        {
            HttpRequest request = HttpContext.Current.Request;

            if (request.ServerVariables["HTTP_VIA"] != null)
            {
                ip = request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString().Split(',')[0].Trim();
            }
            else
            {
                ip = request.UserHostAddress;
            }
        }
        catch (Exception e)
        {
            throw e;
        }

        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["HomeChatConnectionString"].ToString());
        SqlCommand cmd = conn.CreateCommand();
        conn.Open();
        cmd.CommandText = "UPDATE [user] SET ip=@ip WHERE username=@username";
        cmd.Parameters.AddWithValue("@ip", ip);
        cmd.Parameters.AddWithValue("@username",  HttpContext.Current.Request.Cookies["ChatName"].Value);
        cmd.ExecuteNonQuery();
        conn.Close();
    }

    protected void SaveCookie(string username)
    {
        if (Request.Cookies["ChatName"] == null)
        {
            Response.Cookies.Add(new HttpCookie("ChatName",Server.UrlEncode(username)));
        }
        else
        {
            Response.Cookies["ChatName"].Value = Server.UrlEncode(username);
        }
        
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["HomeChatConnectionString"].ToString());
        SqlCommand cmd1 = conn.CreateCommand();
        conn.Open();
        cmd1.CommandText = "UPDATE [user] SET IsOnline=1 WHERE UserName=@name";
        cmd1.Parameters.AddWithValue("@name", username);
        cmd1.ExecuteNonQuery();
        conn.Close();
    }
}
