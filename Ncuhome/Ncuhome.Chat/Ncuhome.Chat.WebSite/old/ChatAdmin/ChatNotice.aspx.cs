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
using nbyd.CheckLog;
using nbyd.DataAccess;


public partial class ChatAdmin_ChatNotice : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Check.CheckAdminSession();
        if (!Page.IsPostBack)
        {
            Editor1.Text = DataAccess.chat.notice();
            Editor2.Text = DataAccess.chat.noticeinside();
            Editor3.Text = DataAccess.chat.noticeinside2();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["HomeChatConnectionString"].ToString());
        SqlCommand cmd = conn.CreateCommand();
        cmd.CommandText = "UPDATE [chat] SET notice=@notice,notice_inside=@notice_inside,notice_inside2=@notice_inside2 WHERE ID=@ID";
        cmd.Parameters.AddWithValue("@notice",Editor1.Text);
        cmd.Parameters.AddWithValue("@notice_inside", Editor2.Text);
        cmd.Parameters.AddWithValue("@notice_inside2", Editor3.Text);
        cmd.Parameters.AddWithValue("@ID",Session["chatnum"].ToString());
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        Response.Write("<script>alert('成功');</script>");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("manage.aspx");
    }
}
