using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Text;
using Ncuhome.Blog.Entity;
using Ncuhome.Blog.Core;
using System.Linq;

namespace Ncuhome.Blog.Controls
{
    public  class Comments :SkinnedBlogWebControl
    {
        private Repeater repeater1;
        public Comments()
        {
            IsThemed = true;
            SkinFileName = "Comments.ascx";
        }
        protected override void InitializeSkin(System.Web.UI.Control Skin)
        {
            repeater1 = (Repeater)(Skin.FindControl("repeater1"));
            DataBind();
        }
        public override void DataBind()
        {
            repeater1.DataSource = BView_WeblogUserComment.GetCommentsByLogID(1, Int32.MaxValue, blogContext.LogId);
            repeater1.DataBind();
            base.DataBind();
        }
    }
}
