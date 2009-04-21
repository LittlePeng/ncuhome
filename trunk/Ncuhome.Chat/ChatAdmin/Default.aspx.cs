using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using nbyd;
using nbyd.DataAccess;

public partial class ChatAdmin_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["HomeChatConnectionString"].ToString());
        conn.Open();
        SqlCommand cmd = conn.CreateCommand();
        cmd.CommandText = "SELECT COUNT(*) FROM [admin] WHERE AdminName=@name and AdminPWD=@password";
        cmd.Parameters.AddWithValue("@name",TextBox1.Text);
        cmd.Parameters.AddWithValue("@password",TextBox2.Text);
        SqlDataReader dr = cmd.ExecuteReader();
        dr.Read();
        if (dr[0].ToString() == "0")
        {
            FuncCommon.MsgDialog("用户名或密码错误");
        }
        else
        {
            dr.Close();
            conn.Close();
            SaveSession(TextBox1.Text);
            dr.Close();
            conn.Close();
            Response.Redirect("manage.aspx");
        }
        dr.Close();
        conn.Close();
    }
    protected void SaveSession(string adminname)
    {
        Session["AdminName"] = adminname;
        HttpCookie ck = new HttpCookie("AdminName", adminname);
        Response.AppendCookie(ck);
        Session["chatnum"] = DataAccess.chat.ID();
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["HomeChatConnectionString"].ToString());
        SqlCommand cmd1 = conn.CreateCommand();
        conn.Open();
        cmd1.CommandText = "UPDATE [user] SET IsOnline=1 WHERE UserName=@name";
        cmd1.Parameters.AddWithValue("@name", adminname);
        cmd1.ExecuteNonQuery();
        conn.Close();
    }
}
 