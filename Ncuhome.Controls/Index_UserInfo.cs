using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Ncuhome.Blog.Core;
using Ncuhome.Blog.Entity;

namespace Ncuhome.Blog.Controls
{
    public class Index_UserInfo :SkinnedBlogWebControl
    {
        private Repeater rep;
        public Index_UserInfo()
        {
            SkinFileName = "Index_UserInfo.ascx";
            IsThemed = true;
        }
        protected override void InitializeSkin(System.Web.UI.Control Skin)
        {
            rep =(Repeater) Skin.FindControl("repeater1");
            DataBind();
        }
        public override void DataBind()
        {
            List<Weblog_User> web = new List<Weblog_User>();
            web.Add(blogContext.Owner);
            rep.DataSource = web;
            rep.DataBind();
            base.DataBind();
        }
    }
}
