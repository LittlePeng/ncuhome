using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Ncuhome.Blog.Core.HTTPModules
{
    public  class SummaryVisitModule: System.Web.IHttpModule
    {


        public void Dispose()
        {
           
        }

        public void Init(System.Web.HttpApplication application)
        {
            application.UpdateRequestCache += (new EventHandler(this.Application_BeginRequest));
            application.EndRequest += (new EventHandler(this.Application_EndRequest));
        }
        private void Application_BeginRequest(Object source, EventArgs e)
        {

            HttpApplication application = (HttpApplication)source;
            HttpContext context = application.Context;
            string Url;
            if (context.Request.Url == null)
                Url = "";
            else
                Url = context.Request.Url.AbsoluteUri.ToString();//获取当前页的url 地址
            string FromUrl;
            if (context.Request.UrlReferrer == null)
                FromUrl = "";
            else
                FromUrl = context.Request.UrlReferrer.AbsoluteUri.ToString();//获取跳转前的url 地址 
            string IP;
            if (context.Request.UserHostAddress == null)
                IP = "";
            else
                IP = Ncuhome.Blog.Core.Globals.IPAddress;

            int ID = 0;
            int str = Url.LastIndexOf(".");////请求 每调用一个webservice 方法 就请求一次,还有一个css也会请求一次.....这个方法取消不必要的请求
            if (Url.Length >= str + 4)
            {
                string Format = Url.Substring(str + 1, 3).ToString();
                if (Format == "asp" || Format == "htm")//得到aspx,asp,html,htm 的页面
                {
                    Ncuhome.Blog.Core.SummaryVisit Sum = new SummaryVisit();
                    int BloguserID=-1;
                  if(Ncuhome.Blog.Core.BlogContext.Current.User.IsLogin)
                      BloguserID=Ncuhome.Blog.Core.BlogContext.Current.User.BlogUserID;
                    Sum.AddVisitLog(BloguserID, Url, FromUrl, IP);
                }
            }

        }

        private void Application_EndRequest(Object source, EventArgs e)
        {

        }

    }
}
