using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

public partial class UserControl_ChatList : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //int id = int.Parse(Request["currentId"].ToString());
        Repeater1.DataSource = GetBind();
        Repeater1.DataBind();
    }

    protected DataSet GetBind()
    {
        SqlConnection conn = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["HomeChatConnectionString"].ToString());
        SqlCommand cmd = conn.CreateCommand();
        cmd.CommandText = "GetChatList";
        //cmd.Parameters.AddWithValue("@currentId", id);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = conn;
        DataSet ds = new DataSet();
        conn.Open();
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        sda.Fill(ds);     
        conn.Close();

        return ds;
    }

    protected string ShowP(object a)
    {
     string s=(a.ToString()=="True") ? "<b>私</b>":"公";
     return s;
    }
}
