using System;
using System.IO;
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

/// <summary>
/// Summary description for ChatInfoHandler
/// </summary>
public class ChatInfoHandler:IHttpHandler
{

    private Page _page;
	
    public ChatInfoHandler()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    

    bool IHttpHandler.IsReusable
    {
        get { return false; }
    }

    void IHttpHandler.ProcessRequest(HttpContext context)
    {
        if (context.Request.QueryString["mode"].ToLower() == "public")
        {
            GetPublicInfo(context);
        }
        if (context.Request.QueryString["mode"].ToLower() == "private")
        {
            GetPrivateInfo(context);
        }
    }
    //公聊窗口设置0.5秒的缓存
    private void GetPublicInfo(HttpContext context)
    {
        string path = "~/UserControl/PublicChatInfo.ascx";
        var temp= HttpRuntime.Cache["PublicChatInfo"];
        if (temp != null)
             context.Response.Write( "" + temp.ToString());
        else
        {
            string PublicChatHtml = LoadControl(path, context);
            HttpRuntime.Cache.Insert("PublicChatInfo", PublicChatHtml, null, DateTime.Now.AddMilliseconds(500), TimeSpan.Zero);
            context.Response.Write(PublicChatHtml);
        }
    }

    private void GetPrivateInfo(HttpContext context)
    {
        string path = "~/UserControl/PrivateChatInfo.ascx";
        context.Response.Write(LoadControl(path, context));
    }

    private string LoadControl(string path,HttpContext context)
    {
        _page = new Page();
        StringWriter sw = new StringWriter();

        UserControl uc = _page.LoadControl(path) as UserControl;

        _page.Controls.Add(uc);
        context.Server.Execute(_page, sw, true);

        return sw.ToString();
    }

    
}
