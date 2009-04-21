using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;

/// <summary>
///ChatList 的摘要说明
/// </summary>
public class ChatList:IHttpHandler
{
	public ChatList()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    #region IHttpHandler 成员

    public bool IsReusable
    {
        get { throw new NotImplementedException(); }
    }

     public void ProcessRequest(HttpContext context)
    {
        GetList(context);
    }

#endregion

    public void GetList(HttpContext context)
    {
        string path = "UserControl/ChatList.ascx";
        context.Response.Write(LoadControl(path, context));
    }

    public string LoadControl(string path, HttpContext context)
    { 
        Page pg = new Page();
        StringWriter sw = new StringWriter();
        UserControl uc = pg.LoadControl(path) as UserControl;
        pg.Controls.Add(uc);
        context.Server.Execute(pg, sw, true);
        return sw.ToString();
    }
    
}
