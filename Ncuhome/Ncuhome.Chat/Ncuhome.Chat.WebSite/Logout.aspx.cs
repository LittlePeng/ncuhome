using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Ncuhome.Chat.Core;

public partial class Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Login.Instance.CheckLogOut();
        Response.Redirect("Default.aspx");
    }
}