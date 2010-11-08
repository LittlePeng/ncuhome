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
public partial class UserControl_UserList : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        BindData();
    }

    private void BindData()
    {
        SqlDataReader dr = DataAccess.user.GetOnlineUserList();
        UserList.DataSource = dr;
        UserList.DataBind();

        dr.Close();
    }
}
