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
using nbyd;
using nbyd.DataAccess;
using AjaxControlToolkit;
using nbyd.CheckLog;
using nbyd.Replace;


public partial class newpage_chat : System.Web.UI.Page
{
    string _userName = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        
        Literal_public.Text = DataAccess.chat.noticeinside2();//横向滚动公告
        _userName = Server.UrlDecode(Request.Cookies["ChatName"].Value);
  
        LinkButton4.Text ="  退出";
        UserName.Text = "用户名:" + _userName;

        chatNumber.Value = nbyd.DataAccess.DataAccess.chat.ID();
        this.sender.Value = _userName;
        liUserID.Text = nbyd.DataAccess.DataAccess.user.UserID(_userName.Trim());
    }

    
    protected void Button2_Click(object sender, EventArgs e)
    {
        _userName = HttpContext.Current.Request.Cookies["ChatName"].Value;
        nbyd.CheckLog.UserLogin.LoginOut(_userName);
        Request.Cookies.Clear();
        Response.Cookies.Clear();
        Response.Redirect("login.aspx");
    }

}
