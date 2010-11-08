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
using nbyd.DataAccess;
public partial class UserControl_PrivateChatInfo : System.Web.UI.UserControl
{
    private int currentId = -1;
    private int chatNumber = -1;
    string sender = "";
    string sendto = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        BindData();
    }

    private void BindData()
    {
        chatNumber = Convert.ToInt32(Request.QueryString["cnum"]);
        //sendto = Server.UrlDecode(Request.QueryString["sendto"]);
        //sender = Server.UrlDecode(Request.QueryString["sender"]);
        sendto = Server.UrlDecode(Request.Cookies["ChatName"].Value);
        sender = Server.UrlDecode(Request.Cookies["ChatName"].Value);
        //Response.Write(sendto + "-" + sender + "-" + Request.QueryString["userid"]);
        //Response.End();

        SqlDataReader dr = DataAccess.ChatInfo.GetPrivateChat(chatNumber, sendto, sender);
        PrivateChat.DataSource = dr;
        PrivateChat.DataBind();
        dr.Close();
    }
}
