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

public partial class History : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string sql = "SELECT [Sender], [SendTo], [content],[TextColor],[time],[CheckTime] FROM [ChatInfo] WHERE (([IsSended] = 1) AND ([IsPrivate] = 0) AND ([ChatNum] = "+nbyd.DataAccess.DataAccess.chat.ID()+")) ORDER BY CheckTime DESC";
        PublicChatDataSource.SelectCommand = sql;
    }
}
