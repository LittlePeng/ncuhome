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
using nbyd.CheckLog;

public partial class ChatAdmin_NewChat : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Check.CheckAdminSession();
       
    }

    //protected string GetCurrentId()
    //{
    //    string sql = "select top 1 ID from dbo.ChatInfo where ID > (select top 1 ID from dbo.ChatInfo where IsSended=1 order by Id desc) order by ID ASC";
    //}
}
