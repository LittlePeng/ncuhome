using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncuhome.Blog.Entity;
using Ncuhome.Blog.Core;
using System.Web.UI.WebControls;

namespace Ncuhome.Blog.Controls
{
   public  class LogNav:SkinnedBlogWebControl
    {
       private Repeater repeater1;
        public LogNav()
        {
            SkinFileName = "LogNav.ascx";
            IsThemed = true;

        }
        protected override void InitializeSkin(System.Web.UI.Control Skin)
        {
          
            repeater1 =(Repeater) Skin.FindControl("repeater1");
            DataBind();
        }
        public override void DataBind()
        {
            Ncuhome.Blog.Core.LogNav[] log = BWeblog_User.GetLogNav(blogContext.BlogUserId);
         
            repeater1.DataSource = log;
            repeater1.DataBind();
            base.DataBind();
        }
    }
}
