using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Ncuhome.Blog.Core;

namespace Ncuhome.Blog.Controls
{
    public class Index_FriList:SkinnedBlogWebControl
    {
        private Repeater repeater1; 
        public Index_FriList()
        {
            SkinFileName = "Index_FriList.ascx";
            IsThemed = true;
        }
        protected override void InitializeSkin(System.Web.UI.Control Skin)
        {
            repeater1 =(Repeater) Skin.FindControl("repeater1");
            DataBind();
        }
        public override void DataBind()
        {
            IEnumerable<Ncuhome.Blog.Entity.View_BlogUserFriend> a = BView_BlogUserFriend.GetByFIID(blogContext.MFiiD).Take(8);
            repeater1.DataSource = a;
            repeater1.DataBind();
            base.DataBind();
        }
    }
}
