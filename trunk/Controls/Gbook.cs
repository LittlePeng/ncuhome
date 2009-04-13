using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Ncuhome.Blog.Core;
using Ncuhome.Blog.Entity;

namespace Ncuhome.Blog.Controls
{
    public  class Gbook:SkinnedBlogWebControl
    {
        public Gbook()
        {
            IsThemed = true;
            SkinFileName = "Gbook.ascx";
        }
        protected override void InitializeSkin(System.Web.UI.Control Skin)
        {
            Literal lit = (Literal)Skin.FindControl("Literal1");
            string g = BGbook.GetGbook(blogContext.MFiiD, blogContext.User.UserInfo.User_NickName, blogContext.IsManager, true, blogContext.IsManager, true, 10);
            lit.Text = g;
        }
        public override void DataBind()
        {
            base.DataBind();
        }
    }
}
