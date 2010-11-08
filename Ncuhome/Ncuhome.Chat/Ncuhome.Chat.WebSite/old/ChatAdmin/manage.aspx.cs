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
using nbyd;
using nbyd.DataAccess;
using nbyd.CheckLog;
using System.Data.SqlClient;
using AjaxControlToolkit;
public partial class ChatAdmin_manage1 : System.Web.UI.Page
{
    string chatnum = nbyd.DataAccess.DataAccess.chat.ID();
    protected void Page_Load(object sender, EventArgs e)
    {
        Check.CheckAdminSession();

        if (DataAccess.chat.IsOpen())
        {
            Button4.Text = "关闭聊天室";
        }
        else
        {
            Button4.Text = "开启聊天室";
        }

    }


    protected void Button3_Click(object sender, EventArgs e)
    {
        FuncCommon.GoToURL("OrgChat.aspx");
    }
    protected void Button4_Click(object sender, EventArgs e)//开启或关闭聊天室
    {            

	if (!DataAccess.chat.IsOpen())
        {
            SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["HomeChatConnectionString"].ToString());
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE [chat] SET isopen=0;UPDATE [chat] SET IsOpen=1 WHERE id=@id";
            cmd.Parameters.AddWithValue("@id", chatnum);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
		    Application["IsOpen"] = 1;    
            Response.Redirect("manage.aspx");
        }
        else
        {
            SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["HomeChatConnectionString"].ToString());
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE [chat] SET IsOpen=0 delete from KickedUser";
            cmd.Parameters.AddWithValue("@id", chatnum);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            cmd.CommandText = "UPDATE [user] SET IsOnline=0 WHERE UserID<>1";//UserID=1的是用户名为‘大家’的用户，将永远开启
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
		    Application["IsOpen"] = 0;
            Response.Redirect("manage.aspx");
        }
        
    }
    protected void Button5_Click(object sender, EventArgs e)//开始一次新的聊天主题
    {
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["HomeChatConnectionString"].ToString());
        SqlCommand cmd = conn.CreateCommand();
        cmd.CommandText = "update chat set isopen=0;INSERT INTO [chat] (Notice,notice_inside) values ('Welcome to ncuhome chatroom','welcome')";
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        int temp = int.Parse(Session["chatnum"].ToString());
        temp++;
        Session["chatnum"] = temp;
        Response.Redirect("ChatNotice.aspx");

    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        Response.Redirect("ChatNotice.aspx");
    }
    protected void Button_Pub_OnClick(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["HomeChatConnectionString"].ToString());
        SqlCommand cmd = conn.CreateCommand();
        cmd.CommandText = "INSERT INTO [PublicTale] (PublicTale,ChatNum) values (@PublicTale,@chatnum)";
        cmd.Parameters.AddWithValue("@PublicTale", "<font style='color:red'>" + TextBox_PublicTale.Text + "</font>");
        cmd.Parameters.AddWithValue("@chatnum", chatnum);
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        TextBox_PublicTale.Text = "";
    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        Response.Redirect("RegName.aspx");
    }
    protected void Button8_Click(object sender, EventArgs e)
    {
        Response.Redirect("ChatReplace.aspx");
    }
    protected void Button9_Click(object sender, EventArgs e)
    {
        Response.Redirect("Gbook.aspx");
    }
   
   
    protected void Button10_Click(object sender, EventArgs e)
    {
        Response.Redirect("Org.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Kick.aspx");
    }

    protected void Button11_Click(object sender, EventArgs e)
    {

        Response.Redirect("guestlogin.aspx");
    }
   
 
}
