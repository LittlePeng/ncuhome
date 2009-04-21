using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class ChatAdmin_Kick : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedValue != "大家")
        {
            SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["HomeChatConnectionString"].ToString());
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "insert into kickedUser (UserName,Reason) values(@name,@Reason) update [user] set IsOnline=0 where username=@name";
            cmd.Parameters.AddWithValue("@name", DropDownList1.SelectedValue);
            cmd.Parameters.AddWithValue("@Reason", txtReason.Text);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            DropDownList1.DataBind();
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Manage.aspx");
    }
}
