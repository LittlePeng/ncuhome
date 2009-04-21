
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;

public partial class logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["HomeChatConnectionString"].ToString());
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandText = "UPDATE [user] SET IsOnline=0 WHERE UserName=@name";
        cmd.Parameters.Add("@name", Server.UrlDecode(Request.Cookies["ChatName"].ToString()));
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        if (Request.QueryString["user"] != null)
        {
            string sql = "delete from kickeduser where username=@username";
            SqlParameter pa = new SqlParameter("@username", Request.QueryString["user"]);
            Ncuhome.ChatRoom.DBHelper.DBHelper.ExecuteNonQuery(Ncuhome.ChatRoom.DBHelper.DBHelper.HomeChatConnectionString, CommandType.Text, sql, pa);
        }

        Response.Redirect("login.aspx");

    }
}
