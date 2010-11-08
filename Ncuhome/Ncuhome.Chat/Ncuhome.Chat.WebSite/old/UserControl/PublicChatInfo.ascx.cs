using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using Ncuhome.ChatRoom.DBHelper;
using nbyd.DataAccess;
public partial class UserControl_PublicChatInfo : System.Web.UI.UserControl
{
    private int currentId = -1;
    private int chatNumber = -1;
    protected void Page_Load(object sender, EventArgs e)
    {
        BindData();
    }

    private void BindData()
    {
        currentId = Convert.ToInt32(Request.QueryString["cid"]);
        chatNumber = Convert.ToInt32(Request.QueryString["cnum"]);

        SqlDataReader dr = DataAccess.ChatInfo.GetPublicChat(currentId, chatNumber);
        PublicChat.DataSource = dr;
        PublicChat.DataBind();
        dr.Close();
    }



   
}
