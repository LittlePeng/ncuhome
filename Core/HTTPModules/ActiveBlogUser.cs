using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ncuhome.Blog.Core.HTTPModules
{
    class ActiveBlogUser :System.Web.IHttpModule
    {
        #region IHttpModule 成员

        public void Dispose()
        {
            
        }

        public void Init(System.Web.HttpApplication context)
        {
            context.BeginRequest += new EventHandler(context_BeginRequest);
            context.EndRequest += new EventHandler(context_EndRequest);
        }

        void context_EndRequest(object sender, EventArgs e)
        {
            
        }

        void context_BeginRequest(object sender, EventArgs e)
        {
            System.Web.HttpApplication App= (System.Web.HttpApplication)sender;
            System.Web.HttpContext Content= App.Context;
            if (Ncuhome.Blog.Core.BlogContext.Current.User.BlogUserID == -1) //激活
            {
                if ((Content.Request.Url.PathAndQuery.Contains("active.aspx") || Content.Request.Url.PathAndQuery.Contains("ajax")) || Content.Request.Url.PathAndQuery.Contains("logout"))
                { }
                else
                {
                    Content.Response.Redirect("/active.aspx");
                }
            }
        }

        #endregion
    }
}
