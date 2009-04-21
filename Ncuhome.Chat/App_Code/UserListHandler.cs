using System;
using System.Data;
using System.IO;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for UserList
/// </summary>
public class UserListHandler:IHttpHandler
{
    public UserListHandler()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    Page _page;
    public bool IsReusable
    {
        get { throw new NotImplementedException(); }
    }

    public void ProcessRequest(HttpContext context)
    {
        if (context.Request.QueryString["mode"].ToLower() == "user")
        {
            GetUserList(context);
        }
        if (context.Request.QueryString["mode"].ToLower() == "guest")
        {
            GetGuestList(context);
        }
    }

    private void GetUserList(HttpContext context)
    {
        string path = "~/UserControl/UserList.ascx";
        context.Response.Write(LoadControl(path, context));
    }

    private void GetGuestList(HttpContext context)
    {
        string path = "~/UserControl/GuestList.ascx";
        context.Response.Write(LoadControl(path, context));
    }


    private string LoadControl(string path, HttpContext context)
    {
        var temp = HttpRuntime.Cache[path];
        if (temp != null)
        {
            return ""+temp.ToString();
        }
        else
        {
            _page = new Page();
            StringWriter sw = new StringWriter();

            UserControl uc = _page.LoadControl(path) as UserControl;

            _page.Controls.Add(uc);
            context.Server.Execute(_page, sw, true);

            string PageHTML = sw.ToString();
            HttpRuntime.Cache.Insert(path, PageHTML, null, DateTime.Now.AddMilliseconds(500), TimeSpan.Zero);
            return PageHTML;
        }
    }
}
