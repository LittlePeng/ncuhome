using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
namespace Ncuhome.Blog.Core.HTTPModules
{
   public class DefaultModule:IHttpModule
    {
        #region IHttpModule Members

        public void Dispose()
        {
            
        }

        public void Init(HttpApplication context)
        {
            context.AuthorizeRequest += new EventHandler(context_AuthorizeRequest);
        }

        void context_AuthorizeRequest(object sender, EventArgs e)
        {
            //BlogContext b = BlogContext.Current;
        }

        #endregion
    }
}
