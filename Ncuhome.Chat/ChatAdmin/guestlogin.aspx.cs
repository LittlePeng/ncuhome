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
using nbyd.CheckLog;


public partial class ChatAdmin_guestlogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["UserName"] == null && HttpContext.Current.Request.Cookies["UserName"] != null)
        {
            HttpContext.Current.Session["UserName"] = Server.UrlEncode(HttpContext.Current.Request.Cookies["UserName"].Value);
        }
        Check.CheckAdminSession();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["HomeChatConnectionString"].ToString());
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandText = "SELECT USERID FROM [User] WHERE Username=@Name";
        cmd.Parameters.AddWithValue("@Name", TextBox1.Text);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();

        if (dr.Read())
        {
            Int64 ID = Convert.ToInt64(DataAccess.user.UserID(TextBox1.Text));
            if (TextBox2.Text == DataAccess.user.UserPWD(ID))
            {
                DataAccess.user.UserReg(ID);
                SaveCookie(TextBox1.Text);
                GetRealIP();
                dr.Close();
                con.Close();
                Response.Redirect("../chat.aspx");
            }
            else
            {
                FuncCommon.MsgDialog("用户名或密码不正确");
            }
        }
        else
        {
            SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["HomeChatConnectionString"].ToString());
            SqlCommand cmd1 = conn.CreateCommand();
            conn.Open();
            cmd1.CommandText = "INSERT INTO [user] (UserName,UserPWD,UserSex,IsOnline,guest) VALUES (@name,@pwd,'性别保密',1,1)";
            cmd1.Parameters.AddWithValue("@name", TextBox1.Text);
            cmd1.Parameters.AddWithValue("@pwd", TextBox2.Text);
            cmd1.ExecuteNonQuery();
            conn.Close();
            Response.Write("<script>alert('添加成功')</script>");
        }

        dr.Close();
        con.Close();
    }

    public void GetRealIP()
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
        cmd.CommandText = "UPDATE [user] SET ip=@ip,guest=1 WHERE username=@username";
        cmd.Parameters.AddWithValue("@ip", ip);
        cmd.Parameters.AddWithValue("@username", Server.UrlDecode(Request.Cookies["ChatName"].Value));
        cmd.ExecuteNonQuery();
        conn.Close();

    }

    protected void SaveCookie(string username)
    {
        if (Request.Cookies["ChatName"] == null)
        {
            Response.Cookies.Add(new HttpCookie("ChatName", Server.UrlEncode(username)));
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
