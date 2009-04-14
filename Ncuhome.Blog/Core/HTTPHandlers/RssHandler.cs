using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Text;

namespace Ncuhome.Blog.Core.HTTPHandlers
{
    class RssHandler:IHttpHandler
    {
        #region IHttpHandler Members

        public bool IsReusable
        {
            get { throw new NotImplementedException(); }
        }

        public void ProcessRequest(HttpContext context)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

}
